using System.Collections.Generic;
using AllInOneMEP.Core.Models;
using AllInOneMEP.Core.Services.Interfaces;
namespace AllInOneMEP.Core.Services.Mechanical
{
    public class MechanicalEngine : IMechanicalEngine
    {
        public void CalculateCFM(IEnumerable<SpaceModel> spaces) { foreach (var space in spaces) space.RequiredCFM = space.Area * space.CeilingHeight * 0.1; }
        public void AutoPlaceDiffusers(SpaceModel space) { }
        public void RouteDuctwork() { }
    }
}
