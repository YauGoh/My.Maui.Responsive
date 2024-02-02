using My.Maui.Responsive.Samples.Pages;

namespace My.Maui.Responsive.Samples.ViewModels;

internal class LandPageViewModel : ViewModel
{
    public LandPageViewModel()
    {
        SamplePages = new SamplePage[]
        {
                new SamplePage<AutoLayoutColumnsPage>("Auto-layout columns"),
                new SamplePage<SettingOneColumnWidthPage>("Setting one column width"),
                new SamplePage<VariableWidthContentPage>("Variable width content"),
                new SamplePage<EqualWidthMultiRowPage>("Equal-width multi-row"),
                new SamplePage<MixAndMatchPage>("Mix and match"),
                new SamplePage<VerticalAlignmentPage>("Vertical alignment"),
                new SamplePage<HorizontalAlignmentPage>("Horizontal alignment"),
                new SamplePage<ReorderingPage>("Reordering"),
                new SamplePage<OffsettingColumnsPage>("Offsetting columns"),
                new SamplePage<NestingPage>("Nesting"),
        };
    }

    public IEnumerable<SamplePage> SamplePages { get; }
}

internal record SamplePage
{
    public SamplePage(string title, Type pageType)
    {
        Title = title;
        PageType = pageType;

        NavigateTo = new Command(async () =>
        {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            await Application.Current.MainPage.Navigation.PushAsync(GetPage());
#pragma warning restore CS8602 // Dereference of a possibly null reference.
        });
    }

    public string Title { get; }
    public Type PageType { get; }
    public Command NavigateTo { get; }

    private Page GetPage()
    {
        var page = Activator.CreateInstance(PageType);

        if (page is null) throw new InvalidOperationException($"Unable to create page {PageType}");

        return (Page)page;
    }
}

internal record SamplePage<TPage> : SamplePage where TPage : Page, new()
{
    public SamplePage(string title) : base(title, typeof(TPage)) { }
}