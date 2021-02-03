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
    /// Interaction logic for CarEdit.xaml
    /// </summary>
    public partial class CarEdit : Window
    {
        static carsDBEntities db = new carsDBEntities();
        int _carId;
        public CarEdit(int carId)
        {
            _carId = carId;
            InitializeComponent();
        }

        private void onEditApply(object sender, RoutedEventArgs e)
        {
            //var updateCar = (from car in db.Cars where car.Id == _carId select car).Single();
            //updateCar.brandID = GetIdValue(comboBoxBrand.SelectedItem.ToString());
            //updateCar.colorID = GetIdValue(comboBoxColor.SelectedItem.ToString());
            //updateCar.countryID = GetIdValue(comboBoxCountry.SelectedItem.ToString());
            //updateCar.fuelTypeID = GetIdValue(comboBoxFuelType.SelectedItem.ToString());
            //updateCar.typeID = GetIdValue(comboBoxType.SelectedItem.ToString());
            //updateCar.capacity = short.Parse(textCapacity.Text);
            //updateCar.horsePower = short.Parse(textHorsePower.Text);
            //updateCar.numberOfSeats = byte.Parse(textNumberOfSeats.Text);
            //updateCar.numberOfDoors = byte.Parse(textNumberOfDoors.Text);
            //updateCar.price = decimal.Parse(textPrice.Text);
            //updateCar.mileage = int.Parse(textMileage.Text);
            //updateCar.yearOfProduction = DateTime.Parse(textProductionDate.Text);

            //db.SaveChanges();

            //var result = from item in db.Cars
            //             select new CarShape
            //             {
            //                 Id = item.Id,
            //                 brand = item.Brand.name,
            //                 carType = item.CarType.name,
            //                 fuelType = item.Fuel.type,
            //                 yearOfProduction = item.yearOfProduction,
            //                 mileage = item.mileage,
            //                 capacity = item.capacity,
            //                 horsePower = item.horsePower,
            //                 numberOfDoors = item.numberOfDoors,
            //                 numberOfSeats = item.numberOfSeats,
            //                 color = item.Color.name,
            //                 country = item.Country.name,
            //                 price = item.price,
            //             };

            //car_table.datagrid.ItemsSource = result.ToList();
            //this.Hide();
        }

        //public static int GetIdValue(string value)
        //{
        //    var clearValue = value.Replace(@"[", "").Replace(@"]", "");
        //    return Convert.ToInt32(clearValue.Split(',')[0]);
        //}
    }
}
