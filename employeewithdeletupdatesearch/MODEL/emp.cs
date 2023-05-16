using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace employeewithdeletupdatesearch.MODEL
{
     public class emp
    {
        public String Name{ get; set; }
        public int Id { get; set; }
        public Single salary { get; set; }

        public override string ToString()
        {
            return string.Format($"Name={Name}\tSalary={salary}");
        }
    }
}
