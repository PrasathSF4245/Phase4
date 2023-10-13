using System;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;

namespace CafetariaCardManagement
{
    public partial class CustomList<Type> : IEnumerable, IEnumerator
    {
        int i;


        //this sets value for initialization
        public IEnumerator GetEnumerator()
        {
            i = -1;
            return (IEnumerator)this;
        }
        //checks the condition Incremets the value for loop
        public bool MoveNext()
        {
            if (i < _count - 1)
            {
                i++;
                return true;
            }
            Reset();
            return false;
        }
        //Intializze the value for Loop
        public void Reset()
        {
            i = -1;
        }

        //Returns the value
        public object Current { get { return _array[i]; } }

    }
}