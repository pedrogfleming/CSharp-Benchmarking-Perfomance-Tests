using System.Reflection;
using System.Reflection.Emit;
using System.Text;

namespace FastClassFactories
{
    public class FastClassFactory
    {
        public int repetitions;

        /// <summary>
        /// A delegate to create the object
        /// </summary>
        /// <returns></returns>
        public delegate object ClassCreator();

        public Dictionary<string, ClassCreator> ClassCreators = new();
        public FastClassFactory(int repetitions)
        {
            this.repetitions = repetitions;
        }

        public void CompileTime_Construction(string typeName)
        {
            for (int i = 0; i < this.repetitions; i++)
            {
                switch (typeName)
                {
                    case "System.Text.StringBuilder":
                            new StringBuilder();
                        break;
                    default:
                        throw new NotImplementedException();
                        break;
                }
            }
        }
        public void Dynamic_Construction(string typeName)
        {
            for (int i = 0; i < this.repetitions; i++)
            {
                Activator.CreateInstance(Type.GetType(typeName));
            }
        }
        public void CIL_Method_Construction(string typeName)
        {
            for (int i = 0; i < this.repetitions; i++)
            {
                ClassCreator classCreator = GetClassCreator(typeName);
                classCreator();
            }
        }

        private ClassCreator GetClassCreator(string typeName)
        {
            // get delegate from dictionary
            if (ClassCreators.ContainsKey(typeName)) { return ClassCreators[typeName]; }

            // get the default constructor of the type
            Type t = Type.GetType(typeName);
            ConstructorInfo ctor = t.GetConstructor(new Type[0]);

            //create a new dynamic method that constructs and returns the type
            string methodName = t.Name + "Ctor";
            DynamicMethod dm = new(methodName, t, new Type[0], typeof(object).Module);
            ILGenerator lgen = dm.GetILGenerator();
            lgen.Emit(OpCodes.Newobj, ctor);
            lgen.Emit(OpCodes.Ret);

            //add delegate to dictionary and return
            ClassCreator creator = (ClassCreator)dm.CreateDelegate(typeof(ClassCreator));
            ClassCreators.Add(typeName, creator);
            return creator;
        }
    }
}
