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
        // connection with database
        carsDBEntities db = new carsDBEntities();
        public static DataGrid datagrid;
        public car_table()
        {
            InitializeComponent();
            // map data to shape
            var result = from item in db.Cars
                         select new CarShape
                         {
                             Id = item.Id,
                             brand = item.Brand.name,
                             carType = item.CarType.name,
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
            myDataGrid.ItemsSource = result.ToList();
            datagrid = myDataGrid;
        }

        private void insertClick(object sender, RoutedEventArgs e)
        {
            CarAdd insertPage = new CarAdd();
            insertPage.ShowDialog();
        }

        private void onDelete(object sender, RoutedEventArgs e)
        {
                var sItem = myDataGrid.SelectedItem as CarShape;

                if (sItem != null)
                {
                    var deletedCar = db.Cars.Where(item => item.Id == sItem.Id).Single();
                    db.Cars.Remove(deletedCar);
                    db.SaveChanges();

                    var result = from item in db.Cars
                                 select new CarShape
                                 {
                                     Id = item.Id,
                                     brand = item.Brand.name,
                                     carType = item.CarType.name,
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

                    myDataGrid.ItemsSource = result.ToList();
                }
        }
    }
}
