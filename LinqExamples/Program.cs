using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ
{
    internal class Program
    {
        private static void Main()
        {
            var contributorByte = new Contributor<byte>();
            var contributorString = new Contributor<string>();

            contributorByte.FillArray(1,2,3,4,5,6,7,8,9,10);
            contributorString.FillArray("First","Second","Third","Fourth","Fifth","Sixth","Seventh","Eighth","Ninth","Tenth");

            var arr1Byte = contributorByte.ArrayList; 
            var arr1String = contributorString.ArrayList; 

            /* Aggregate */
            Console.WriteLine($"Start : First [byte] array [{string.Join(',',arr1Byte)}]");
            Console.WriteLine($"Start : First [string] array [{string.Join(',', arr1String)}]\n");

            var minArr1Byte = arr1Byte.Aggregate(arr1Byte[0], (current, next) => next < current ? next : current);
            var maxArr1Byte = arr1Byte.Aggregate(arr1Byte[0], (current, next) => next > current ? next : current);
            var minArr1String = arr1String.Aggregate(arr1String[0], (current, next) => next.Length < current.Length ? next : current);
            var maxArr1String = arr1String.Aggregate(arr1String[0], (current, next) => next.Length > current.Length ? next : current);

            Console.WriteLine($"\tMin [byte] from first  array is [{minArr1Byte}], Max from first array is [{maxArr1Byte}]");
            Console.WriteLine($"\tMin [string] from first  array is [{minArr1String}], Max from first array is [{maxArr1String}]\n");

            var arr2Byte = contributorByte.ArrayList;
            var arr2String = contributorString.ArrayList;

            /* All */
            Console.WriteLine($"Start : Second [byte] array [{string.Join(',', arr2Byte)}]");
            Console.WriteLine($"Start : Second [string] array [{string.Join(',', arr2String)}]\n");

            Predicate<byte> arr2ByteCondition2 = b => { return b >= 10; };
            var arr2ByteCondition2Result = new Func<byte, bool>(arr2ByteCondition2);

            Predicate<string> arr2StringCondition2 = b => { return b.Length >= 6; };
            var arr2StringCondition2Result = new Func<string, bool>(arr2StringCondition2);

            var arr2ByteLessTen = arr2Byte.All(arr2ByteCondition2Result);
            if (!arr2ByteLessTen)
                arr2Byte.RemoveAll(arr2ByteCondition2);

            var arr2StringLessTen = arr2String.All(arr2StringCondition2Result);
            if (!arr2StringLessTen)
                arr2String.RemoveAll(arr2StringCondition2);

            Console.WriteLine($"\tFinal >=10 : Second [byte] array [{string.Join(',', arr2Byte)}]");
            Console.WriteLine($"\tFinal >= 6: Second [string] array [{string.Join(',', arr2String)}]");
        }

    }

    internal class Contributor<T> : ICloneable 
    {
        internal List<T> ArrayList = new List<T>();

        internal void FillArray(params T[] args)
        {
            ArrayList.AddRange(args);
        }

        public object Clone()
        {
            return ArrayList;
        }
    }

    
}
