using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericApp
{
    interface ICalculation<in T> where T : struct
    {
        void Subtract(T a, T b);
    }
    class Calculation<T> : ICalculation<T> where T : struct
    {
        public void Subtract(T a, T b)
        {
           
        }
    }
    //internal class Calculation : ICalculation<int>
    //{
    //    public void Subtract(int a, int b)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
}
