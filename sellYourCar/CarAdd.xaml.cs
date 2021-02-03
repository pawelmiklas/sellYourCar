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
    /// Interaction logic for CarAdd.xaml
    /// </summary>
    public partial class CarAdd : Window
    {
        static carsDBEntities db = new carsDBEntities();
        // get table values
        IQueryable<Brand> brands = from brand in db.Brands select brand;
        IQueryable<CarType> carTypes = from carType in db.CarTypes select carType;
        IQueryable<Country> countries = from country in db.Countries select country;
        IQueryable<Color> colors = from color in db.Colors select color;
        IQueryable<Fuel> fuels = from fuel in db.Fuels select fuel;
        public CarAdd()
        {
            InitializeComponent();
            // insert values to combobox
            foreach (var item in brands) comboBoxBrand.Items.Add(new KeyValuePair<int, string>(item.Id, item.name));
            foreach (var item in carTypes) comboBoxType.Items.Add(new KeyValuePair<int, string>(item.Id, item.name));
            foreach (var item in countries) comboBoxCountry.Items.Add(new KeyValuePair<int, string>(item.Id, item.name));
            foreach (var item in colors) comboBoxColor.Items.Add(new KeyValuePair<int, string>(item.Id, item.name));
            foreach (var item in fuels) comboBoxFuelType.Items.Add(new KeyValuePair<int, string>(item.Id, item.type));
        }

        private void onAdd(object sender, RoutedEventArgs e)
        {
            // connection with database
            carsDBEntities db = new carsDBEntities();
            Console.WriteLine(comboBoxType.SelectedItem);

            var fieldValues = new List<string>()
            {
                textCapacity.Text,
                textHorsePower.Text,
                textNumberOfSeats.Text,
                textNumberOfDoors.Text,
                textPrice.Text,
                textMileage.Text,
                textProductionDate.Text
            };

            var comboBoxValues = new List<ComboBox>()
            {
                comboBoxBrand,
                comboBoxColor,
                comboBoxCountry,
                comboBoxFuelType,
                comboBoxType,
            };

            // validate fields
            var isValid = fieldValues.All(item => item != "" && item != null) && comboBoxValues.All(item => item.SelectedItem != null);

            if (isValid)
            {
                // create car with values
                Car newCar = new Car()
                {
                    brandID = GetIdValueUtil.GetIdValue(comboBoxBrand.SelectedItem.ToString()),
                    colorID = GetIdValueUtil.GetIdValue(comboBoxColor.SelectedItem.ToString()),
                    countryID = GetIdValueUtil.GetIdValue(comboBoxCountry.SelectedItem.ToString()),
                    fuelTypeID = GetIdValueUtil.GetIdValue(comboBoxFuelType.SelectedItem.ToString()),
                    typeID = GetIdValueUtil.GetIdValue(comboBoxType.SelectedItem.ToString()),
                    capacity = short.Parse(textCapacity.Text),
                    horsePower = short.Parse(textHorsePower.Text),
                    numberOfSeats = byte.Parse(textNumberOfSeats.Text),
                    numberOfDoors = byte.Parse(textNumberOfDoors.Text),
                    price = decimal.Parse(textPrice.Text),
                    mileage = int.Parse(textMileage.Text),
                    yearOfProduction = DateTime.Parse(textProductionDate.Text),
                };

                // add car to database and save changes
                db.Cars.Add(newCar);
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

                // show latest car table data
                car_table.datagrid.ItemsSource = result.ToList();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Uzupełnij wszystkie pola", "Błąd walidacji", MessageBoxButton.OKCancel, MessageBoxImage.Error);
            }
        }
    }
}
