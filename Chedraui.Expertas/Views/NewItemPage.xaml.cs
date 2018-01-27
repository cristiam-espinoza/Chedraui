using System;

using Xamarin.Forms;

namespace Chedraui.Expertas
{
    public partial class NewItemPage : ContentPage
    {
        public EncuestaItem Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();

            Item = new EncuestaItem
            {
                Titulo = "Item name",
                Premio = "This is an item description."
            };

            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddItem", Item);
            await Navigation.PopToRootAsync();
        }
    }
}
