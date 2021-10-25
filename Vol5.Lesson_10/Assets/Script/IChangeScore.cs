using System;
using MVVM.Model;
namespace MVVM.ViewModel
{
    internal interface IChangeScore
    {
        IScore GetScore { get; }
        void AddScore(float score);
        event Action<bool> onChangeScore;
    }
}
