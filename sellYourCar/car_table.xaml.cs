using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace sellYourCar
{
    /// <summary>
    /// Interaction logic for car_table.xaml
    /// </summary>
    public partial class car_table : Window
    {
        public car_table()
        {
            InitializeComponent();
            // connection with database
            carsDBEntities db = new carsDBEntities();
            // map data to shape
            var result = from item in db.Cars
                    select new 
                    {
                        Marka = item.Brand.name,
                        Typ = item.CarType.name,
                        RodzajPaliwa = item.Fuel.type,
                        RokProdukcji = item.yearOfProduction,
                        Przebieg = item.mileage,
                        PojemnoscSkokowa = item.capacity,
                        Moc = item.horsePower,
                        LiczbaDrzwi = item.numberOfDoors,
                        LiczbaMiejsc = item.numberOfSeats,
                        Kolor = item.Color.name,
                        KrajPochodzenia = item.Country.name
                    };

            // insert data to table
            this.carsList.ItemsSource = result.ToList();
        }
    }
}
