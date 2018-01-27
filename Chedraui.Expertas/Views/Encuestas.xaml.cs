using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace Chedraui.Expertas
{
    public partial class Encuestas : ContentPage
    {
        EncuestaViewModel viewModel;
        public Encuestas()
        {
            InitializeComponent();

            BindingContext = viewModel = new EncuestaViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as EncuestaItem;
            if (item == null)
                return;

            await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));

            EncuestasListView.SelectedItem = null;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Encuestas.Count() == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
    }
}
