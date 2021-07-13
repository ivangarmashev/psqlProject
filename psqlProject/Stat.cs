using System.Collections.Generic;

namespace psqlProject
{
    public struct Stat
    {
        public int CountEvents;
        public Dictionary<string, int> EventsByLevel;
        public Dictionary<string, int> EventsBySource;
    }
}

