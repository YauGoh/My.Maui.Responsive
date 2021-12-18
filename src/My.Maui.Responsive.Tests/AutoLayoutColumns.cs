using Microsoft.Maui.Graphics;
using Moq;
using My.Maui.Responsive.Layouts;
using System.Linq;
using Xunit;

namespace My.Maui.Responsive.Tests;

public class AutoLayoutColumns : MyMauiTestBase
{
    private readonly Mock<IRowLayout> _mockRowLayout;
    private readonly RowLayoutManager _rowLayoutManager;

    public AutoLayoutColumns()
    {
        _mockRowLayout = new Mock<IRowLayout>();
        _rowLayoutManager = new RowLayoutManager(_mockRowLayout.Object);
    }

    [Theory]
    [InlineData(2, 1200, 600)]
    [InlineData(3, 1200, 400)]
    [InlineData(5, 1200, 240)]
    [InlineData(6, 1200, 200)]
    public void WhenAllItemsHaveNoWidths_AllShouldHaveEqualWidthsToFillRow(int count, double rowWidth, double expectItemWidths)
    {
        SetWindowWidth(rowWidth);

        var mockChildren = Enumerable
            .Range(0, count)
            .Select(_ => MockViewBuilder.Default.WithHeight(100).Build())
            .ToArray();
           
        _mockRowLayout.Setup(_ => _.GetOrderedVisibleElements()).Returns(mockChildren.Select(_ => _.Object));

        _rowLayoutManager.Measure(rowWidth, 100);
        _rowLayoutManager.ArrangeChildren(new Rectangle(0, 0, rowWidth, 100));

        foreach(var mock in mockChildren)
        {
            mock.Verify(child => child.Arrange(It.Is<Rectangle>(size => size.Width == expectItemWidths)));
        }
    }

    [Fact]
    public void WhenItemsHaveWidths_AutoWidthColumnsShouldHaveEqualWithsToFillRow()
    {
        SetWindowWidth(1200);

        var mockChildren = new[]
        {
            MockViewBuilder.Default.Build(),
            MockViewBuilder.Default.Build(),

            MockViewBuilder.Default.WithColumnSpan(new ResponsiveSpecifications { Xs = 4 }).Build(),

            MockViewBuilder.Default.Build(),
            MockViewBuilder.Default.Build()
        };

        _mockRowLayout.Setup(_ => _.GetOrderedVisibleElements()).Returns(mockChildren.Select(_ => _.Object));
        _mockRowLayout.Setup(_ => _.Columns).Returns(12);

        _rowLayoutManager.Measure(1200, double.PositiveInfinity);
        _rowLayoutManager.ArrangeChildren(new Rectangle(0, 0, 1200, 100));

        var expectedWidths = new[] { 200.0, 200.0, 400.0, 200.0, 200.0 };

        foreach(var (mock, index) in mockChildren.Select((mock, index) => (mock, index)))
        {
            mock.Verify(_ => _.Arrange(It.Is<Rectangle>(size => size.Width == expectedWidths[index])));
        }
    }
}