using Boobs.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Boobs.UI
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FullSizePage : ContentPage
    {
        public BoobsItemViewModel VM { get; private set; }

        public FullSizePage()
        {
            InitializeComponent();
        }

        public FullSizePage(BoobsItemViewModel vm) : this()
        {
            this.VM = vm;
            this.BindingContext = VM;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
    }
}