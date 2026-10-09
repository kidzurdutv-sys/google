using System;
namespace AllInOneMEP.Core.Models
{
    public class SpaceModel
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public double Area { get; set; }
        public double CeilingHeight { get; set; }
        public double RequiredCFM { get; set; }
        public double RequiredLux { get; set; }
    }
}
