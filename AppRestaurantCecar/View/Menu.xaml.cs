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
    public partial class Menu : ContentPage
    {
        public string url = "http://192.168.1.193/Api_restaurant/Foods/all_foods";
        HttpClient foods = new HttpClient();

        private List<Food> ListaFoods = new List<Food>();
        Food food = new Food();
        private Customer customer;

        public Menu(Customer customer)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        protected override async void OnAppearing()
        {
            try
            {
                base.OnAppearing();
                string content = await foods.GetStringAsync(url);

                List<Food> list = JsonConvert.DeserializeObject<List<Food>>(content);
                FoodList.ItemsSource = new ObservableCollection<Food>(list);
                ListaFoods = list;

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
            FoodList.ItemsSource =
                ListaFoods.Where(name => name.Name.ToLower().Contains(keyword));
        }


        private void FoodList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Food selected = e.SelectedItem as Food;
            if (e.SelectedItem != null)
            {
                var food_id = Convert.ToInt32(selected.Food_id);


                Food food= new Food
                {
                    Food_id = food_id,

                };
                //Application.Current.MainPage = new NavigationPage(new Crud_Customers_Page(selected, food));

            }

        }

        private void Btn_Regresar(object sender, EventArgs e)
        {
            Application.Current.MainPage = new NavigationPage(new Login_Page());
        }

        private void Btn_Historial(object sender, EventArgs e)
        {

        }
    }


}