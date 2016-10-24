using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BehaviorTreeLibrary
{
    public class Decorator : Composite
    {
        public Func<bool> CanRun { protected get; set; }
        public Status ReturnStatus { get; set; }

        public Decorator()
        {
            Update = () =>
            {
                if (CanRun != null && CanRun() && Children != null)
                {
                    return Children[0].Tick();
                }
                return ReturnStatus;
            };
        }
    }
}
