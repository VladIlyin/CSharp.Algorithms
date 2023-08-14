using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Algorithms.Problems.Topics.Matrix
{
    public partial class MatrixProblem
    {
        public static int[][] SortJaggedArray(int[][] array, int column)
        {
            Array.Sort(array, new JaggedArrayComparer(column));
            return array;
        }

        public class JaggedArrayComparer : IComparer<int[]>
        {
            private int _col;

            public JaggedArrayComparer(int col)
            {
                this._col = col;
            }

            public int Compare(int[]? x, int[]? y)
            {
                return x[_col].CompareTo(y[_col]);
            }
        }
    }
}
