using Microsoft.Extensions.Hosting;
using MyCarParking.ParkContext;
using MyCarParking.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCarParking.Manager
{
    public class adminManager : IRepository<Admin>
    {
        public Admin GetUser(string username, string password) => ContextManager.GetContext().Admins.SingleOrDefault(entity => entity.Username == username && entity.Password == password);
    }
}
