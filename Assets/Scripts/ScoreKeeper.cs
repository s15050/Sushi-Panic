using System.Collections;
using System.Collections.Generic;

public class ScoreKeeper
{
    private static int score = 0;

    public static void setScore(int a)
    {
        score = a;
    }

    public static int getScore()
    {
        return score;
    }
    
}
