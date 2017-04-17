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
            Simulator sim = new Simulator();
            String scene = "4square";
            String mengePath = @"E:\work\projects\menge_fork\";
            String behaveXml = String.Format(@"{0}examples\core\{1}\{1}B.xml", mengePath, scene);
            String sceneXml = String.Format(@"{0}examples\core\{1}\{1}S.xml", mengePath, scene);
            if (sim.Initialize(behaveXml, sceneXml, "orca"))
            {
                System.Console.WriteLine("New simulator created.");
                System.Console.WriteLine("\t{0} agents", sim.AgentCount);
                for (int i = 0; i < 20; ++i)
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
                        System.Console.WriteLine("\tAgent {0} at ({1}, {2} moving a5 {3} m/s)", a, p.X, p.Z, v.Length());
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
