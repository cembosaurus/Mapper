using System.Reflection;
using System.Threading;

namespace MilosAPI
{
    static public class MapperStatic
    {
        /// <summary>
        /// Mapping properties with identical name and type.
        /// </summary>
        /// <param name="_a">Source</param>
        /// <param name="_b">Destination</param>
        static public void Copy<Source, Target>(Source _a, Target _b)
        {
            object locker = new object();
            Monitor.Enter(locker);
            try
            {
                PropertyInfo[] sourceInfoArray = _a.GetType().GetProperties();
                PropertyInfo[] targetInfoArray = _b.GetType().GetProperties();

                _recursiveA(ref _a, ref _b, ref sourceInfoArray, ref targetInfoArray);
            }
            finally
            {
                Monitor.Exit(locker);
            }
        }


        static private void _recursiveA<Source, Target>(ref Source source, ref Target target, ref PropertyInfo[] sourceInfoArray, ref PropertyInfo[] targetInfoArray, int index = 0)
        {
            if (index <= targetInfoArray.Length - 1)
            {
                PropertyInfo pi = targetInfoArray[index];
                _recursiveB(ref source, ref target, ref sourceInfoArray, ref pi);
                _recursiveA(ref source, ref target, ref sourceInfoArray, ref targetInfoArray, ++index);
            }
        }


        static private void _recursiveB<Source, Target>(ref Source sourceObj, ref Target targetObj, ref PropertyInfo[] sourceInfoArray, ref PropertyInfo targetInfo, int index = 0)
        {
            if (index <= sourceInfoArray.Length - 1)
            {
                if (
                    targetInfo.Name == sourceInfoArray[index].Name 
                    && 
                    targetInfo.GetType() == sourceInfoArray[index].GetType()
                    )
                {
                    if(sourceInfoArray[index].GetValue(sourceObj) != null)
                    targetInfo.SetValue(targetObj, sourceInfoArray[index].GetValue(sourceObj));
                    return;
                }
                _recursiveB(ref sourceObj, ref targetObj, ref sourceInfoArray, ref targetInfo, ++index);
            }
        }


    }
}

