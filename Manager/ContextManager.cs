using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyCarParking.ParkContext;

namespace MyCarParking.Manager
{
    public class ContextManager
    {
        private static myparkingContext context;
        private ContextManager()
        {

        }
        public static myparkingContext GetContext()
        {
            if (context == null)
                context = new myparkingContext();

            return context;
        }
    }
}
