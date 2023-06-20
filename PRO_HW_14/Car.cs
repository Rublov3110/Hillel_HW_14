using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRO_HW_14
{
    public class Car
    {
        public string Brand { get; set; }

        [DisplayName]
        public string Model { get; set; }

        [DisplayName]
        public string Year { get; set; }
        public string Color { get; set; }

    }
}
