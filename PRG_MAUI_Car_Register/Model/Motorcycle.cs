using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRG_MAUI_Car_Register.Model
{
    class Motorcycle : Vehicle
    {
        public Motorcycle() : base(Type.MC)
        {

        }
        public override string GetDesc()
        {
            return "This is a motorcycle. Sewilius seems like the type to own one.";
        }

        public override string ToString()
        {
            return $"{RegistrationNumber} {Manufacturer} {Model} {ModelYear} - MC";
        }
    }
}
