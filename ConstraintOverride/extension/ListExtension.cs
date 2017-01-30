using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstraintOverride.extension
{
    public static class ListExtension
    {
        private static Random rng = new Random();

        public static T RandomElement<T>(this List<T> list)
        {
            return list[rng.Next(list.Count)];
        }

    }
}
