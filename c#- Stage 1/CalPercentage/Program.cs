class Program
{
    public int GetOverAllScore(int[] cards)
    {
        return 0;
    }

    public string GenerateScoreCard(int[] cards)
    {
        return "";
    }
}

public enum AssessmentType
{
    Quiz=50,
    KBA=100,
    Calibration=150,
    Hackathon=200
}

public struct AssessmentCard
{
    public int score;
    public AssessmentType type;
    public string date;
}