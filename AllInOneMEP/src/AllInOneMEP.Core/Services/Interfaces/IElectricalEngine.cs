using System.Collections.Generic;
using AllInOneMEP.Core.Models;

namespace AllInOneMEP.Core.Services.Interfaces
{
    /// <summary>
    /// The core engine for electrical calculations and automation.
    /// </summary>
    public interface IElectricalEngine
    {
        /// <summary>
        /// Calculates the required Lux levels for a given set of spaces.
        /// </summary>
        /// <param name="spaces">The target spaces.</param>
        void CalculateLux(IEnumerable<SpaceModel> spaces);

        /// <summary>
        /// Automatically places lighting fixtures to meet the required Lux level.
        /// </summary>
        /// <param name="space">The target space.</param>
        void AutoPlaceLighting(SpaceModel space);

        /// <summary>
        /// Automatically routes cable trays.
        /// </summary>
        void RouteCableTrays();
    }
}
