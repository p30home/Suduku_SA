using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AI_PROJECT
{
    public static class MyExtenstion
    {
        public static void InvokeIfRequired<T>(this T control, Action<T> action) where T :Control
        {
            if(control.InvokeRequired)
            {
                control.Invoke(new Action(()=> action(control)));
            }
            else
            {
                action(control);
            }
        }

        public static Suduku GetNextRandom(this Suduku current,bool HoldPointer = false)
        {
            Random rand = new Random((int)DateTime.Now.Ticks);
            var x = rand.Next(0, (int)current.SudukuType);
            var y1 = rand.Next(0, (int)current.SudukuType);
            var y2 = y1;
            while(y2 == y1) y2 = rand.Next(0, (int)current.SudukuType);

            var next = current.Swap(x, y1, x, y2, HoldPointer);

            return next;
        }


    }
}
