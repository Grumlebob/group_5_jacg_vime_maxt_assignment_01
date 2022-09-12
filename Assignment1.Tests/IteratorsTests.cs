using Xunit;

namespace Assignment1.Tests;

public class IteratorsTests
{
    //STARTER SETUP, ALSO EXPERIENCING WITH COPILOT.
    [Fact]
    public void Flatten_EmptyList_ReturnsEmptyList()
    {
        // Arrange
        var list = new List<List<int>>();

        // Act
        var result = Iterators.Flatten(list);

        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public void Flatten_ListWithList_1_2_3_4_Returns_List_1_2_3_4()
    {
        // Arrange
        var list = new List<List<int>> { new List<int>() { 1, 2, 3, 4 } };

        // Act
        var result = Iterators.Flatten(list);

        // Assert
        Assert.Equal(new[] { 1, 2, 3, 4 }, result);
    }

    [Fact]
    public void Flatten_ListWithList_1_2_3_4_And_List_5_6_7_8_Returns_List_1_2_3_4_5_6_7_8()
    {
        // Arrange
        var list = new List<List<int>> { new List<int>() { 1, 2, 3, 4 }, new List<int>() { 5, 6, 7, 8 } };

        // Act
        var result = Iterators.Flatten(list);

        // Assert
        Assert.Equal(new[] { 1, 2, 3, 4, 5, 6, 7, 8 }, result);
    }


    [Fact]
    public void Filter_EmptyList_ReturnsEmptyList()
    {
        // Arrange
        var list = new List<int>();

        // Act
        var result = Iterators.Filter(list, x => x % 2 == 0);

        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public void Filter_List_1_2_3_4_Returns_List_2_4()
    {
        // Arrange
        var list = new List<int> { 1, 2, 3, 4 };

        // Act
        var result = Iterators.Filter(list, x => x % 2 == 0);

        // Assert
        Assert.Equal(new[] { 2, 4 }, result);
    }

    [Fact]
    public void Filter_List_1_2_3_4_Returns_List_1_3()
    {
        // Arrange
        var list = new List<int> { 1, 2, 3, 4 };

        // Act
        var result = Iterators.Filter(list, x => x % 2 != 0);

        // Assert
        Assert.Equal(new[] { 1, 3 }, result);
    }
}
