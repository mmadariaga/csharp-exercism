using System;

public class Player
{
    public int RollDie()
    {
        var rand = new Random();

        return rand.Next(1, 18);
    }

    public double GenerateSpellStrength()
    {
        var rand = new Random();

        return (rand.Next(0, 999)) / 10d;
    }
}
