using MyCarParking.ParkContext;
using MyCarParking.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCarParking.Manager
{
    public class parkManager:IRepository<Carpark>
    {
        static int count = 0;
        myparkingContext context = ContextManager.GetContext();

        public static int AddCount() => count = count + 1;

        public static int ShowCount() => count;
        
        public static int DeleteCount() => count = count - 1;
        
        public List<Carpark> PlakaSorgulama(string harf) => context.Carparks.Where(entity => entity.Carplate.Contains(harf)).ToList();

        
        public Carpark Aracbilgisinigetir(string Carplate) => context.Carparks.SingleOrDefault(entity => entity.Carplate == Carplate+"");
        
    }
}
