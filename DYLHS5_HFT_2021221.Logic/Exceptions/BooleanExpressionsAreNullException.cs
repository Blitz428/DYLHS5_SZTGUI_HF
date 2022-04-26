using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DYLHS5_HFT_2021221.Logic
{
    public class BooleanExpressionsAreNullException : Exception
    {
        public BooleanExpressionsAreNullException(string msg) : base(msg)
        {

        }
    }
}
