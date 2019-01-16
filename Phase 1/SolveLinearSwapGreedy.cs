using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phase_1
{
    class SolveLinearSwapGreedy : ISolve
    {
        public delegate void InfoDelegate(Suduku CurrentSuduku, int ProcessedCount);

        public event InfoDelegate InfoEvent;

        public event ErrorHappenedDelegate ErrorHappend;

        public event ProblemSolvedDelegate ProblemSolved;


        public bool Start(Suduku su)
        {
            Queue<Suduku> queue = new Queue<Suduku>();



            while(queue.Count > 0)
            {
                if(Start(queue.Dequeue()))
                    return true;
            }

            return false;
        }

        private Suduku GetNext(Suduku su)
        {
            for(int i = 0;i < (int)su.SudukuType;i++)
            {
                for(int j = i+1;j < (int)su.SudukuType;j++)
                {
                    var res = su.Swap(su.ValidRow + 1, i, su.ValidRow + 1, j);
                    if(res != null && !dic.ContainsKey(res.GetHashCode()))
                        return res;
                }
            }

            return null; 
        }
    }
}
