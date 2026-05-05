using GildedRoseKata.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRoseKata.Classes
{
    public class Conjured : IUpdateQuality
    {
        readonly int Quality_Min = 0;
        private readonly int SellIn_Min = 0;
        private readonly Item _item;

        public Conjured(Item item)
        {
            _item = item;
        }
        public void UpdateQuality()
        {
            _item.SellIn--;

            decreaseQuality(2);

            if (_item.SellIn < SellIn_Min)
                decreaseQuality(2);

        }

        private void decreaseQuality(int decrement)
        {
            if (_item.Quality > Quality_Min)
                _item.Quality = Math.Max(Quality_Min, _item.Quality - decrement); 
        }

    }
}
