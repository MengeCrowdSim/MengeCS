using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace MengeCS
{
    class MengeWrapper
    {
        [DllImport("MengeCore")]
        public static extern bool InitSimulator([MarshalAs(UnmanagedType.LPStr)] String behaveFile,
                                                [MarshalAs(UnmanagedType.LPStr)] String sceneFile,
                                                [MarshalAs(UnmanagedType.LPStr)] String model,
                                                [MarshalAs(UnmanagedType.LPStr)] String pluginPath
                                                );

        [DllImport("MengeCore")]
        public static extern uint AgentCount();
        
        [DllImport("MengeCore")]
        public static extern float SetTimeStep(float timestep);

        [DllImport("MengeCore")]
        public static extern bool DoStep();

        [DllImport("MengeCore")]
        public static extern bool GetAgentPosition(uint i, ref float x, ref float y, ref float z);

        [DllImport("MengeCore")]
        public static extern bool GetAgentVelocity(uint i, ref float x, ref float y, ref float z);

        [DllImport("MengeCore")]
        public static extern bool GetAgentOrient(uint i, ref float x, ref float y );

        [DllImport("MengeCore")]
        public static extern int GetAgentClass(uint i);

        [DllImport("MengeCore")]
        public static extern float GetAgentRadius(uint i);
    }
}
