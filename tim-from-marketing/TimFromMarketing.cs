using System;
using System.Linq;

static class Badge
{
    public static string Print(int? id, string name, string? department)
        => $"{ new string( id == null ? "" : $"[{id}] - " ) }" +
           $"{name} - " +
           $"{department?.ToUpper() ?? "OWNER"}";
}
