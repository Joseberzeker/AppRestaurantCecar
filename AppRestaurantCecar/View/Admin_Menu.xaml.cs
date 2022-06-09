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
    public partial class Admin_Menu : ContentPage
    {
        public Admin_Menu()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private void Btn_Back(object sender, EventArgs e)
        {
            Application.Current.MainPage = new NavigationPage(new Login_Page());

        }

        private void Btn_Customers(object sender, EventArgs e)
        {
            Application.Current.MainPage = new NavigationPage(new Customers_Page());
        }
    }
}