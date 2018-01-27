using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chedraui.Expertas
{
    public class MockDataStore : IDataStore<EncuestaItem>
    {
        List<EncuestaItem> items;

        public MockDataStore()
        {
            items = new List<EncuestaItem>();
            var mockItems = new List<EncuestaItem>
            {
                new EncuestaItem { Id = 1, Titulo = "Desarrollo de productos para campaña 'Come saludable'", Premio="Cupón de descuento por 20%.", FechaFinal=DateTime.Now.AddDays(10) },
                new EncuestaItem { Id = 2, Titulo = "Desarrollo de productos vegetales 'Semana verde'", Premio="Taller de preparación de ensaladas.", FechaFinal=DateTime.Now.AddDays(5) },
                new EncuestaItem { Id = 3, Titulo = "Campaña del ingrediente más popular en tus comidas", Premio="Oferta 2x1 en el producto de preferencia", FechaFinal=DateTime.Now.AddDays(15) }
            };

            foreach (var item in mockItems)
            {
                items.Add(item);
            }
        }

        public async Task<bool> AddItemAsync(EncuestaItem item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(EncuestaItem item)
        {
            var _item = items.Where((EncuestaItem arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(_item);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            var _item = items.Where((EncuestaItem arg) => arg.Id == id).FirstOrDefault();
            items.Remove(_item);

            return await Task.FromResult(true);
        }

        public async Task<EncuestaItem> GetItemAsync(int id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<EncuestaItem>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}
