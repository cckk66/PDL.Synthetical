using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDL.Synthetical.Common
{
    public static class Tools
    {
        private static long lLeft = 621355968000000000;

        //将数字变成时间
        public static string GetTimeFromInt(long ltime)
        {
            long Eticks = (long)(ltime * 10000000) + lLeft;
            DateTime dt = new DateTime(Eticks).ToLocalTime();
            return dt.ToString();
        }
        //将时间变成数字
        public long GetIntFromTime()
        {
            DateTime dt1 = DateTime.Now.ToUniversalTime();
            long Sticks = (dt1.Ticks - lLeft) / 10000000;
            return Sticks;

        }

    }
}
