using Xunit;
using System.Collections.Generic;
using GildedRoseKata;
using System.Linq;

namespace GildedRoseTests;

public class GildedRoseTests
{
    [Fact]
    public void UpdateQuality_NormalItem_DecreasesQualityByOne()
    {
        // Arrange
        IList<Item> items = new List<Item> { new Item { Name = "+5 Dexterity Vest", SellIn = 2, Quality = 1 } };
        GildedRose app = new GildedRose(items);

        // Act
        app.UpdateQuality();

        // Assert
        var item = items.Where(x => x.Name == "+5 Dexterity Vest").First();
        Assert.Equal(1, item.SellIn);
        Assert.Equal(0, item.Quality);
    }
}