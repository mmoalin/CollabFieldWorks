using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace FieldWorksApp
{
    public partial class MainPage : ContentPage
    {
        private async void LoginClick(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MediaPage());
        }
        public MainPage()
        {
            InitializeComponent();
            Picker pickUniNames = new Picker
            {
                Title = "Please Select University:",
            };
            Entry inboxName = new Entry
            {
                Placeholder = "UserName:"
            };
            Entry inboxPassword = new Entry
            {
                Placeholder = "Password:",
                IsPassword = true
            };
            Button btnLogin = new Button
            {
                IsVisible = false,
                Text = "Login"

            };
            btnLogin.Clicked += LoginClick;
            foreach (string uniName in nameToUni.Keys)
            {
                pickUniNames.Items.Add(uniName);
            }
            pickUniNames.SelectedIndexChanged += (sender, args) =>
            {
                btnLogin.IsVisible = true;
            };
            this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);
            this.Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Children =
                {
                    pickUniNames,
                    inboxName,
                    inboxPassword,
                    btnLogin
                }
            };
        }

        Dictionary<string, int> nameToUni = new Dictionary<string, int>
        {
            { "Hull University", 1 }, { "Brighton University", 2 },
            { "Southampton University", 3 }, { "University of Oxford", 4},
            { "Southampton Solent University", 5 }, { "University of Cambridge", 6 },
            { "Open University", 7}, { "Imperial College London", 8 },
            { "University College London", 9 }, { "University of Edinburgh", 10 },
            { "King’s College London", 11 }, { "University of Manchester", 12 },
            { "University of Bristol", 13 }, { "University of Warwick", 14 },
            { "University of Glasgow", 15 }, { "Durham University", 16 }
        };

    }
}
