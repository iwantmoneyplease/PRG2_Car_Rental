using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRG_MAUI_Car_Register.Model
{
    class Truck : Vehicle
    {
        public Truck() : base(Type.Lastbil)
        {

        }

        public override string ToString()
        {
            return $"{Manufacturer} {Model} {ModelYear} - Lastbil";
        }
    }
}
