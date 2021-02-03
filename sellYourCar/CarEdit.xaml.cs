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
        IQueryable<Brand> brands = from brand in db.Brands select brand;
        IQueryable<CarType> carTypes = from carType in db.CarTypes select carType;
        IQueryable<Country> countries = from country in db.Countries select country;
        IQueryable<Color> colors = from color in db.Colors select color;
        IQueryable<Fuel> fuels = from fuel in db.Fuels select fuel;
        int _carId;
        public CarEdit(int carId)
        {
            _carId = carId;
            InitializeComponent();
            foreach (var item in brands) comboBoxBrand.Items.Add(new KeyValuePair<int, string>(item.Id, item.name));
            foreach (var item in carTypes) comboBoxType.Items.Add(new KeyValuePair<int, string>(item.Id, item.name));
            foreach (var item in countries) comboBoxCountry.Items.Add(new KeyValuePair<int, string>(item.Id, item.name));
            foreach (var item in colors) comboBoxColor.Items.Add(new KeyValuePair<int, string>(item.Id, item.name));
            foreach (var item in fuels) comboBoxFuelType.Items.Add(new KeyValuePair<int, string>(item.Id, item.type));

            var updateCar = (from car in db.Cars where car.Id == _carId select car).Single();

            comboBoxBrand.SelectedItem = new KeyValuePair<int, string>(updateCar.brandID, updateCar.Brand.name);
            comboBoxColor.SelectedItem= new KeyValuePair<int, string>(updateCar.colorID, updateCar.Color.name);
            comboBoxCountry.SelectedItem=new KeyValuePair<int, string>(updateCar.countryID, updateCar.Country.name);
            comboBoxFuelType.SelectedItem=new KeyValuePair<int, string>(updateCar.fuelTypeID, updateCar.Fuel.type);
            comboBoxType.SelectedItem=new KeyValuePair<int, string>(updateCar.typeID, updateCar.CarType.name);
            textCapacity.Text = Convert.ToString(updateCar.capacity);
            textHorsePower.Text = Convert.ToString(updateCar.horsePower);
            textNumberOfSeats.Text = Convert.ToString(updateCar.numberOfSeats);
            textNumberOfDoors.Text = Convert.ToString(updateCar.numberOfDoors);
            textPrice.Text = Convert.ToString(updateCar.price);
            textMileage.Text = Convert.ToString(updateCar.mileage);
            textProductionDate.Text = Convert.ToString(updateCar.yearOfProduction);
        }

        private void onEditApply(object sender, RoutedEventArgs e)
        {
            var updateCar = (from car in db.Cars where car.Id == _carId select car).Single();
            updateCar.brandID = GetIdValue(comboBoxBrand.SelectedItem.ToString());
            updateCar.colorID = GetIdValue(comboBoxColor.SelectedItem.ToString());
            updateCar.countryID = GetIdValue(comboBoxCountry.SelectedItem.ToString());
            updateCar.fuelTypeID = GetIdValue(comboBoxFuelType.SelectedItem.ToString());
            updateCar.typeID = GetIdValue(comboBoxType.SelectedItem.ToString());
            updateCar.capacity = short.Parse(textCapacity.Text);
            updateCar.horsePower = short.Parse(textHorsePower.Text);
            updateCar.numberOfSeats = byte.Parse(textNumberOfSeats.Text);
            updateCar.numberOfDoors = byte.Parse(textNumberOfDoors.Text);
            updateCar.price = decimal.Parse(textPrice.Text);
            updateCar.mileage = int.Parse(textMileage.Text);
            updateCar.yearOfProduction = DateTime.Parse(textProductionDate.Text);

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

            car_table.datagrid.ItemsSource = result.ToList();
            this.Hide();
        }

        public static int GetIdValue(string value)
        {
            var clearValue = value.Replace(@"[", "").Replace(@"]", "");
            return Convert.ToInt32(clearValue.Split(',')[0]);
        }
    }
}
