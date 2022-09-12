using System.Text;

namespace String_Vs_StringBuilder
{
    public class StringManager
    {
        /// <summary>
        /// Using string type concatenation
        /// </summary>
        /// <returns></returns>
        public void StringTypeConcatenation(int numRepetitions)
        {
            string s = string.Empty;
            for (int i = 0; i < numRepetitions; i++)
            {
                s = s + "a";
            }
        }
        /// <summary>
        /// Using stringBuilder type concatenation
        /// </summary>
        /// <returns></returns>
        public void StringBuilderTypeConcatenation(int numRepetitions)
        {
            StringBuilder sb = new();
            for (int i = 0; i < numRepetitions; i++)
            {
                sb.Append("a");
            }
        }
    }
}
