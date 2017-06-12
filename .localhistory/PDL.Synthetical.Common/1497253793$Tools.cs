using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDL.Synthetical.Common
{
    public static class Tools
    {
        private long lLeft = 621355968000000000;

        //将数字变成时间
        public string GetTimeFromInt(long ltime)
        {

            long Eticks = (long)(ltime * 10000000) + lLeft;
            DateTime dt = new DateTime(Eticks).ToLocalTime();
            return dt.ToString();

        }
    }
}
