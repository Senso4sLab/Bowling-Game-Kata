using System;
namespace Bowling_Game_Kata.ScoreCalculation
{
    public class ScoreCalculationStrike : ScoreCalculationBase
    {

        public override bool IsMatch(Frame currentFrame)
        {
            if (currentFrame.IsStrike)
                return true;
            else
                return false;
        }

        public override bool IsFrameCompleted(Frame currentFrame)
        {
            if (!currentFrame.IsLastFrame)
                currentFrame.IsFrameCompleted = true;
            else
            {
                if (currentFrame.PinsKnocked.Count == 3)
                    currentFrame.IsFrameCompleted = true;
                else
                    currentFrame.IsFrameCompleted = false;
            }

            return currentFrame.IsFrameCompleted;
        }



        public override void BonusScorePreviousFrame(Frame currentFrame)
        {
            Frame previousFrame = currentFrame.PreviousFrame;

            if (previousFrame == null)
                return;

            if (previousFrame.IsSpare)
            {
                previousFrame.BonusScore = 10;
            }
            else if (previousFrame.IsStrike)
            {
                previousFrame.BonusScore = 10;

                if (currentFrame.IsLastFrame)
                    previousFrame.BonusScore += currentFrame.PinsKnocked[1];

                if (previousFrame.PreviousFrame.IsStrike)
                    previousFrame.PreviousFrame.BonusScore += 10;
            }
        }
    }
}
