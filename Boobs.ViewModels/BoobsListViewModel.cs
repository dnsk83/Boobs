using Boobs.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace Boobs.ViewModels
{
    public class BoobsListViewModel : BaseViewModel
    {
        public ObservableCollection<BoobsDto> BoobsList { get; set; }
        public BoobsListViewModel()
        {
            BoobsList = new ObservableCollection<BoobsDto>();
            GetBoobsAsync();
        }
        private async Task GetBoobsAsync()
        {
            var service = new BoobsService();
            var list = await service.GetBoobsAsync(10, 20);
            foreach (var item in list)
            {
                item.Preview = $"http://media.oboobs.ru/{item.Preview}";
                BoobsList.Add(item);
            }
            NotifyPropertyChanged(nameof(BoobsList));
        }
    }
}
