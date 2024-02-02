using FluentAssertions;
using Moq;
using My.Maui.Responsive.Layouts;

namespace My.Maui.Responsive.Tests;

public class ContainerLayoutTests
{
    private readonly Mock<IContainerLayout> _mockContainer;
    private readonly ContainerLayoutManager _containerLayoutManager;

    public ContainerLayoutTests()
    {
        _mockContainer = new Mock<IContainerLayout>();
        _containerLayoutManager = new ContainerLayoutManager(_mockContainer.Object);
    }

    [Theory]
    [InlineData(20, 30, 0, 0, 0, 0, 50)]
    [InlineData(20, 30, 0, 5, 0, 0, 55)]
    [InlineData(20, 30, 0, 5, 0, 5, 60)]
    public void DefaultStackLayout(double child1Height, double child2Height, double paddingLeft, double paddingTop, double paddingRight, double paddingBottom, double expectedHeight)
    {
        var child1 = MockViewBuilder.Default
            .WithHeight(child1Height)
            .Build();

        var child2 = MockViewBuilder.Default
            .WithHeight(child2Height)
            .Build();

        _mockContainer.Setup(_ => _.Padding).Returns(new Thickness(paddingLeft, paddingTop, paddingRight, paddingBottom));

        _mockContainer.Setup(_ => _.GetOrderedVisibleRows()).Returns(new[]
        {
                child1.Object,
                child2.Object
            });

        var size = _containerLayoutManager.Measure(800, 600);

        size.Should().Be(new Size(800, expectedHeight));
    }
}