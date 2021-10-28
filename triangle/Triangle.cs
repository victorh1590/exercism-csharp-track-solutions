using System;
using System.Linq;

public static class Triangle
{
    private static bool TriangleInequality(params double[] sides)
    {
        double largerSide = sides.Max();
        double sumOfSides = sides.Sum();
        return largerSide < (sumOfSides - largerSide);
    }
    
    public static bool IsScalene(double side1, double side2, double side3)
        => side1 != side2 &&
           side1 != side3 &&
           side2 != side3 &&
           TriangleInequality(side1, side2, side3);

    public static bool IsIsosceles(double side1, double side2, double side3)
        => (side1 == side2 || 
            side1 == side3 || 
            side2 == side3 ) && 
           TriangleInequality(side1, side2, side3);
    
    public static bool IsEquilateral(double side1, double side2, double side3)
        => side1 == side2 && 
           side1 == side3 && 
           side2 == side3 && 
           side1 != 0;
}