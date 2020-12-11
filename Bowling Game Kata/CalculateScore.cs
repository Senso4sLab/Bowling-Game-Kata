using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bowling_Game_Kata
{
    public class CalculateScore
    {
        IList<Frame> _frames;
        ScoreRuleEngine scoreRuleEngine;
        public CalculateScore(IList<Frame> frames)
        {
            _frames = frames;
            scoreRuleEngine = new ScoreRuleEngine(_frames);
        }
        public void ScoreCalculation(Frame lastFrame)
        {
            scoreRuleEngine.ApplyRules(lastFrame);                           
        }
    }
}
