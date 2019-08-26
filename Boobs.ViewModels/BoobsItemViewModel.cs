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
        public string FullSize => GetFullSize();

        public long Id => BoobsItem.Id;

        // public long Rank { get; set; }

        // public string Author { get; set; }

        private string GetFullSize()
        {
            var sub = "_preview";
            var s1 = Preview.Substring(0, Preview.IndexOf(sub));
            var s2 = Preview.Substring(s1.Length + sub.Length);
            return s1 + s2;
        }
    }
}
