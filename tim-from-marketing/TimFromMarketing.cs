using System;
using System.Collections.Generic;

static class Badge
{
    public static string Print(int? id, string name, string? department)
    {
        string response = "";

        if (id != null) {
            response = $"[{id}] - ";
        }
        response += $"{name} - ";
        response += department?.ToUpper() ?? "OWNER";

        return response;
    }
}
