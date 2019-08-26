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
        public ObservableCollection<BoobsItemViewModel> BoobsList { get; set; }
        public BoobsListViewModel()
        {
            BoobsList = new ObservableCollection<BoobsItemViewModel>();
            GetBoobsAsync();
        }
        private async Task GetBoobsAsync()
        {
            var service = new BoobsService();
            var list = await service.GetBoobsAsync(10, 10);
            foreach (var item in list)
            {
                BoobsList.Add(new BoobsItemViewModel(item));
            }
            NotifyPropertyChanged(nameof(BoobsList));
        }
    }
}
