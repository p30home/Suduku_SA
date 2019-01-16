using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_PROJECT
{
    public class ISolve
    {
        public delegate void ProblemSolvedDelegate(Suduku goalState, int ProcessedCount);
        public delegate void ErrorHappenedDelegate(Exception ex);

        protected Dictionary<int, bool> dic = new Dictionary<int, bool>();

    }
}
