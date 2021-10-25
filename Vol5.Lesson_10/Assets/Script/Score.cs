namespace MVVM.Model
{
    internal sealed class Score : IScore
    {
        public float MaxScore { get; }
        public float CurrentScore { get; set; }
        public Score(float maxScore)
        {
            MaxScore = maxScore;
            CurrentScore = MaxScore;
        }
    }
}
