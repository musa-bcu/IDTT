using GildedRoseKata.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRoseKata.Classes
{
    public class NormalItemRule : IUpdateQuality
    {
        private readonly int Quality_Min = 0;
        private readonly int SellIn_Min = 0;
        private readonly Item _item;

        public NormalItemRule(Item item)
        {
            _item = item;
        }
        public void UpdateQuality()
        {
            _item.SellIn--;

            decreaseQuality();

            if (_item.SellIn < SellIn_Min)
                decreaseQuality();
        }

        private void decreaseQuality()
        {
            if (_item.Quality > Quality_Min)
                _item.Quality--;
        }
    }
}
