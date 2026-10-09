using System;
namespace AllInOneMEP.Core.Utilities
{
    public static class GeometryHelpers
    {
        public static double CalculateDistance(Tuple<double, double, double> p1, Tuple<double, double, double> p2) => Math.Sqrt(Math.Pow(p2.Item1 - p1.Item1, 2) + Math.Pow(p2.Item2 - p1.Item2, 2) + Math.Pow(p2.Item3 - p1.Item3, 2));
    }
}
