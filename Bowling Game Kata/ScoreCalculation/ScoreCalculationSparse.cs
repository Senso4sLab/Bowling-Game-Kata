using System;
namespace Bowling_Game_Kata.ScoreCalculation
{
    public class ScoreCalculationSparse : ScoreCalculationBase
    {

        public override bool IsMatch(Frame currentFrame)
        {
            if (currentFrame.IsSpare)
                return true;
            else
                return false;
        }

        public override bool IsFrameCompleted(Frame currentFrame)
        {
            if (!currentFrame.IsLastFrame)
            {
                currentFrame.IsFrameCompleted = true;
            }
            else
            {
                if (currentFrame.PinsKnocked.Count == 3)
                    currentFrame.IsFrameCompleted = true;
                else
                    currentFrame.IsFrameCompleted = false;
            }

            return currentFrame.IsFrameCompleted;
        }

    }
}
