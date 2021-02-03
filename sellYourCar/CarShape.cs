using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sellYourCar
{
    class CarShape
    {
        public int Id { get; set; }
        public System.DateTime yearOfProduction { get; set; }
        public int mileage { get; set; }
        public short capacity { get; set; }
        public short horsePower { get; set; }
        public byte numberOfDoors { get; set; }
        public byte numberOfSeats { get; set; }
        public decimal price { get; set; }
        public int brandID { get; set; }
        public int typeID { get; set; }
        public int fuelTypeID { get; set; }
        public int colorID { get; set; }
        public int countryID { get; set; }

        public string brand { get; set; }
        public string carType { get; set; }
        public string color { get; set; }
        public string country { get; set; }
        public string fuelType { get; set; }
    }
}
