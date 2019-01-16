using System.Reflection;

namespace MilosAPI
{
    public class Mapper
    {

        /// <summary>
        /// Mapping properties with identical name and type.
        /// </summary>
        /// <param name="_a">Source</param>
        /// <param name="_b">Destination</param>
        public Mapper(object _a, object _b)
        {
            Mapping(ref _a, ref _b);
        }


        private void Mapping<A, B>(ref A _a, ref B _b)
        {
            PropertyInfo[] _aPI = _a.GetType().GetProperties();
            PropertyInfo[] _bPI = _b.GetType().GetProperties();

            _recursiveB(ref _a, ref _b, ref _aPI, ref _bPI);
        }


        private void _recursiveB<A, B>(ref A a, ref B b, ref PropertyInfo[] aPIArr, ref PropertyInfo[] bPIArr, int i = 0)
        {
            if (i <= bPIArr.Length - 1)
            {
                PropertyInfo pi = bPIArr[i];
                _recursiveA(ref a, ref b, ref aPIArr, ref pi);
                _recursiveB(ref a, ref b, ref aPIArr, ref bPIArr, ++i);
            }
        }


        private void _recursiveA<A, B>(ref A a, ref B b, ref PropertyInfo[] aPIArr, ref PropertyInfo bPI, int i = 0)
        {
            if (i <= aPIArr.Length - 1)
            {
                if (
                    bPI.Name == aPIArr[i].Name 
                    && 
                    bPI.GetType() == aPIArr[i].GetType()
                    )
                {
                    if(aPIArr[i].GetValue(a) != null)
                    bPI.SetValue(b, aPIArr[i].GetValue(a));
                    return;
                }
                _recursiveA(ref a, ref b, ref aPIArr, ref bPI, ++i);
            }
        }


    }
}
