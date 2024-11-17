using System;
using System.Collections.Generic;

public interface IRemoteControlCar {
    int DistanceTravelled { get; }

    void Drive();
}

public class ProductionRemoteControlCar : IRemoteControlCar, IComparable<ProductionRemoteControlCar>
{
    public int DistanceTravelled { get; private set; }
    public int NumberOfVictories { get; set; }

    public int CompareTo(ProductionRemoteControlCar other)
    {
        return this.NumberOfVictories - other.NumberOfVictories;
    }

    public void Drive()
    {
        DistanceTravelled += 10;
    }
}

public class ExperimentalRemoteControlCar : IRemoteControlCar
{
    public int DistanceTravelled { get; private set; }

    public void Drive()
    {
        DistanceTravelled += 20;
    }
}

public static class TestTrack
{
    public static void Race(IRemoteControlCar car)
    {
        car.Drive();
    }

    public static List<ProductionRemoteControlCar> GetRankedCars(
        ProductionRemoteControlCar prc1,
        ProductionRemoteControlCar prc2
    ) {
        var response = new List<ProductionRemoteControlCar>();

        if (prc1.CompareTo(prc2) <= 0) {
            response.Add(prc1);
            response.Add(prc2);
        } else {
            response.Add(prc2);
            response.Add(prc1);
        }

        return response;
    }
}
