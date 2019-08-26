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
        int displayFrom;
        int displayRange;
        int displayPage;
        public int DisplayPage
        {
            get => displayPage;
            set
            {
                if (displayPage != value)
                {
                    displayPage = value;
                    displayFrom = (displayPage - 1) * displayRange;
                    OnDisplayRangeChangedAsync();
                }
            }
        }
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

        public void SetDisplayPage(string value)
        {
            if (int.TryParse(value, out var valueInt))
            {
                DisplayPage = valueInt;
            }
        }

        public BoobsListViewModel()
        {
            BoobsList = new ObservableCollection<BoobsItemViewModel>();
            displayFrom = 0;
            displayRange = 10;
            GetBoobsAsync();
            LoadSortbyList();
            NotifyPropertyChanged(nameof(SortByList));
        }

        private void LoadSortbyList()
        {
            SortByList = new List<OrderByItem>();
            SortByList.Add(new OrderByItem(OrderBy.RankAsc, "Рейтиг ^"));
            SortByList.Add(new OrderByItem(OrderBy.RankDesc, "Рейтинг v"));
            SortByList.Add(new OrderByItem(OrderBy.InterestAsc, "Просмотры ^"));
            SortByList.Add(new OrderByItem(OrderBy.InterestDesc, "Просмотры v"));
            SortByList.Add(new OrderByItem(OrderBy.Random, "Случайным образом"));
            SortByList.Add(new OrderByItem(OrderBy.Id, "ID файла"));
        }

        private async Task GetBoobsAsync(OrderBy orderBy = OrderBy.Random)
        {
            var service = new BoobsService();
            var list = await service.GetBoobsAsync(displayFrom, displayRange, orderBy);
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

        private async Task OnDisplayRangeChangedAsync()
        {
            await GetBoobsAsync(SelectedSortingCriteria?.Key ?? OrderBy.Random);
        }

    }
}
