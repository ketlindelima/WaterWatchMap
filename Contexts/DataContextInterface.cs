using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WaterWatchMap.Models;

namespace WaterWatchMap.Contexts
{
    public interface DataContextInterface
    {
        DbSet<WaterConsumption> Consumptions {get; set;}

        int SaveChanges();
    }
}