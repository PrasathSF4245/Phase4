using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CafetariaCardManagement
{
    public partial class CustomList<Type>
    {
        private static int _count;

        private static int _size;
    
        /// This gets the Count of List
     
        public int Count { get { return _count; } }

 
        /// This gets the Size of List
  

        public int Capacity { get { return _size; } }
        //Array inzialization
        private static Type[] _array;

        public Type this[int index]
        {
            get { return _array[index]; }
            set { _array[index] = value; }

        }

        //List is created with Default Size
        public CustomList()
        {
            _count = 0;
            _size = 4;
            _array = new Type[_size];
        }

        //List is created with given Size
        public CustomList(int size)
        {
            _count = 0;
            _size = size;
            _array = new Type[_size];
        }

        //this method adds data to list
        public void Add(Type data)
        {
            if (_count == _size)
            {
                GrowSize();
            }
            _array[_count] = data;
            _count++;
        }
        //this method increases the size of array
        public static void GrowSize()
        {
            _size *= 2;
            Type[] temp = new Type[_size];
            for (int i = 0; i < _count; i++)
            {
                temp[i] = _array[i];
            }
            _array = temp;
        }

        //this method adds a list to list
        public void AddRange(CustomList<Type> dataList)
        {
            _size = _count + dataList.Count + 4;
            Type[] temp = new Type[_size];
            for (int i = 0; i < _count; i++)
            {
                temp[i] = _array[i];

            }
            int k = 0;
            for (int j = _count; j < _count + dataList.Count; j++)
            {
                temp[j] = dataList[k];
                k++;
            }
            _array = temp;
            _count += dataList.Count;
        }
    }
}