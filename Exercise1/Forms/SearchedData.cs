using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1.Forms
{
    internal class SearchedData
    {
        public SearchedData(string searchedItem, string priceFrom)
        {
            SearchedItem = searchedItem;
            PriceFrom = priceFrom;
        }

        public string SearchedItem { get; }
        public string PriceFrom { get; }
    }
}
