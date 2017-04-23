using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MengeCS
{
    /// <summary>
    /// Class for interacting with Menge's ExternalEventTriggers.
    /// </summary>
    public class ExternalTrigger
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="name">The name of the trigger.</param>
        public ExternalTrigger(String name)
        {
            _name = name;
        }

        /// <summary>
        /// Fires this external trigger in the simulator.
        /// </summary>
        public void Fire()
        {
            MengeWrapper.FireExternalTrigger(_name);
        }

        /// <summary>
        /// The name of the trigger.
        /// </summary>
        public String Name { get { return _name; } }
        internal String _name;
    }
}
