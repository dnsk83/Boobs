using Boobs.Core;
using Boobs.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Boobs.UI
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        BoobsListViewModel VM;
        public MainPage()
        {
            InitializeComponent();
            VM = new BoobsListViewModel();
            this.BindingContext = VM;
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedItem = ((ListView)sender).SelectedItem;
            if (selectedItem != null)
            {
                var itemVm = (BoobsItemViewModel)e.SelectedItem;
                OpenFullSize(itemVm);
            }
            ((ListView)sender).SelectedItem = null;
        }

        private void OpenFullSize(BoobsItemViewModel itemVm)
        {
            Navigation.PushModalAsync(new FullSizePage(itemVm));
        }

        private void Entry_Unfocused(object sender, FocusEventArgs e)
        {
            var value = ((Entry)sender).Text;
            VM.SetDisplayPage(value);
        }
    }
}
