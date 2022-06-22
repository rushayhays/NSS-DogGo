using System.Collections.Generic;
using System;

namespace DogGo.Models
{
    public class TotalWalkTime
    {
        public int WalkTimeTotal 
        {
            get
            {
                int totalTime = 0;
                foreach (Walk walk in _allWalks)
                {
                    totalTime += walk.Duration;
                }
                return totalTime;
            }
        }

        private List<Walk> _allWalks;

        public TotalWalkTime(List<Walk> walks) 
        {
            _allWalks = walks;
        }
   
    }
}
