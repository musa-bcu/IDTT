using GildedRoseKata.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRoseKata.Classes
{
    public class AgedBrie : IUpdateQuality
    {
        readonly int Quality_Max = 40;
        private readonly int SellIn_Min = 0;
        private readonly Item _item;

        public AgedBrie(Item item)
        {
            _item = item;
        }
        public void UpdateQuality()
        {
            _item.SellIn--;

            increaseQuality();

            if (_item.SellIn < SellIn_Min)
                increaseQuality();

        }

        private void increaseQuality()
        {
            if (_item.Quality < Quality_Max)
                _item.Quality++;
        }
    }
}
