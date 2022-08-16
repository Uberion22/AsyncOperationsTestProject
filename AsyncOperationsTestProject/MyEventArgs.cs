using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncOperationsTestProject
{
    internal class MyEventArgs: EventArgs
    {
        public readonly int WorkTime;

        public MyEventArgs(int time)
        { 
            WorkTime = time;
        }
    }
}
