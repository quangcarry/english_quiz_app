using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace form_net.Utils
{
    internal class StringUtil
    {
        public static bool isEmpty(string str)
        {
            return str.Trim().Equals("") || str == null;
        }
    }
}
