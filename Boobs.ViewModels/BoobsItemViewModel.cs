using Boobs.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boobs.ViewModels
{
    public class BoobsItemViewModel
    {
        BoobsDto BoobsItem;

        public BoobsItemViewModel(BoobsDto item)
        {
            this.BoobsItem = item;
        }

        public string Model => $"Модель: {BoobsItem.Model}";

        public string Preview => $"http://media.oboobs.ru/{BoobsItem.Preview}";

        public long Id => BoobsItem.Id;

        // public long Rank { get; set; }

        // public string Author { get; set; }
    }
}
