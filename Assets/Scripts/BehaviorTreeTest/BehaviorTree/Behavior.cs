using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BehaviorTreeLibrary
{
    public class Behavior : IBehavior
    {
        public Status Status { get; set; }
        public IBehavior Parent { get; set; }
        public Action Initialize { protected get; set; }
        public Func<Status> Update { protected get; set; }
        public Action<Status> Terminate { protected get; set; }
        public virtual void Reset()
        {}

        public Status Tick()
        {
            if (Status == Status.BhInvalid && Initialize != null)
            {
                Initialize();
            }

            Status = Update();

            if (Status != Status.BhRunning && Terminate != null)
            {
                Terminate(Status);
            }

            return Status;
        }

     
    }
}
