using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sellYourCar
{
    static class GetIdValueUtil
    {
        public static int GetIdValue(string value)
        {
            // get value from string
            var clearValue = value.Replace(@"[", "").Replace(@"]", "");
            return Convert.ToInt32(clearValue.Split(',')[0]);
        }
    }
}
