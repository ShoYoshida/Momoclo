using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Momoclo.Util
{
    public class Utility
    {


        public static double? NullorValue(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return null;
            }
            else
            {
                return double.Parse(s);
            }
        }

        public static string NullToZero(string s)
        {
            if (s == null)
            {
                return "0";
            }
            else
            {
                return s;
            }
        }

        public static double NullorValue(double? d)
        {
            return d ?? 0d;
        }
    }
}