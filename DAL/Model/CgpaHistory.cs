using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class CgpaHistory : IEntity
    {
        public string? StudentName { get; set; }
        public double Cgpa { get; set; }     
    }
}
