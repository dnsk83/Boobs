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
        public List<OrderByItem> SortByList { get; private set; }
        OrderByItem selectedSortingCriteria;
        public OrderByItem SelectedSortingCriteria
        {
            get { return selectedSortingCriteria; }
            set
            {
                if (selectedSortingCriteria != value)
                {
                    selectedSortingCriteria = value;
                    OnSortingChangedAsync();
                    NotifyPropertyChanged(nameof(SelectedSortingCriteria));
                }
            }
        }

        public BoobsListViewModel()
        {
            BoobsList = new ObservableCollection<BoobsItemViewModel>();
            GetBoobsAsync();
            LoadSortbyList();

            NotifyPropertyChanged(nameof(SortByList));
        }

        private void LoadSortbyList()
        {
            SortByList = new List<OrderByItem>();
            SortByList.Add(new OrderByItem(OrderBy.RankAsc, "Rating +"));
            SortByList.Add(new OrderByItem(OrderBy.RankDesc, "Rating -"));
            SortByList.Add(new OrderByItem(OrderBy.InterestAsc, "Interest +"));
            SortByList.Add(new OrderByItem(OrderBy.InterestDesc, "Interest -"));
            SortByList.Add(new OrderByItem(OrderBy.Random, "Random"));
            SortByList.Add(new OrderByItem(OrderBy.Id, "Photo ID"));
        }

        private async Task GetBoobsAsync(OrderBy orderBy=OrderBy.Random)
        {
            var service = new BoobsService();
            var list = await service.GetBoobsAsync(10, 10, orderBy);
            BoobsList.Clear();
            foreach (var item in list)
            {
                BoobsList.Add(new BoobsItemViewModel(item));
            }
            NotifyPropertyChanged(nameof(BoobsList));
        }

        private async Task OnSortingChangedAsync()
        {
            await GetBoobsAsync(SelectedSortingCriteria.Key);
        }

    }
}
