namespace My.Maui.Responsive;

public partial class Row
{
    public static readonly BindableProperty ColumnSpanProperty = BindableProperty.CreateAttached("ColumnSpan", typeof(ResponsiveSpecifications), typeof(Row), new ResponsiveSpecifications { Default = 0 });
    public static readonly BindableProperty XsProperty = BindableProperty.CreateAttached("Xs", typeof(int?), typeof(Row), null, propertyChanged: OnXsPropertyChanged);
    public static readonly BindableProperty SmProperty = BindableProperty.CreateAttached("Sm", typeof(int?), typeof(Row), null, propertyChanged: OnSmPropertyChanged);
    public static readonly BindableProperty MdProperty = BindableProperty.CreateAttached("Md", typeof(int?), typeof(Row), null, propertyChanged: OnMdPropertyChanged);
    public static readonly BindableProperty LgProperty = BindableProperty.CreateAttached("Lg", typeof(int?), typeof(Row), null, propertyChanged: OnLgPropertyChanged);
    public static readonly BindableProperty XlProperty = BindableProperty.CreateAttached("Xl", typeof(int?), typeof(Row), null, propertyChanged: OnXlPropertyChanged);
    public static readonly BindableProperty XxlProperty = BindableProperty.CreateAttached("Xxl", typeof(int?), typeof(Row), null, propertyChanged: OnXxlPropertyChanged);

    public static ResponsiveSpecifications GetColumnSpan(BindableObject bindable) => (ResponsiveSpecifications)bindable.GetValue(ColumnSpanProperty);
    public static void SetColumnSpan(BindableObject bindable, ResponsiveSpecifications value) => bindable.SetValue(ColumnSpanProperty, value);

    public static int? GetXs(BindableObject bindable) => (int?)bindable.GetValue(XsProperty);
    public static int? GetSm(BindableObject bindable) => (int?)bindable.GetValue(SmProperty);
    public static int? GetMd(BindableObject bindable) => (int?)bindable.GetValue(MdProperty);
    public static int? GetLg(BindableObject bindable) => (int?)bindable.GetValue(LgProperty);
    public static int? GetXl(BindableObject bindable) => (int?)bindable.GetValue(XlProperty);
    public static int? GetXxl(BindableObject bindable) => (int?)bindable.GetValue(XxlProperty);

    private static void OnXsPropertyChanged(BindableObject bindable, object oldValue, object newValue) => SetColumnSpan(bindable, GetColumnSpan(bindable) with { Xs = (int?)newValue });
    private static void OnSmPropertyChanged(BindableObject bindable, object oldValue, object newValue) => SetColumnSpan(bindable, GetColumnSpan(bindable) with { Sm = (int?)newValue });
    private static void OnMdPropertyChanged(BindableObject bindable, object oldValue, object newValue) => SetColumnSpan(bindable, GetColumnSpan(bindable) with { Md = (int?)newValue });
    private static void OnLgPropertyChanged(BindableObject bindable, object oldValue, object newValue) => SetColumnSpan(bindable, GetColumnSpan(bindable) with { Lg = (int?)newValue });
    private static void OnXlPropertyChanged(BindableObject bindable, object oldValue, object newValue) => SetColumnSpan(bindable, GetColumnSpan(bindable) with { Xl = (int?)newValue });
    private static void OnXxlPropertyChanged(BindableObject bindable, object oldValue, object newValue) => SetColumnSpan(bindable, GetColumnSpan(bindable) with { Xxl = (int?)newValue });
}
