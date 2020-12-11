using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bowling_Game_Kata
{
    public class Game
    {       
        public CalculateScore CalculateScore { get; set; }
        IList<Frame> _frames = new List<Frame>();

        Frame lastFrame;
        public int TotalScore => _frames.Sum(_ => _.Score + _.BonusScore);

        public void PrintResult()
        {
            foreach(var frame in _frames)
            {
                Console.WriteLine($"Frame {frame.Id}, is spare: {frame.IsSpare}, is strike: {frame.IsStrike}, bonus score: {frame.BonusScore}, score: {frame.Score}, pins: {string.Join(", ", frame.PinsKnocked)}");
            }
        }

        bool IsGameEnd => lastFrame.Id == 10 && lastFrame.IsFrameCompleted;
        public Game()
        {
            CalculateScore = new CalculateScore(_frames);
            lastFrame = new Frame();
            _frames.Add(lastFrame);            
        }
        public void Roll(int pins)
        {
            if (IsGameEnd)
                return;
           
            if (lastFrame.IsFrameCompleted) 
            {
                _frames.Add(new Frame());
                lastFrame = _frames.Last();
            }
            lastFrame.PinsKnocked.Add(pins);
            CalculateScore.ScoreCalculation(lastFrame);
        }
    }
}
