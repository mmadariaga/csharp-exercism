using System;

class WeighingMachine
{
    public int Precision { get; }

    private double weight;

    public double Weight {
        get { return weight; }
        set {
            if (value < 0) {
                throw new ArgumentOutOfRangeException();
            }
            weight = value; 
        }
    }

    public string DisplayWeight {
        get {
            string value = (Weight - TareAdjustment).ToString($"F{Precision}");
            return $"{value} kg";
        }
    }

    public double TareAdjustment {set; get; } = 5;

    public WeighingMachine(
        int precision
    ) {
        this.Precision = precision;
    }
}
