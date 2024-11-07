using System;

class BirdCount
{
    private int[] birdsPerDay;

    public BirdCount(int[] birdsPerDay)
    {
        this.birdsPerDay = birdsPerDay;
    }

    public static int[] LastWeek()
    {
        int[] response = {0, 2, 5, 3, 7, 8, 4};

        return response;
    }

    public int Today()
    {
        return birdsPerDay[birdsPerDay.Length - 1];
    }

    public void IncrementTodaysCount()
    {
        var position = birdsPerDay.Length - 1; 
        birdsPerDay[position] += 1;
    }

    public bool HasDayWithoutBirds()
    {
        foreach (var value in birdsPerDay) {
            if (value == 0) {
                return true;
            }
        }

        return false;
    }

    public int CountForFirstDays(int numberOfDays)
    {
        int response = 0;
        for (int i = 0; i < numberOfDays; i++) {
            response += birdsPerDay[i];
        }

        return response;
    }

    public int BusyDays()
    {
        int response = 0;
        foreach (var value in birdsPerDay) {
            if (value >= 5) {
                response++;
            }
        }

        return response;
    }
}
