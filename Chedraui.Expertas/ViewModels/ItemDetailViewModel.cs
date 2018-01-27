using System;

namespace Chedraui.Expertas
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public EncuestaItem Item { get; set; }
        public ItemDetailViewModel(EncuestaItem item = null)
        {
            Title = item?.Titulo;
            Item = item;
        }
    }
}
