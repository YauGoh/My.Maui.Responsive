using Microsoft.Maui;
using Microsoft.Maui.Graphics;
using Moq;

namespace My.Maui.Responsive.Tests
{
    internal class MockViewBuilder
    {
        private readonly double _requiredHeight;

        internal static MockViewBuilder Default => new MockViewBuilder(20);

        private MockViewBuilder(double requiredHeight)
        {
            _requiredHeight = requiredHeight;
        }

        public MockViewBuilder WithHeight(double height) => new MockViewBuilder(height);

        internal Mock<IView> Build()
        {
            var mock = new Mock<IView>();

            mock.Setup(_ => _.Measure(It.IsAny<double>(), It.IsAny<double>())).Returns((double width, double height) => new Size(width, _requiredHeight));

            return mock;
        }
    }
}
