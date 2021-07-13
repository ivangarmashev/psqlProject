using System.Collections.Generic;

namespace psqlProject
{
    
    public class Stat
    {
        public int CountEvents = 0;
        public Dictionary<string, int> EventsByLevel = new Dictionary<string, int>();
        public Dictionary<string, int> EventsBySource = new Dictionary<string, int>();
    }
}

