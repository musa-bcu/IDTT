using GildedRoseKata.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRoseKata.Classes
{
    public class Sulfuras : IUpdateQuality
    {
        private readonly Item _item;

        public Sulfuras(Item item)
        {
            _item = item;
        }
        public void UpdateQuality()
        {
            // never changes.
        }
    }
}
