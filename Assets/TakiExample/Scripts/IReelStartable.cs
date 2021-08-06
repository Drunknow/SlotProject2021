using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlotProject.TakiExample
{
    interface IReelStartable
    {
        public void StartReel(int target);
        public void SetStopEvent(Action action);
    }
}
