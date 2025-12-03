using Microsoft.Maui.Controls;
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
        public override string GetDesc()
        {
            return "This is a Truck. They usually have more than four wheels, and usually carry a maximum of 2 people, 30 if counting the trailer, another 10 if counting the roof if you're really brave.";
        }
        public override string ToString()
        {
            return $"{Manufacturer} {Model} {ModelYear} - Lastbil";
        }
    }
}
