using System.Collections.Generic;
using AllInOneMEP.Core.Models;
using AllInOneMEP.Core.Services.Interfaces;
namespace AllInOneMEP.Core.Services.Electrical
{
    public class ElectricalEngine : IElectricalEngine
    {
        public void CalculateLux(IEnumerable<SpaceModel> spaces) { foreach (var space in spaces) space.RequiredLux = space.Area * 1.5; }
        public void AutoPlaceLighting(SpaceModel space) { }
        public void RouteCableTrays() { }
    }
}
