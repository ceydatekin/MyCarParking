using System;
using System.Collections.Generic;

#nullable disable

namespace MyCarParking.ParkContext
{
    public partial class Admin
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
    }
}
