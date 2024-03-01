using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericApp
{
    static class Addition
    {
        public static void Add<T1, T2>(T1 a, T2 b)
        {

        }
        public static void Add<T>(T a, T b) where T : struct
        {

        }
    }
}
