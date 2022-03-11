using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTSLabsExercise
{
    public class ExampleClass
    {
        //Constructor
        public ExampleClass()
        {
        }

        /// <summary>
        /// aboveBelow
        /// </summary>
        /// <param name="numberList">Unsorted collection of integers</param>
        /// <param name="comparisonOperand">Comparison value as an integar</param>
        /// <returns>Hash/object/map/etc. with keys "above" and "below" with the corresponding count of integers from the list that are above or below the comparison value</returns>
        public Dictionary<string, int> aboveBelow(List<int> numberList, int comparisonOperand)
        {
            Dictionary<string, int> result = new Dictionary<string, int>();
            result.Add("above", 0);
            result.Add("below", 0);

            foreach (int number in numberList)
            {
                if (number < comparisonOperand)
                {
                    result["below"]++;
                }
                else if (number > comparisonOperand)
                {
                    result["above"]++;
                }
            }

            return result;
        }

        /// <summary>
        /// stringRotation
        /// </summary>
        /// <param name="rotateString">Original string to be rotated</param>
        /// <param name="rotationAmount">Number of rotations as a positive integer</param>
        /// <returns></returns>
        public string stringRotation(string rotateString, int rotationAmount)
        {
            if (rotationAmount < 0)
            {
                throw new Exception("rotationAmount is invalid.  A positive integer is expected");
            }

            StringBuilder sb = new StringBuilder(rotateString);

            for (int i = 0; i < rotationAmount; i++)
            {
                sb.Insert(0, sb[sb.Length - 1]);
                sb.Remove(sb.Length - 1, 1);
            }

            return sb.ToString();
        }
    }
}
