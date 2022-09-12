namespace OneDArray_vs_TwoDArray_vs_JaggedArray
{
    public class ArrayManager
    {
        public void One_Dimensional_Array(int numElements)
        {
            int[] list = new int[numElements];
            for (int i = 0; i < numElements; i++)
            {
                list[i] = i;
            }
        }
        public void Two_Dimensional_Array(int numElements)
        {
            int[,] list = new int[numElements, numElements];
            for (int i = 0; i < numElements; i++)
            {
                for (int j = 0; j < numElements; j++)
                {
                    list[i, j] = i;
                }                
            }
        }
        public void JaggedArray(int numElements)
        {
            int[][] list = new int[numElements][];
            for (int i = 0; i < numElements; i++)
            {
                list[i] = new int[numElements];
            }
            for (int i = 0; i < numElements; i++)
            {
                for (int j = 0; j < numElements; j++)
                {
                    list[i][j] = i; 
                }
            }
        }
    }
}
