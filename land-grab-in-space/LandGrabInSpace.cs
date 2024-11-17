using System;
using System.Collections.Generic;

public struct Coord
{
    public ushort X { get; }
    public ushort Y { get; }

    public Coord(ushort x, ushort y)
    {
        X = x;
        Y = y;
    }

    public static bool operator == (Coord a, Coord b)
    {
        return a.X == b.X && a.Y == b.Y;
    }

    public static bool operator != (Coord a, Coord b)
    {
        return a.X != b.X || a.Y != b.Y;
    }

    public static bool operator >= (Coord a, Coord b)
    {
        var maxX = Math.Max(a.X, b.X);
        var maxY = Math.Max(a.Y, b.Y);
        var max = Math.Max(maxX, maxY);

        if (a.X == max || a.Y == max) {
            return true;
        }

        return false;
    }

    public static bool operator <= (Coord a, Coord b)
    {
        return !(a >= b);
    }

    public override bool Equals(object obj)
    {
        if (obj is Coord that) {
            return this == that;
        }

        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(X, Y);
    }
}

public struct Plot
{
    public Coord coord1;
    public Coord coord2;
    public Coord coord3;
    public Coord coord4;

    public Plot(
        Coord coord1,
        Coord coord2,
        Coord coord3,
        Coord coord4
    ) {
        this.coord1 = coord1;
        this.coord2 = coord2;
        this.coord3 = coord3;
        this.coord4 = coord4;
    }

    public ushort LongestSide()
    {
        Coord response = coord1;

        if (coord2 >= response) {
            response = coord2;
        }

        if (coord3 >= response) {
            response = coord3;
        }

        if (coord4 >= response) {
            response = coord4;
        }

        return Math.Max(response.X, response.Y);
    }

    public override bool Equals(object obj)
    {
        if (obj is Plot that) {
            return
                this.coord1 == that.coord1 &&
                this.coord2 == that.coord2 &&
                this.coord3 == that.coord3 &&
                this.coord4 == that.coord4;
        }

        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(
            coord1,
            coord2,
            coord3,
            coord4
        );
    }
}

public class ClaimsHandler
{
    List<Plot> claimedStakes = new List<Plot>();

    public void StakeClaim(Plot plot)
    {
        if (IsClaimStaked(plot)) {
            return;
        }

        claimedStakes.Add(plot);
    }

    public bool IsClaimStaked(Plot plot)
    {
        return claimedStakes.Contains(plot);
    }

    public bool IsLastClaim(Plot plot)
    {
        if (claimedStakes.Count == 0) {
            return false;
        }

        var lastPos = claimedStakes.Count - 1;
        var lastItem = claimedStakes[lastPos];

        return plot.Equals(lastItem);
    }

    public Plot GetClaimWithLongestSide()
    {
        Plot response = claimedStakes[0];

        for (int i = 1; i < claimedStakes.Count; i++) {
            Plot plot = claimedStakes[i];

            if (plot.LongestSide() > response.LongestSide()) {
                response = plot;
            }
        }

        return response;
    }
}
