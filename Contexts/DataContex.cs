using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WaterWatchMap.Models;

namespace WaterWatchMap.Contexts
{
    public class DataContex : DbContext, DataContextInterface
    {
        public DataContex(DbContextOptions<DataContex> options) : base(options)
        {

        }
        public DbSet<WaterConsumption> Consumptions {get; set;}
    }
}