using Boobs.Core;

namespace Boobs.ViewModels
{
    public class OrderByItem
    {
        public OrderByItem(OrderBy orderBy, string Name)
        {
            this.Key = orderBy;
            this.Name = Name;
        }

        public OrderBy Key { get; set; }
        public string Name { get; set; }
    }
}