using System;
namespace Bowling_Game_Kata.ScoreCalculation
{
    public class ScoreCalculationNormal : ScoreCalculationBase
    {

        public override bool IsFrameCompleted(Frame currentFrame)
        {

            if (currentFrame.PinsKnocked.Count == 2)
                currentFrame.IsFrameCompleted = true;
            else
                currentFrame.IsFrameCompleted = false;
           
            return currentFrame.IsFrameCompleted;

        }

        public override bool IsMatch(Frame lastFrame) => true;

    }
}
