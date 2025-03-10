using DataAccesLayer.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Initializer
{
    public class Initializer(CrowdfundingDbContext ctx)
    {
        public static void InitializeDb(CrowdfundingDbContext ctx)
        {
            ctx.Database.EnsureCreated();
        }
    }
}
