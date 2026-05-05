using GildedRoseKata.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRoseKata.Classes
{
    public class BackstagePasses: IUpdateQuality
    {
        private readonly int Quality_Max = 40;
        private readonly int SellIn_Min = 0;
        private readonly int SellIn_GreaterThanThreshold_IncrementQualityByOne = 7;
        private readonly int SellIn_LessThanEqualThreshold_IncrementQualityByThree = 7;
        private readonly int SellIn_LessThanEqualThreshold_IncrementQualityByFour = 2;
        private readonly Item _item;

        public BackstagePasses(Item item)
        {
            _item = item;
        }
        public void UpdateQuality()
        {
            _item.SellIn--;

            if(_item.SellIn > SellIn_GreaterThanThreshold_IncrementQualityByOne)
                increaseQuality(1);

            else if (_item.SellIn> SellIn_Min && _item.SellIn <= SellIn_LessThanEqualThreshold_IncrementQualityByThree && _item.SellIn > SellIn_LessThanEqualThreshold_IncrementQualityByFour)
                increaseQuality(3);

            else if (_item.SellIn > SellIn_Min && _item.SellIn <= SellIn_LessThanEqualThreshold_IncrementQualityByFour)
                increaseQuality(4);

            else if (_item.SellIn < SellIn_Min)
                _item.Quality = 0;
        }

        private void increaseQuality(int increment)
        {
            if (_item.Quality < Quality_Max)
                _item.Quality = Math.Min(Quality_Max, _item.Quality+ increment);
        }
    }
}
