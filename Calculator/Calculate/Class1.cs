using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculate
{
    public class Operate
    {
        public double add(double d1, double d2)
        {
            double result=0;
            result = d1 + d2;
            return result;
        }
        public double minus(double d1, double d2)
        {
            double result = 0;
            result = d1 - d2;
            return result;
        }
        public double times(double d1, double d2)
        {
            double result = 0;
            result = d1 * d2;
            return result;
        }
        public double divide(double d1, double d2)
        {
            double result = 0;
            result = d1 / d2;
            return result;
        }
    }
}
