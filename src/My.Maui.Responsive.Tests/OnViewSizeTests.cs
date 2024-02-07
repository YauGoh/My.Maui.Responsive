using FluentAssertions;

namespace My.Maui.Responsive.Tests;

public class OnViewSizeTests : MyMauiTestBase
{
    [Theory]
    [InlineData( 575.9, 100, "Extra small")]
    [InlineData( 576.0, 100, "Small")]
    [InlineData( 767.9, 100, "Small")]
    [InlineData( 768.0, 100, "Medium")]
    [InlineData( 991.9, 100, "Medium")]
    [InlineData( 992.0, 100, "Large")]
    [InlineData(1199.9, 100, "Large")]
    [InlineData(1200.0, 100, "Extra large")]
    [InlineData(1399.9, 100, "Extra large")]
    [InlineData(1400.0, 100, "Extra extra large")]
    public void ShouldUpdateValueWhenViewSizeChanges(double width, double hieght, string expectedValue)
    {
        var onViewSize = new OnViewSize<string>
        {
            Default = "Default",
            Xs = "Extra small",
            Sm = "Small",
            Md = "Medium",
            Lg = "Large",
            Xl = "Extra large",
            Xxl = "Extra extra large"
        };

        InvokeSizeChange(new Size(width, hieght));

        var actualValue = (string)onViewSize;

        actualValue.Should().Be(expectedValue);
    }

    [Theory]
    [InlineData(DeviceSize.XSmall, 575.9, 100)]
    [InlineData(DeviceSize.Small, 576.0, 100)]
    [InlineData(DeviceSize.Medium, 768.0, 100)]
    [InlineData(DeviceSize.Large, 992.0, 100)]
    [InlineData(DeviceSize.XLarge, 1200.0, 100)]
    [InlineData(DeviceSize.XXLarge, 1400.0, 100)]
    public void ShouldUseDefaultValueWhenNotDefined(DeviceSize deviceSizeToUnset, double width, double hieght)
    {
        var onViewSize = new OnViewSize<string>
        {
            Default = "Default",
            Xs = "Extra small",
            Sm = "Small",
            Md = "Medium",
            Lg = "Large",
            Xl = "Extra large",
            Xxl = "Extra extra large"
        };

        switch(deviceSizeToUnset)
        {
            case DeviceSize.XSmall: 
                onViewSize.Xs = null;
                break;

            case DeviceSize.Small:
                onViewSize.Sm = null;
                break;

            case DeviceSize.Medium: 
                onViewSize.Md = null; 
                break;

            case DeviceSize.Large: 
                onViewSize.Lg = null; 
                break;

            case DeviceSize.XLarge:
                onViewSize.Xl = null;
                break;

            case DeviceSize.XXLarge: 
                onViewSize.Xxl = null;
                break;
        }


        InvokeSizeChange(new Size(width, hieght));

        var actualValue = (string)onViewSize;

        actualValue.Should().Be("Default");
    }
}