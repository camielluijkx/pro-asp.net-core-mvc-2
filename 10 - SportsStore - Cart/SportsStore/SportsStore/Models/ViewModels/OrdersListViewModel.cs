using System.Collections.Generic;

namespace SportsStore.Models.ViewModels
{
    public class OrdersListViewModel
    {
        public IEnumerable<Order> Orders { get; set; }
    }
}