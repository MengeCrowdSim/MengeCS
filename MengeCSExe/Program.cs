using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MengeCS;
using System.Runtime.InteropServices;

namespace MengeCSExe
{
    class Program
    {
        static void Main(string[] args)
        {
            Run4Square();
            //RunUserEvent();
        }

        /// <summary>
        /// Runs the 4square example for 20 time steps.
        /// </summary>
        static void Run4Square()
        {
            Simulator sim = new Simulator();
            String scene = "4square";
            String mengePath = @"E:\work\projects\menge_fork\";
            String behaveXml = String.Format(@"{0}examples\core\{1}\{1}B.xml", mengePath, scene);
            String sceneXml = String.Format(@"{0}examples\core\{1}\{1}S.xml", mengePath, scene);
            if (sim.Initialize(behaveXml, sceneXml, "orca"))
            {
                System.Console.WriteLine("New simulator created.");
                System.Console.WriteLine("\tBFSM has {0} states.", sim.StateCount);
                for (uint i = 0; i < sim.StateCount; ++i)
                {
                    System.Console.WriteLine("\t\tState: {0}: {1}", i, sim.GetStateName(i));
                }
                    System.Console.WriteLine("\t{0} agents", sim.AgentCount);
                for (int i = 0; i < 1; ++i)
                {
                    System.Console.WriteLine("Step {0}", i + 1);
                    if (!sim.DoStep())
                    {
                        System.Console.WriteLine("Simulation done...quitting");
                        break;
                    }
                    for (int a = 0; a < sim.AgentCount; ++a)
                    {
                        Agent agt = sim.GetAgent(a);
                        Vector3 p = agt.Position;
                        Vector3 v = agt.Velocity;
                        Vector2 o = agt.Orientation;
                        System.Console.WriteLine(
                            "\tAgent {0} at ({1}, {2}), moving at {3} m/s, facing ({4}, {5}), " +
                            "in state \"{6}\"", 
                            a, p.X, p.Z, v.Length(), o.X, o.Y, sim.GetStateName(agt.StateId));
                    }
                }

            }
            else
            {
                System.Console.WriteLine("Error initializing simulation");
            }
        }

        /// <summary>
        /// Runs the userEvent.xml example. Invokes the external triggers every few time steps.
        /// </summary>
        static void RunUserEvent()
        {
            Simulator sim = new Simulator();
            String scene = "userEvent";
            String mengePath = @"E:\work\projects\menge_fork\";
            String behaveXml = String.Format(@"{0}examples\core\{1}\{1}B.xml", mengePath, scene);
            String sceneXml = String.Format(@"{0}examples\core\{1}\{1}S.xml", mengePath, scene);
            if (sim.Initialize(behaveXml, sceneXml, "orca"))
            {
                System.Console.WriteLine("Simulator has {0} external triggers", sim.Triggers.Count);
                System.Console.WriteLine("New simulator created.");
                System.Console.WriteLine("BFSM has {0} states.", sim.StateCount);
                System.Console.WriteLine("\t{0} agents", sim.AgentCount);
                for (int i = 0; i < 20; ++i)
                {
                    if ( i % 3 == 0 )
                    {
                        int triggerIndex = (i / 3) % sim.Triggers.Count;
                        ExternalTrigger trigger = sim.Triggers[triggerIndex];
                        System.Console.WriteLine("Firing trigger: {0}", trigger.Name);
                        trigger.Fire();
                    }
                    System.Console.WriteLine("Step {0}", i + 1);
                    if (!sim.DoStep())
                    {
                        System.Console.WriteLine("Simulation done...quitting");
                        break;
                    }
                    for (int a = 0; a < sim.AgentCount; ++a)
                    {
                        Agent agt = sim.GetAgent(a);
                        Vector3 p = agt.Position;
                        Vector3 v = agt.Velocity;
                        System.Console.WriteLine(
                            "\tAgent {0} at ({1}, {2}) moving at {3} m/s.", 
                            a, p.X, p.Z, v.Length());
                    }
                }
            }
            else
            {
                System.Console.WriteLine("Error initializing simulation");
            }
        }
    }
}
