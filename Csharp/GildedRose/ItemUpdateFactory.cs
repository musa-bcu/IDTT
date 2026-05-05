using GildedRoseKata.Classes;
using GildedRoseKata.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRoseKata
{
    public class ItemUpdateFactory
    {
        public static IUpdateQuality GetUpdater(Item item)
        {
            return item.Name switch
            {
                "Aged Brie" => new AgedBrie(item),
                "Sulfuras, Hand of Ragnaros" => new Sulfuras(item),
                "Conjured Mana Cake" => new Conjured(item),
                "Backstage passes to a TAFKAL80ETC concert" => new BackstagePasses(item),
                _ => new NormalItemRule(item)
            };
        }
    }
}
