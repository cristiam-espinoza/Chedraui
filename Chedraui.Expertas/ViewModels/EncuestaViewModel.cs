using System; using System.Collections.ObjectModel; using System.Diagnostics; using System.Threading.Tasks;  using Xamarin.Forms;

namespace Chedraui.Expertas
{
    public class EncuestaViewModel : BaseViewModel
    {
        public string NombreExperta { get; set; }
        public string Nivel { get; set; }
        public ObservableCollection<EncuestaItem> Encuestas { get; set; }
        public Command LoadItemsCommand { get; set; } 
        public EncuestaViewModel()
        {             Title = "Chedraui";             Encuestas = new ObservableCollection<EncuestaItem>();             LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());              MessagingCenter.Subscribe<NewItemPage, EncuestaItem>(this, "AddItem", async (obj, item) =>             {                 var _item = item as EncuestaItem;                 Encuestas.Add(_item);                 await DataStore.AddItemAsync(_item);             });
        }          async Task ExecuteLoadItemsCommand()         {             if (IsBusy)                 return;              IsBusy = true;              try             {                 Encuestas.Clear();                 var items = await DataStore.GetItemsAsync(true);                 foreach (var item in items)                 {                     Encuestas.Add(item);                 }             }             catch (Exception ex)             {                 Debug.WriteLine(ex);             }             finally             {                 IsBusy = false;             }         }
    }
}
