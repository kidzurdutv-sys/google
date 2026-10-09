using System.Collections.Generic;
using AllInOneMEP.Core.Models;

namespace AllInOneMEP.Core.Services.Interfaces
{
    /// <summary>
    /// The core engine for mechanical (HVAC) calculations and automation.
    /// </summary>
    public interface IMechanicalEngine
    {
        /// <summary>
        /// Calculates the required CFM for the given spaces.
        /// </summary>
        /// <param name="spaces">The spaces to perform calculation on.</param>
        void CalculateCFM(IEnumerable<SpaceModel> spaces);

        /// <summary>
        /// Automatically places air terminals (diffusers) into a given space based on calculated requirements.
        /// </summary>
        /// <param name="space">The target space.</param>
        void AutoPlaceDiffusers(SpaceModel space);

        /// <summary>
        /// Automatically routes ductwork according to pathfinding algorithms.
        /// </summary>
        void RouteDuctwork();
    }
}
