using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRG_MAUI_Car_Register.Model
{
    class Car : Vehicle
    {
        public Car() : base(Type.Bil)
        {

        }
        public override string GetDesc()
        {
            return "This is a car. They have four wheels, and usually carry a maximum of five people";
        }
        public override string ToString()
        {
            return $"{Manufacturer} {Model} {ModelYear} - Bil";
        }
    }
}
