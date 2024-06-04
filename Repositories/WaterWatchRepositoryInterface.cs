using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WaterWatchMap.Models;

namespace WaterWatchMap.Repositories
{
    public interface WaterWatchRepositoryInterface
    {
        Task<IEnumerable<WaterConsumption>> GetAll();
        Task<IEnumerable<WaterConsumption>> GetTopTenConsumers();
    }
}