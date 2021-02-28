using System;
using System.Collections.Generic;

namespace Example_005
{
    /// <summary>
    /// Utility class for handling math operations
    /// </summary>
    public static class UtilsMath
    {
        /// <summary>
        /// Progression is arithmetic or geometric 
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static (bool isArithmetic, bool isGeometric) IsProgression(int[] array)
        {
            if (array.Length < 2)
            {
                return (true, true);
            }
            var difArithmetic = array[1] - array[0];
            var difGeometric = array[1] / array[0];
 
            var isArithmetic = true;
            var isGeometric = true;
 
            for(var i = 1; i < array.Length - 1; i++)
            {
                if(isArithmetic)
                    if (array[i + 1] - array[i] != difArithmetic)
                    {
                        isArithmetic = false;
                    }

                if (isGeometric != true) continue;
                if (array[i + 1] / array[i] != difGeometric)
                {
                    isGeometric = false;
                }
            }
            return (isArithmetic, isGeometric);
        }
        
        public static ulong AccermanFunction(ulong n, ulong m)
        {
            if (n == 0)
                return m + 1;
            else
            if ((n != 0) && (m == 0))
                return AccermanFunction(n - 1, 1);
            else
                return AccermanFunction(n - 1, AccermanFunction(n, m - 1));
        }
    }
}