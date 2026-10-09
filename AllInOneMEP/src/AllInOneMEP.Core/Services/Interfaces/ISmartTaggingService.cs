using System.Collections.Generic;

namespace AllInOneMEP.Core.Services.Interfaces
{
    /// <summary>
    /// Service for automatically tagging elements while avoiding collisions.
    /// </summary>
    public interface ISmartTaggingService
    {
        /// <summary>
        /// Tags the given elements in the active view, ensuring tags don't overlap.
        /// </summary>
        /// <param name="elementIds">A list of element IDs to tag.</param>
        void TagElementsCollisionFree(IEnumerable<string> elementIds);
    }
}
