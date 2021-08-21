namespace My.Maui.Responsive
{
    public interface IDeviceSizeProvider
    {
        DeviceSize Get();

        internal static IDeviceSizeProvider Instance => new DeviceSizeProvider(IWindowSizeProvider.Instance, new Breakpoints());
    }

    internal class DeviceSizeProvider : IDeviceSizeProvider
    {
        private readonly IWindowSizeProvider _windowSize;
        private readonly Breakpoints _breakPoints;

        public DeviceSizeProvider(
            IWindowSizeProvider windowSize, 
            Breakpoints breakPoints)
        {
            _windowSize = windowSize;
            _breakPoints = breakPoints;
        }

        public DeviceSize Get()
        {
            var size = _windowSize.Get();

            return size switch
            {
                _ when size.Width < _breakPoints.Small => DeviceSize.XSmall,
                _ when size.Width < _breakPoints.Medium => DeviceSize.Small,
                _ when size.Width < _breakPoints.Large => DeviceSize.Medium,
                _ when size.Width < _breakPoints.XLarge => DeviceSize.Large,
                _ when size.Width < _breakPoints.XXLarge => DeviceSize.XLarge,
                _ => DeviceSize.XXLarge
            };
        }
    }
}
