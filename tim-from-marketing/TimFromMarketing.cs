using System;
using System.Linq;

static class Badge
{
    public static string Print(int? id, string name, string? department)
        => (id == null ? "" : $"[{id}] - ") +
           $"{name} - " +
           $"{department?.ToUpper() ?? "OWNER"}";
}
