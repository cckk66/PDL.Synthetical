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
        public static string GetTimeFromInt()
        {
            long ltime = Tools.GetIntFromTime();
            long Eticks = (long)(ltime * 10000000) + lLeft;
            DateTime dt = new DateTime(Eticks).ToLocalTime();
            return dt.ToString();
        }
        //将时间变成数字
        public static long GetTimeLikeJS()
        {
            long lLeft = 621355968000000000;
            DateTime dt = DateTime.Now;
            long Sticks = (dt.Ticks - lLeft) / 10000;
            return Sticks;
        }

    }
}
