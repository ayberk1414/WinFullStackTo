using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFullStackTo.Entities
{
      public class AppUser
    {
        public int Id { get; set; } 
        public string? UserName { get; set; }
        public string? Password { get; set; }
    }
}
