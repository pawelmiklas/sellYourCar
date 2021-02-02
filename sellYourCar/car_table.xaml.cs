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
                        brand = item.Brand.name,
                        type = item.CarType.name,
                        fuelType = item.Fuel.type,
                        yearOfProduction = item.yearOfProduction,
                        mileage = item.mileage,
                        capacity = item.capacity,
                        horsePower = item.horsePower,
                        numberOfDoors = item.numberOfDoors,
                        numberOfSeats = item.numberOfSeats,
                        color = item.Color.name,
                        country = item.Country.name,
                        price = item.price,
                    };

            // insert data to table
            this.myDataGrid.ItemsSource = result.ToList();
        }

        private void insertClick(object sender, RoutedEventArgs e)
        {
            CarAdd insertPage = new CarAdd();
            insertPage.ShowDialog();
        }
    }
}
