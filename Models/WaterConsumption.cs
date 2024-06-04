using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WaterWatchMap.Models
{
    public class WaterConsumption
    {
        public int Id { get; set; } 
        public string Neighbourhood { get; set; }
        public int SuburbGroup { get; set; }
        public int AvarageMonthlyKL { get; set; }
        public string Coordinates { get; set; }
    }
}