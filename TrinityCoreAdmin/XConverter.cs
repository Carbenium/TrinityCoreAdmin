﻿using System;

namespace TrinityCoreAdmin
{
    internal class XConverter
    {
        public static Int32 ToInt32(string str)
        {
            int output;
            Int32.TryParse(str, out output);
            return output;
        }

        public static UInt32 ToUInt32(string str)
        {
            uint output;
            UInt32.TryParse(str, out output);
            return output;
        }

        public static Int32 ToInt32(object str)
        {
            int output;
            Int32.TryParse(str.ToString(), out output);
            return output;
        }

        public static UInt32 ToUInt32(object str)
        {
            uint output;
            UInt32.TryParse(str.ToString(), out output);
            return output;
        }

        public static long ToLong(string str)
        {
            long output;
            long.TryParse(str, out output);
            return output;
        }

        public static long Tolong(object str)
        {
            long output;
            long.TryParse(str.ToString(), out output);
            return output;
        }
    }
}