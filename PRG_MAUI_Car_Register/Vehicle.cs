namespace PRG_MAUI_Car_Register
{
    abstract class Vehicle
    {
        // Medlemsvariabler
        public enum Type { Bil, MC, Lastbil };
        private Type vehicleType;
        private string registrationNumber = string.Empty;
        private string manufacturer = string.Empty;
        private string model = string.Empty;
        private int modelYear = 0;

        // Konstruktor (en metod med samma namn som klassen, som returnerar ett objekt)
        public Vehicle(Type vehicleType) // en konstruktor kan, men måste inte, ta parametrar
        {
            this.vehicleType = vehicleType;
        }

        // Get-Set för att hålla variablerna privata, och för att validera inkommande värden från UI (user interface, användargränssnittet)
        public string RegistrationNumber
        {
            get { return registrationNumber; }

            set
            {
                if (value.Length == 6)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        if (!char.IsLetter(value[i]))
                            throw new ArgumentException("Inkorrekt registreringsnummer: De första tre tecknen måste vara bokstäver.");
                    }

                    for (int i = 3; i < 6; i++)
                    {
                        if (i < 5)
                        {
                            if (!char.IsDigit(value[i]))
                                throw new ArgumentException("Inkorrekt registreringsnummer: Det fjärde och femte tecknet måste vara siffror.");
                        }
                        else
                        {
                            if (!char.IsDigit(value[i]) && !char.IsLetter(value[i]))
                                throw new ArgumentException("Inkorrekt registreringsnummer: Det sjätte tecknet måste vara en siffra eller en bokstav.");
                        }
                    }
                }
                else
                {
                    throw new ArgumentException("Ett registreringsnummer måste bestå av exakt 6 tecken, med tre bokstäver följt av två siffror och en siffra eller bokstav.");
                }

                registrationNumber = value.ToUpper();
            }
        }

        // Fordonstyp tas in från dropdown-menyn, och behöver därför inte valideras
        public Type VehicleType
        {
            get { return vehicleType; }
            set { this.vehicleType = value; }
        }

        //TODO Tillverkare ska valideras, sparas i objektet och visas i UI
        public string Model
        {
            get { return model; }
            set 
            { 

                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Fältet model kan ej vara tomt");

                }

                foreach (char c in value)
                {
                    if (!char.IsLetter(c) && !char.IsDigit(c) && c != ' ' && c != '-') { }
                        throw new ArgumentException("Enbart alfabetet, siffror, mellanrum, och - är tillåtna");
                }

            }
        }

        public string ModelYear
        {
            get { return modelYear.ToString(); }
            set
            {
                if (int.TryParse(value, out int year))
                {
                    if (year >= 1895 && year <= DateTime.Now.Year)
                    {
                        modelYear = year;
                    }
                    else
                    {
                        throw new ArgumentException("Året måste vara riktigt");
                    }
                }
                else
                {
                    throw new ArgumentException("Årfältet kan enbart ha siffror");
                }
            }
        }

        //TODO Modell ska valideras, sparas i objektet och visas i UI
        public string Manufacturer
        {
            get { return manufacturer; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Fältet tillverkare kan ej vara tomt");
                }

                foreach (char c in value)
                {
                    if (!char.IsLetter(c) && c != ' ' && c != '-')
                        throw new ArgumentException("Enbart alfabetet, mellanrum, och - är tillåtna");
                }

                this.manufacturer = value;
            }
        }

        public override string ToString()
        {
            return this.registrationNumber + "\t" + this.vehicleType + "\t" + this.manufacturer + "\t" + this.model + "\t" + this.modelYear;
        }
    }

    class Car : Vehicle
    {
        public Car() : base(Type.Bil)
        {

        }
    }

    class Motorcycle : Vehicle
    {
        public Motorcycle() : base(Type.MC)
        {

        }
    }

    class Truck : Vehicle
    {
        public Truck() : base(Type.Lastbil)
        {

        }
    }
}
