namespace My.Maui.Responsive;

public partial class Row
{
    public static readonly BindableProperty OrderProperty = BindableProperty.CreateAttached("Order", typeof(ResponsiveSpecifications), typeof(Row), new ResponsiveSpecifications { Default = 0 });
    public static readonly BindableProperty OrderXsProperty = BindableProperty.CreateAttached("OrderXs", typeof(int?), typeof(Row), null, propertyChanged: OnOrderXsPropertyChanged);
    public static readonly BindableProperty OrderSmProperty = BindableProperty.CreateAttached("OrderSm", typeof(int?), typeof(Row), null, propertyChanged: OnOrderSmPropertyChanged);
    public static readonly BindableProperty OrderMdProperty = BindableProperty.CreateAttached("OrderMd", typeof(int?), typeof(Row), null, propertyChanged: OnOrderMdPropertyChanged);
    public static readonly BindableProperty OrderLgProperty = BindableProperty.CreateAttached("OrderLg", typeof(int?), typeof(Row), null, propertyChanged: OnOrderLgPropertyChanged);
    public static readonly BindableProperty OrderXlProperty = BindableProperty.CreateAttached("OrderXl", typeof(int?), typeof(Row), null, propertyChanged: OnOrderXlPropertyChanged);
    public static readonly BindableProperty OrderXxlProperty = BindableProperty.CreateAttached("OrderXxl", typeof(int?), typeof(Row), null, propertyChanged: OnOrderXxlPropertyChanged);

    public static ResponsiveSpecifications GetOrder(BindableObject bindable) => (ResponsiveSpecifications)bindable.GetValue(OrderProperty);
    public static void SetOrder(BindableObject bindable, ResponsiveSpecifications value) => bindable.SetValue(OrderProperty, value);

    public static int? GetOrderXs(BindableObject bindable) => (int?)bindable.GetValue(OrderXsProperty);
    public static int? GetOrderSm(BindableObject bindable) => (int?)bindable.GetValue(OrderSmProperty);
    public static int? GetOrderMd(BindableObject bindable) => (int?)bindable.GetValue(OrderMdProperty);
    public static int? GetOrderLg(BindableObject bindable) => (int?)bindable.GetValue(OrderLgProperty);
    public static int? GetOrderXl(BindableObject bindable) => (int?)bindable.GetValue(OrderXlProperty);
    public static int? GetOrderXxl(BindableObject bindable) => (int?)bindable.GetValue(OrderXxlProperty);

    private static void OnOrderXsPropertyChanged(BindableObject bindable, object oldValue, object newValue) => SetOrder(bindable, GetOrder(bindable) with { Xs = (int?)newValue });
    private static void OnOrderSmPropertyChanged(BindableObject bindable, object oldValue, object newValue) => SetOrder(bindable, GetOrder(bindable) with { Sm = (int?)newValue });
    private static void OnOrderMdPropertyChanged(BindableObject bindable, object oldValue, object newValue) => SetOrder(bindable, GetOrder(bindable) with { Md = (int?)newValue });
    private static void OnOrderLgPropertyChanged(BindableObject bindable, object oldValue, object newValue) => SetOrder(bindable, GetOrder(bindable) with { Lg = (int?)newValue });
    private static void OnOrderXlPropertyChanged(BindableObject bindable, object oldValue, object newValue) => SetOrder(bindable, GetOrder(bindable) with { Xl = (int?)newValue });
    private static void OnOrderXxlPropertyChanged(BindableObject bindable, object oldValue, object newValue) => SetOrder(bindable, GetOrder(bindable) with { Xxl = (int?)newValue });
}
