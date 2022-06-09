using AppRestaurantCecar.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppRestaurantCecar.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login_Page : ContentPage
    {
        public Login_Page()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private async void Btn_Menu(object sender, EventArgs e)
        {

            HttpClient httpclient = new HttpClient();
            var verify = 0;

            var request = await httpclient.GetAsync("http://192.168.1.193/Api_restaurant/Customers/all_customers");

 

            if (request.IsSuccessStatusCode){

                //await DisplayAlert("Message", "Conection established", "OK");

                var msjson = request.Content.ReadAsStringAsync().Result;
                String json = (msjson);
                dynamic objjson = JsonConvert.DeserializeObject(json);
                List<Customer> customers = new List<Customer>();
                Customer customer = new Customer();

                foreach (var i in objjson)
                {
                    customer.Customer_id = i.Customer_id;
                    customer.Names = i.Names;
                    customer.Cellphone = i.Cellphone;
                    customer.Password = i.Password;
                    customer.Address = i.Address;

                    customers.Add(customer);
                    var aux = Convert.ToInt32(customer_id.Text);


                    if (customer.Customer_id == aux)
                    {
                        verify = 1;



                        foreach (var i2 in objjson)
                        {

                            if (i2.Password == password.Text)
                            {
                                //if (customer.Customer_id != 1)
                                //{
                                verify = 3;
                                Application.Current.MainPage = new NavigationPage(new Menu(customer));

                                //}
                                //else
                                //{
                                //Application.Current.MainPage = new NavigationPage(new Admin_Menu());
                                //}



                            }
                            else
                            {

                                verify = 0;
                            }
                        }

                        if (verify == 1)
                        {

                            await DisplayAlert("Error", "Incorrect Password", "OK");
                            
                        }

                        if (verify == 3)
                        {
                            break;
                        }


                    }
                    else
                    {
                        verify = 2;
                    }


                    //if (customer.Customer_id == 100)
                    //{

                    //    if (customer.Password == "admin")
                    //    {

                    //        Application.Current.MainPage = new NavigationPage(new Admin_Menu());
                    //    }
                    //}


                }

                if (verify != 3)
                {

                    await DisplayAlert("Error", "Customer Id or Password incorrects", "OK");
                }

            }
            
           
            //await Navigation.PushAsync(new Menu());
        }

        private void Btn_Admin(object sender, EventArgs e)
        {
            Application.Current.MainPage = new NavigationPage(new Admin_Menu());
        }
    }
}