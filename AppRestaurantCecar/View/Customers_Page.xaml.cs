using AppRestaurantCecar.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppRestaurantCecar.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Customers_Page : ContentPage
    {

        public string url = "http://192.168.1.193/Api_restaurant/Customers/all_customers";
        HttpClient customers = new HttpClient();

        private List<Customer> ListaCustomers = new List<Customer>();
        Customer customer = new Customer();

        public Customers_Page()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }


        protected override async void OnAppearing()
        {
            try
            {
                base.OnAppearing();
                string content = await customers.GetStringAsync(url);

                List<Customer> list = JsonConvert.DeserializeObject<List<Customer>>(content);
                CustomerList.ItemsSource = new ObservableCollection<Customer>(list);
                ListaCustomers = list;
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Aquí está el error en onAppearing" + ex);
            }
        }


        private void TextChanged(object sender, TextChangedEventArgs e)
        {
            var keyword = "";
            if (SearchBar.Text.Length == 2)
            {
                keyword = SearchBar.Text.ToLower();
            }
            keyword = SearchBar.Text;
            CustomerList.ItemsSource =
                ListaCustomers.Where(name => name.Names.ToLower().Contains(keyword));
        }

        private void CustomerList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Customer selected = e.SelectedItem as Customer;
            if (e.SelectedItem != null)
            {
                var id_customer = Convert.ToInt32(selected.Customer_id);


                Customer customer = new Customer
                {
                    Customer_id = id_customer,

                };
                Application.Current.MainPage = new NavigationPage(new Crud_Customers_Page(selected, customer));

            }

        }
        private void Btn_Regresar(object sender, EventArgs e)
        {
            Application.Current.MainPage = new NavigationPage(new Admin_Menu());
        }
    }
}