using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Chedraui.Expertas
{
    public class CuestionarioViewModel : BaseViewModel
    {
        public ObservableCollection<EncuestaItem> Items { get; set; }
        public Command LoadItemsCommand { get; set; }

        public CuestionarioViewModel()
        {
            Title = "Cuestionario";
            Items = new ObservableCollection<EncuestaItem>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<NewItemPage, EncuestaItem>(this, "AddItem", async (obj, item) =>
            {
                var _item = item as EncuestaItem;
                Items.Add(_item);
                await DataStore.AddItemAsync(_item);
            });
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
