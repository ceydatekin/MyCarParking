using System;
using System.Collections.Generic;

#nullable disable

namespace MyCarParking.ParkContext
{
    public partial class Tenant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Plate { get; set; }
    }
}
