using AppRestaurantCecar.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppRestaurantCecar.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Crud_Customers_Page : ContentPage
    {
        private Food selected;
        private Food food;

        public Crud_Customers_Page(Customer selected, Customer customer)
        {
            InitializeComponent();
            customer_id.Text = customer.Customer_id.ToString();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        public Crud_Customers_Page(Food selected, Food food)
        {
            this.selected = selected;
            this.food = food;
        }

        private void Btn_Actualizar(object sender, EventArgs e)
        {

        }

        private void Btn_Eliminar(object sender, EventArgs e)
        {

        }
    }
}