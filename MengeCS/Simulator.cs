using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MengeCS
{
    /// <summary>
    /// Wrapper for Menge::SimulatorBase
    /// </summary>
    public class Simulator
    {   
        /// <summary>
        /// Constructor.
        /// </summary>
        public Simulator() {
            _agents = new List<Agent>();
        }

        public bool Initialize(String behaveXml, String sceneXml, String model)
        {
            if (MengeWrapper.InitSimulator(behaveXml, sceneXml, model, null))
            {
                uint count = MengeWrapper.AgentCount();
                for (uint i = 0; i < count; ++i)
                {
                    Agent agt = new Agent();
                    float x = 0;
                    float y = 0;
                    float z = 0;
                    MengeWrapper.GetAgentPosition(i, ref x, ref y, ref z);
                    agt._pos = new Vector3(x, y, z);
                    MengeWrapper.GetAgentOrient(i, ref x, ref y);
                    agt._orient = new Vector2(x, y);
                    agt._class = MengeWrapper.GetAgentClass(i);
                    agt._radius = MengeWrapper.GetAgentRadius(i);
                    _agents.Add(agt);
                }
                    return true;
            }
            else
            {
                System.Console.WriteLine("Failed to initialize simulator.");
            }
            return false;
        }

        /// <summary>
        /// The number of agents in the simulation.
        /// </summary>
        public int AgentCount { get { return _agents.Count;} }

        /// <summary>
        /// Returns the ith agent.
        /// </summary>
        /// <param name="i">Index of the agent to retrieve.</param>
        /// <returns>The ith agent.</returns>
        public Agent GetAgent( int i ) {
            return _agents[i];
        }

        /// <summary>
        /// The simulation time step.
        /// </summary>
        public float TimeStep
        {
            get { return _timeStep; }
            set { _timeStep = value; MengeWrapper.SetTimeStep(_timeStep); }
        }
        private float _timeStep = 0.1f;

        /// <summary>
        /// Advances the simulation by the current time step.
        /// </summary>
        /// <returns>True if evaluation is successful and the simulation can proceed.</returns>
        public bool DoStep() {
            bool running = MengeWrapper.DoStep();
            for (int i = 0; i < _agents.Count; ++i) {
                float x = 0, y = 0, z = 0;
                MengeWrapper.GetAgentPosition((uint)i, ref x, ref y, ref z);
                _agents[i].Position.Set(x, y, z);
                MengeWrapper.GetAgentOrient((uint)i, ref x, ref y);
                _agents[i].Orientation.Set(x, y);
            }
            return true;
        }

        /// <summary>
        /// The agents in the simulation.
        /// </summary>
        private List<Agent> _agents;
    }
}
