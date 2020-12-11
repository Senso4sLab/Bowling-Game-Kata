using Bowling_Game_Kata.ScoreCalculation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bowling_Game_Kata
{
    public class ScoreRuleEngine
    {
        private List<ScoreCalculationBase> _rules = new List<ScoreCalculationBase>();
        private IList<Frame> _frames;
        public ScoreRuleEngine(IList<Frame> frames)
        {
            _frames = frames;
            _rules.Add(new ScoreCalculationNormal(_frames));
            _rules.Add(new ScoreCalculationSparse(_frames));
            _rules.Add(new ScoreCalculationStrike(_frames));
        }

        public void ApplyRules(Frame lastFrame)
        {
            foreach(var rule in _rules)
            {
                if (rule.IsMatch(lastFrame))
                {
                    rule.UpdateScore(lastFrame);
                    ScoreSequenceStrikes(lastFrame);
                    return;
                }                    
            }          
        }

        public void ScoreSequenceStrikes(Frame lastFrame)
        {
            if (lastFrame.IsFrameCompleted && _frames.TakeLast(3).Take(2).All(frame => frame.IsStrike))
            {
                var olderFrame = _frames.FirstOrDefault(frame => frame.Id == lastFrame.Id - 2);
                olderFrame.BonusScore += lastFrame.PinsKnocked[0];
            }
        }
    }
}
