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

namespace Boobs
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
    }
}
