using System;
using System.Collections;

namespace ForEach_vs_For
{
    public class LoopManager
    {
        public static ArrayList arrayList;
        public static List<int> genericList;
        public static int[] array;

        public LoopManager(int numElements)
        {
            arrayList = new(numElements);
            genericList = new(numElements);
            array = new int[numElements];
            Random random = new();

            for (int i = 0; i < numElements; i++)
            {
                int number = random.Next(256);
                arrayList.Add(number);
                genericList.Add(number);
                array[i] = number;
            }
        }
        public void For_Loop_ArrayList()
        {
            for (int i = 0; i < LoopManager.arrayList.Count; i++)
            {
                int result = (int)arrayList[i];
            }

        }
        public void ForEach_Loop_ArrayList()
        {
            foreach (int item in LoopManager.arrayList)
            {
                int result = item;
            }
        }
        public void For_Loop_GenericList()
        {
            for (int i = 0; i < LoopManager.genericList.Count; i++)
            {
                int result = genericList[i];
            }
        }
        public void ForEach_Loop_GenericLis()
        {
            foreach (int item in LoopManager.arrayList)
            {
                int result = item;
            }
        }
        public void For_Loop_SimpleArray()
        {
            for (int i = 0; i < LoopManager.array.Length; i++)
            {
                int result = array[i];
            }

        }
        public void ForEach_Loop_SimpleArray()
        {
            foreach (int item in LoopManager.array)
            {
                int result = item;
            }
        }
    }
}
