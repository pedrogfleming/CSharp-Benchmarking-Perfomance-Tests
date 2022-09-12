using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayList_vs_List_vs_Array
{
    public class IterableManager
    {
        public void ArrayList_Test(int numElements)
        {
            ArrayList list = new();
            for (int i = 0; i < numElements; i++)
            {
                list.Add(i);
            }
        }
        public void List_Test(int numElements)
        {
            List<int> list = new();
            for (int i = 0; i < numElements; i++)
            {
                list.Add(i);
            }
        }
        public void SimpleArray_Test(int numElements)
        {
            int[] list = new int[numElements];
            for (int i = 0; i < numElements; i++)
            {
                list[i] = i;
            }
        }
    }
}
