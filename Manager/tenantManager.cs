using MyCarParking.ParkContext;
using MyCarParking.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCarParking.Manager
{
    public class tenantManager:IRepository<Tenant>
    {
        myparkingContext context = ContextManager.GetContext();
        public Tenant Kullanicigisinigetir(string plate) => context.Tenants.SingleOrDefault(entity => entity.Plate == plate + "");

    }
}
