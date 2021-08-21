namespace My.Maui.Responsive
{
    internal record Breakpoints
    {
        public double Small { get; init; } = 576.0;
        public double Medium { get; init; } = 768.0;
        public double Large { get; init; } = 992.0;
        public double XLarge { get; init; } = 1200.0;
        public double XXLarge { get; init; } = 1400.0;
    }
}
