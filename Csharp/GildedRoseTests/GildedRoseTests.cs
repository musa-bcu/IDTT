using Xunit;
using System.Collections.Generic;
using GildedRoseKata;
using System.Linq;

namespace GildedRoseTests;

public class GildedRoseTests
{
    /// <summary>
    /// NormalItem: DecreasesQualityByOne
    /// Result without changes: Passed
    /// </summary>
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

    /// <summary>
    /// NormalItem: QualityNeverNegative
    /// Result without changes: Passed
    /// </summary>
    [Fact]
    public void UpdateQuality_NormalItem_QualityNeverNegative()
    {
        var items = new List<Item>
        {
            new Item { Name = "+5 Dexterity Vest", SellIn = 2, Quality = 0 }
        };

        var app = new GildedRose(items);

        app.UpdateQuality();

        var item = items.First();
        Assert.Equal(0, item.Quality);
    }

    /// <summary>
    /// NormalItem: AfterSellDate_DegradesTwiceAsFast
    /// Result without changes: Passed
    /// </summary>
    [Fact]
    public void UpdateQuality_NormalItem_AfterSellDate_DegradesTwiceAsFast()
    {
        var items = new List<Item>
        {
            new Item { Name = "Elixir of the Mongoose", SellIn = 0, Quality = 10 }
        };

        var app = new GildedRose(items);

        app.UpdateQuality();

        var item = items.First();
        Assert.Equal(8, item.Quality);
        Assert.Equal(-1, item.SellIn);
    }

    /// <summary>
    /// Aged Brie: AgedBrie_IncreasesQualityByOne
    /// Result without changes: Passed
    /// </summary>
    [Fact]
    public void UpdateQuality_AgedBrie_IncreasesQualityByOne()
    {
        var items = new List<Item>
        {
            new Item { Name = "Aged Brie", SellIn = 5, Quality = 10 }
        };

        var app = new GildedRose(items);

        app.UpdateQuality();

        var item = items.First();
        Assert.Equal(11, item.Quality);
        Assert.Equal(4, item.SellIn);
    }

    /// <summary>
    /// Aged Brie: AfterSellDate_IncreasesByTwo
    /// Result without changes: Passed
    /// </summary>
    [Fact]
    public void UpdateQuality_AgedBrie_AfterSellDate_IncreasesByTwo()
    {
        var items = new List<Item>
        {
            new Item { Name = "Aged Brie", SellIn = 0, Quality = 12 }
        };

        var app = new GildedRose(items);

        app.UpdateQuality();

        var item = items.First();
        Assert.Equal(14, item.Quality);
    }

    /// <summary>
    /// Aged Brie: QualityNeverExceedsFourty
    /// Result without changes: Failed
    /// Reason: Unit test edge case: upper limit 40 as per specification, but in code it is set as 50, hence failed
    /// </summary>
    [Fact]
    public void UpdateQuality_AgedBrie_QualityNeverExceedsFourty()
    {
        var items = new List<Item>
        {
            new Item { Name = "Aged Brie", SellIn = 5, Quality = 40 }
        };

        var app = new GildedRose(items);

        app.UpdateQuality();

        var item = items.First();
        Assert.Equal(40, item.Quality);
    }
    /// <summary>
    /// Sulfuras: NeverChangesQualityOrSellIn
    /// Result without changes: Passed
    /// </summary>
    [Fact]
    public void UpdateQuality_Sulfuras_NeverChangesQualityOrSellIn()
    {
        var items = new List<Item>
        {
            new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 2, Quality = 80 }
        };

        var app = new GildedRose(items);

        app.UpdateQuality();

        var item = items.First();
        Assert.Equal(80, item.Quality);
        Assert.Equal(2, item.SellIn);
    }

    /// <summary>
    /// BackstagePass: MoreThanSevenDays_IncreasesByOne
    /// Result without changes: Failed
    /// Reason: quality is expected to increase by 1 as per specification for 8 days or more, in actual it is increased by 2
    /// </summary>

    [Fact]
    public void UpdateQuality_BackstagePass_MoreThanSevenDays_IncreasesByOne()
    {
        var items = new List<Item>
        {
            new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 8, Quality = 20 }
        };

        var app = new GildedRose(items);

        app.UpdateQuality();

        var item = items.First();
        Assert.Equal(21, item.Quality);
    }

    /// <summary>
    /// BackstagePass: SevenDaysOrLess_IncreasesByThree
    /// Result without changes: Failed
    /// Reason: quality is expected to increase by 3 as per specification for 7 days or less, in actual it is increased by 4
    /// </summary>
     
    [Fact]
    public void UpdateQuality_BackstagePass_SevenDaysOrLess_IncreasesByThree()
    {
        var items = new List<Item>
        {
            new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 7, Quality = 20 }
        };

        var app = new GildedRose(items);

        app.UpdateQuality();

        var item = items.First();
        Assert.Equal(23, item.Quality);
    }

    /// <summary>
    /// BackstagePass: FiveDays_IncreasesByThree
    /// Result without changes: Passed
    /// </summary>
     
    [Fact]
    public void UpdateQuality_BackstagePass_FiveDays_IncreasesByThree()
    {
        var items = new List<Item>
        {
            new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 20 }
        };

        var app = new GildedRose(items);

        app.UpdateQuality();

        var item = items.First();
        Assert.Equal(23, item.Quality);
    }

    /// <summary>
    /// BackstagePass: TwoDaysOrLess_IncreasesByFour
    /// Result without changes: Failed
    /// Reason: quality is expected to increase by 4 as per specification for 2 days or less, in actual it is increased by 3
    /// </summary>

    [Fact]
    public void UpdateQuality_BackstagePass_TwoDaysOrLess_IncreasesByFour()
    {
        var items = new List<Item>
        {
            new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 2, Quality = 20 }
        };

        var app = new GildedRose(items);

        app.UpdateQuality();

        var item = items.First();
        Assert.Equal(24, item.Quality);
    }

    /// <summary>
    /// BackstagePass: AfterConcert_QualityDropsToZero
    /// Result without changes: Passed
    /// </summary>

    [Fact]
    public void UpdateQuality_BackstagePass_AfterConcert_QualityDropsToZero()
    {
        var items = new List<Item>
        {
            new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 20 }
        };

        var app = new GildedRose(items);

        app.UpdateQuality();

        var item = items.First();
        Assert.Equal(0, item.Quality);
    }

    /// <summary>
    /// ConjuredItem: DecreasesQualityTwiceAsFast
    /// New item: before sell date quality decrease by (2)
    /// </summary>
    [Fact]
    public void UpdateQuality_ConjuredItem_DecreasesQualityTwiceAsFast()
    {
        var items = new List<Item>
        {
            new Item { Name = "Conjured Mana Cake", SellIn = 3, Quality = 10 }
        };

        var app = new GildedRose(items);

        app.UpdateQuality();

        var item = items.First();
        Assert.Equal(8, item.Quality);
        Assert.Equal(2, item.SellIn);
    }
    /// <summary>
    /// ConjuredItem: AfterSellDate_DegradesTwiceAgain
    /// New item: after sell date quality decrease by (2)
    /// </summary>
    [Fact]
    public void UpdateQuality_ConjuredItem_AfterSellDate_DegradesTwiceAgain()
    {
        var items = new List<Item>
        {
            new Item { Name = "Conjured Mana Cake", SellIn = 0, Quality = 10 }
        };

        var app = new GildedRose(items);

        app.UpdateQuality();

        var item = items.First();
        Assert.Equal(6, item.Quality);
        Assert.Equal(-1, item.SellIn);
    }
    /// <summary>
    /// ConjuredItem: QualityNeverNegative
    /// New item: min quality is 0
    /// </summary>
    [Fact]
    public void UpdateQuality_ConjuredItem_QualityNeverNegative()
    {
        var items = new List<Item>
        {
            new Item { Name = "Conjured Mana Cake", SellIn = 3, Quality = 1 }
        };

        var app = new GildedRose(items);

        app.UpdateQuality();

        var item = items.First();
        Assert.Equal(0, item.Quality);
    }
}