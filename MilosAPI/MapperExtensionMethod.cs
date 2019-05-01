using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilosAPI
{
    public static class MapperExtensionMethod
    {
        public static void Map(this object destination, object source)
        {

            new Mapper(source, destination);

        }
    }
}
