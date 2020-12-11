using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bowling_Game_Kata
{
    public class Frame
    {
        static int counter = 0;
        public List<int> PinsKnocked { get; set; } = new List<int>();       
        public bool IsSpare
        {
            get
            {
                if(PinsKnocked.Count == 2)
                {
                    if (PinsKnocked.Sum() == 10)                    
                        return true;                    
                    else
                        return false;
                }
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
        public int Id { get; set; }
        public bool IsFrameCompleted { get; set; }    
        public int Score { get; set; }
        public int BonusScore { get; set; }

        public Frame()
        {
            counter++;
            Id = counter;
        }

    }
}
