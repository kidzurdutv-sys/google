using System;
using System.Collections.Generic;
namespace AllInOneMEP.Core.Models
{
    public class DuctModel
    {
        public string Id { get; set; } = string.Empty;
        public string SystemType { get; set; } = string.Empty;
        public List<Tuple<double, double, double>> RoutingPoints { get; set; } = new List<Tuple<double, double, double>>();
    }
}
