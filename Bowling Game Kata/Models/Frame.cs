using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bowling_Game_Kata
{
    public class Frame
    {
        public List<int> PinsKnocked { get; set; }

        public Frame PreviousFrame { get; set; }

        public bool IsSpare
        {
            get
            {
                if (PinsKnocked.Count == 2 && PinsKnocked.Sum() == 10)
                    return true;
                return false;
            }
        }
        public bool IsStrike
        {
            get
            {
                if (PinsKnocked[0] == 10)
                    return true;
                else
                    return false;              
            }
        }

        public bool IsLastFrame { get; set; }
        

        
        public bool IsFrameCompleted { get; set; }    
        public int Score { get; set; }
        public int BonusScore { get; set; }

        public Frame()
        {
            PinsKnocked = new List<int>();
        }

    }
}
