///////////////////////////////////////////////////////////////////
//
// STARTER-KIT : demo app 
// Copyright (c) D.E. 2017
//
// Author: Dino Esposito
//

using System;
using System.Globalization;

namespace Expoware.YouStart.Common.Extensions
{
    public static class IntExtensions
    {
        public static String ToStringIfGreaterThan(this int theNumber, int min = 0, string empty = "", string format = "{0}")
        {
            if (theNumber <= min)
                return empty;

            return String.Format(format, theNumber);
        }

        public static String ToStringIfGreaterThan(this double theNumber, int min = 0, string empty = "", string format = "{0}")
        {
            if (theNumber <= min)
                return empty;

            return String.Format(format, theNumber);
        }

        public static String ToStringTimeZone(this double timeZone)
        {
            if ((int)timeZone == 0)
                return "GMT";
            if (timeZone > 0)
                return String.Format("GMT +{0}", timeZone);
            return String.Format("GMT -{0}", timeZone);
        }

        public static int ToLowerBound(this int theNumber, int lower)
        {
            return theNumber < lower ? lower : theNumber;
        }

        public static int ToUpperBound(this int theNumber, int upper)
        {
            return theNumber > upper ? upper : theNumber;
        }

        public static int ToCelsius(this int fahrenheit)
        {
            return (int)((5.0 / 9.0) * (fahrenheit - 32));
        }

        public static string ToCelsiusOrDefault(this int fahrenheit, string zero = "")
        {
            if (fahrenheit == 0)
                return zero;

            return ((int)((5.0 / 9.0) * (fahrenheit - 32))).ToString(CultureInfo.InvariantCulture);
        }

        public static bool Between(this int theNumber, int min, int max)
        {
            return theNumber >= min && theNumber <= max;
        }

        public static bool StrictBetween(this int theNumber, int min, int max)
        {
            return theNumber > min && theNumber < max;
        }
    }
}