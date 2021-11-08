using Xunit;

namespace My.Maui.Responsive.Tests;

public class AutoLayoutColumns
{
    [Theory]
    [InlineData(2, 1200, 600)]
    [InlineData(3, 1200, 400)]
    [InlineData(5, 1200, 240)]
    [InlineData(6, 1200, 200)]
    public void AllItemsInRowShouldHaveTheSameWidths(int count, double rowWidth, double expectItemWidths)
    {
    }
}