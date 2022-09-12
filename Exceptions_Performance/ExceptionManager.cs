namespace Exceptions_Performance
{
    public class ExceptionManager
    {
        public void Loop_Without_Exceptions(int repetitions)
        {
            int count = 0;
            for (int r = 0; r < repetitions; r++)
            {
                count = count + 1;
            }
        }
        public void Loop_With_Exceptions(int repetitions)
        {
            int count = 0;
            for (int r = 0; r < repetitions; r++)
            {
                try
                {
                    count = count + 1;
                    throw new InvalidOperationException();
                }
                catch (InvalidOperationException)
                {
                }
            }
        }
    }
}
