using AI_PROJECT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_PROJECT
{
    class SimulatedAnnealing : ISolve
    {
        public event ProblemSolvedDelegate ProblemSolved;
        public event ErrorHappenedDelegate ErrorHappend;

        public delegate void ReportHandler(Suduku current,double temperature,double score);
        public event ReportHandler Report;


        /// <summary>
        /// the initialed temprature
        /// </summary>
        public double T { get; set; }

        public Func<double , double> Schedule { get; set; }


        private double LimitedMinute = 10;

        public SimulatedAnnealing() : this(1)
        {

        }

        public SimulatedAnnealing(Func<double, double> ScheduleFunction) 
        {
            this.T = 1;
            this.Schedule = ScheduleFunction;
        }



        private double CoolingSchedule(double tempreture)
        {

            return 1 - this.sp.Elapsed.TotalMinutes/this.LimitedMinute;
        }

        public SimulatedAnnealing(double tempreture)
        {
            this.T = tempreture;
            this.Schedule = CoolingSchedule;
        }


        System.Diagnostics.Stopwatch sp = new System.Diagnostics.Stopwatch();

        public void Start(Suduku su,double limitedMinutes)
        {
            this.LimitedMinute = limitedMinutes;
            sp.Reset();
            sp.Start();
            var current = su;
            long a = 0;
            while(!current.Solved && this.T>0)
            {
                a++;
                this.T = this.Schedule(a);
                var next = Next(current, this.T);
                var dE = current.ConflictPercent - next.ConflictPercent;
                if(dE > 0)
                {
                    current = next;
                }
                else
                {
                    dE = dE < 0 ? dE * -1 : dE;
                    var r = rand.NextDouble();
                    var p = this.T; //Math.Pow( Math.Pow(Math.E, (double)dE / this.T),-1);
                    if(r <= p)
                        current = next;
                }

                if(a % 100 == 0 && this.Report!=null)
                {
                    this.Report(current, this.T,current.ConflictPercent);
                }

            }

            if(this.ProblemSolved != null)
                this.ProblemSolved(current, (int)a);
        }

        Random rand = new Random();

        private Suduku Next(Suduku su , double t)
        {
            var x = rand.Next(0, (int)su.SudukuType);
            var y1 = rand.Next(0, (int)su.SudukuType);
            var y2 = y1;
            while(y2==y1) y2 = rand.Next(0, (int)su.SudukuType);

            var next = su.Swap(x, y1, x, y2,false);
            if(dic.ContainsKey(next.GetHashCode()))
                return Next(su, t);
            else
                return next;
        }


    }
}
