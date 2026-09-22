using System;
namespace AllInOneMEP.Core.Models
{
    public class EquipmentModel
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string EquipmentType { get; set; } = string.Empty;
        public double LocationX { get; set; }
        public double LocationY { get; set; }
        public double LocationZ { get; set; }
    }
}
