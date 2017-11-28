using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class MergeSorter
    {
        public static Dictionary<string, int> MergeSort(Dictionary<string, int> numbers)
        {
            if (numbers.Count <= 1)
            {
                return numbers; //base case
            }

            var left = new Dictionary<string, int>();
            var right = new Dictionary<string, int>();

            var i = 0;
            foreach (KeyValuePair<string, int> element in numbers)
            {
                if (i % 2 > 0)
                {
                    left.Add(element.Key, element.Value);
                }
                else
                {
                    right.Add(element.Key, element.Value);
                }
                i++;
            }

            left = MergeSort(left);
            right = MergeSort(right);

            return Merge(left, right);
        }

        private static Dictionary<string, int> Merge(Dictionary<string, int> left, Dictionary<string, int> right)
        {
            var result = new Dictionary<string, int>();

            while (left.Count > 0 && right.Count > 0)
            {
                if (left.First().Value >= right.First().Value)
                {
                    //we take the first element from the left and then remove it
                    result.Add(left.First().Key, left.First().Value);
                    left.Remove(left.First().Key);
                }
                else
                {
                    result.Add(right.First().Key, right.First().Value);
                    right.Remove(right.First().Key);
                }
            }

            // as soon as one of the sides doesn't have more values
            while (left.Count > 0)
            {
                result.Add(left.First().Key, left.First().Value);
                left.Remove(left.First().Key);
            }

            while (right.Count > 0)
            {
                result.Add(right.First().Key, right.First().Value);
                right.Remove(right.First().Key);
            }



            return result;

        }
    }
}
