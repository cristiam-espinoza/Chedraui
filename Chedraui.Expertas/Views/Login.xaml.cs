using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Chedraui.Expertas
{
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
        }


        async void Handle_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new Encuestas());
        }
    }
}
