using System;
using MVVM.Model;
namespace MVVM.ViewModel
{
    internal sealed class ChangeScore : IChangeScore
    {
        public event Action<bool> onChangeScore;
        public IScore GetScore { get; }
        public ChangeScore(IScore score)
        {
            GetScore = score;
        }
        public void AddScore(float score)
        {
            GetScore.CurrentScore += score;
            onChangeScore?.Invoke(true);
        }
    }
}
