using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilosAPI
{
    public static class MapperExtensionMethod
    {
        /// <summary>
        /// Mapping properties with identical name and type.
        /// </summary>
        /// <param name="_a">Source</param>
        /// <param name="_b">Destination</param>
        /// 
        public static void Map(this object _dest, object _sour)
        {

            new Mapper(_sour, _dest);

        }
    }
}
