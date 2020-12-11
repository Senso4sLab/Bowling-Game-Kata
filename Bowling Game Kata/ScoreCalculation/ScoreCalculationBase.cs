
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bowling_Game_Kata.ScoreCalculation
{
    public abstract class ScoreCalculationBase
    {
        protected IList<Frame> _frames;
        protected Frame LastFrame { get; set; }
        protected Frame PreviousFrame => _frames.FirstOrDefault(fr => fr.Id == LastFrame.Id - 1);
        public ScoreCalculationBase(IList<Frame> frames)
        {
            _frames = frames;
        }
        public abstract bool IsMatch(Frame lastFrame);


        public virtual void ScoreStrikeSpare()
        {
            if (PreviousFrame.IsSpare)
                PreviousFrame.BonusScore = LastFrame.PinsKnocked.First();
            else if (PreviousFrame.IsStrike)
            {
                if (LastFrame.IsStrike)
                {
                    if (LastFrame.Id != 10)
                        PreviousFrame.BonusScore = LastFrame.PinsKnocked[0];
                    else
                        PreviousFrame.BonusScore = LastFrame.PinsKnocked[0] + LastFrame.PinsKnocked[1];
                }
                else
                    PreviousFrame.BonusScore = LastFrame.PinsKnocked.Sum();
            }

        }
        public abstract bool IsFrameCompleted();
        
        public virtual void UpdateScore(Frame lastFrame)
        {
            LastFrame = lastFrame;
            LastFrame.Score = LastFrame.PinsKnocked.Sum();
            LastFrame.IsFrameCompleted = IsFrameCompleted();

            if (LastFrame.IsFrameCompleted)
            {               
                if (PreviousFrame != null)                
                    ScoreStrikeSpare();               
            }
        }
    }

    public class ScoreCalculationNormal : ScoreCalculationBase
    {
        public ScoreCalculationNormal(IList<Frame> frames):base(frames)
        {
        }
        public override bool IsFrameCompleted()
        {
            if (LastFrame.PinsKnocked.Count == 2)
                return true;
            return false;
        }

        public override bool IsMatch(Frame lastFrame)
        {
            if (!lastFrame.IsSpare && !lastFrame.IsStrike)
                return true;
            return false;
        }

       
    }


    public class ScoreCalculationSparse : ScoreCalculationBase
    {
        public ScoreCalculationSparse(IList<Frame> frames):base(frames)
        {

        }
        public override bool IsFrameCompleted()
        {
            if (LastFrame.Id != 10)
                return true;
            else
              if (LastFrame.PinsKnocked.Count == 3)
                return true;

            return false;

        }      

        public override bool IsMatch(Frame lastFrame)
        {
            if (lastFrame.IsSpare)
                return true;
            else
                return false;
        }

      
    }

    public class ScoreCalculationStrike : ScoreCalculationBase
    {
        public ScoreCalculationStrike(IList<Frame> frames):base(frames)
        {

        }       
        public override bool IsFrameCompleted()
        {
            if (LastFrame.Id != 10)
                return true;
            else
            {
                if (LastFrame.PinsKnocked.Count == 3)
                    return true;
            }
            return false;            
        }       

        public override bool IsMatch(Frame lastFrame)
        {          

            if (lastFrame.IsStrike)
                return true;
            else
                return false;
        }

      
    }
}
