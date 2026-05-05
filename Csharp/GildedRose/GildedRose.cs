using GildedRoseKata.Contracts;
using System.Collections.Generic;

namespace GildedRoseKata;

public class GildedRose
{
    IList<Item> Items;

    public GildedRose(IList<Item> Items)
    {
        this.Items = Items;
    }

    public void UpdateQuality()
    {
        // New Refactored version
        foreach (var item in Items)
        {
            var updater = ItemUpdateFactory.GetUpdater(item);
            updater.UpdateQuality();
        }
    }

}