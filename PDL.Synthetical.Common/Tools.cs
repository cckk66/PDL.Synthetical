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
        public static long ticks
        {
            get
            {
               // return ((GetTimeLikeJS() * 10000) + 621355968000000000);
                return DateTime.UtcNow.Ticks;
            }
        }
        //将时间变成数字
        public static long GetTimeLikeJS()
        {
            DateTime dt = DateTime.Now;
            long Sticks = (dt.Ticks - lLeft) / 10000;
            return Sticks;
        }

    }
}
