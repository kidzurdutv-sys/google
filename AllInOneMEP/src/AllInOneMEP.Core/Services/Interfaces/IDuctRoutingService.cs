using System;
using AllInOneMEP.Core.Models;

namespace AllInOneMEP.Core.Services.Interfaces
{
    /// <summary>
    /// Service for routing ducts using pathfinding algorithms.
    /// </summary>
    public interface IDuctRoutingService
    {
        /// <summary>
        /// Routes a duct between two 3D points.
        /// </summary>
        /// <param name="startPoint">The starting point coordinates.</param>
        /// <param name="endPoint">The ending point coordinates.</param>
        /// <returns>A configured DuctModel.</returns>
        DuctModel RouteDuct(Tuple<double, double, double> startPoint, Tuple<double, double, double> endPoint);
    }
}
