using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSession.Core
{
    public static class GlobalExpressions
    {
        /// <summary>
        ///     Get target property by him name from specific object.
        ///     if found; otherwise, null.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="name"></param>
        /// <exception cref="InvalidCastException"/>
        /// <exception cref="System.Reflection.AmbiguousMatchException"/>
        /// <returns></returns>
        public static T GetPropertyValue<T>(this object that, string name)
        {
            object property = that.GetType()?.GetProperty(name)?.GetValue(that);

            if (property == null) return default(T);

            return (T)property;
        }

        public static bool FindIn(this string that, params string[] targets)
        {
            return string.Join(" ", targets).Contains(that);
        }


        public static bool IsInLevDistanceOf(this string that, string target, int distance)
        {
            return LevenshteinDistance(that, target) <= distance;
        }

        public static int MinOfThree(int a, int b, int c) => (a = a < b ? a : b) < c ? a : c;
        public static int LevenshteinDistance(this string that, string target)
        {
            var n = that.Length + 1;
            var m = target.Length + 1;
            var matrixD = new int[n, m];

            const int deletionCost = 1;
            const int insertionCost = 1;

            for (var i = 0; i < n; i++)
            {
                matrixD[i, 0] = i;
            }

            for (var j = 0; j < m; j++)
            {
                matrixD[0, j] = j;
            }

            for (var i = 1; i < n; i++)
            {
                for (var j = 1; j < m; j++)
                {
                    var substitutionCost = that[i - 1] == target[j - 1] ? 0 : 1;

                    matrixD[i, j] = MinOfThree(matrixD[i - 1, j] + deletionCost,          // удаление
                                            matrixD[i, j - 1] + insertionCost,         // вставка
                                            matrixD[i - 1, j - 1] + substitutionCost); // замена
                }
            }

            return matrixD[n - 1, m - 1];
        }

        public static string SwapToSize(this string that, int len)
        {
            if (that.Length > len)
                return that.Substring(0, len - 4) + "...";

            return that;
        }
    }
}
