using System.Collections;
using System.Collections.Generic;

public class ScoreKeeper
{
    private static int score = 0;
    private static int speedUpScore = 0;
    private static int bound = 100;
    private static bool secondOrLater = false;
    private static bool canSpeedNow = true;

    public static void setBound(int a)
    {
        bound = a;
    }

    public static void setScore(int a)
    {
        score += a;
        speedUpScore += a;
        canSpeedNow = true;
        if (speedUpScore >= bound)
        {
            speedUpScore = 0;
            secondOrLater = true;
        }
    }

    public static bool ShouldSpeedUp()
    {
        if ((speedUpScore < 10) && (secondOrLater) && (canSpeedNow))
        {
            canSpeedNow = false;
            return true;
        }
        else
            return false;
    }

    public static int getScore()
    {
        return score;
    }
    
}
