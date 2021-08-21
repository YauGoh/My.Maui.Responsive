using Microsoft.Maui.Controls;

namespace My.Maui.Responsive
{
    public partial class Row
    {
        public static readonly BindableProperty OffsetProperty = BindableProperty.CreateAttached("Offset", typeof(ResponsiveSpecifications), typeof(Row), new ResponsiveSpecifications { Default = 0 });
        public static readonly BindableProperty OffsetXsProperty = BindableProperty.CreateAttached("OffsetXs", typeof(int?), typeof(Row), null, propertyChanged: OnOffsetXsPropertyChanged);
        public static readonly BindableProperty OffsetSmProperty = BindableProperty.CreateAttached("OffsetSm", typeof(int?), typeof(Row), null, propertyChanged: OnOffsetSmPropertyChanged);
        public static readonly BindableProperty OffsetMdProperty = BindableProperty.CreateAttached("OffsetMd", typeof(int?), typeof(Row), null, propertyChanged: OnOffsetMdPropertyChanged);
        public static readonly BindableProperty OffsetLgProperty = BindableProperty.CreateAttached("OffsetLg", typeof(int?), typeof(Row), null, propertyChanged: OnOffsetLgPropertyChanged);
        public static readonly BindableProperty OffsetXlProperty = BindableProperty.CreateAttached("OffsetXl", typeof(int?), typeof(Row), null, propertyChanged: OnOffsetXlPropertyChanged);
        public static readonly BindableProperty OffsetXxlProperty = BindableProperty.CreateAttached("OffsetXxl", typeof(int?), typeof(Row), null, propertyChanged: OnOffsetXxlPropertyChanged);

        public static ResponsiveSpecifications GetOffset(BindableObject bindable) => (ResponsiveSpecifications)bindable.GetValue(OffsetProperty);
        public static void SetOffset(BindableObject bindable, ResponsiveSpecifications value) => bindable.SetValue(OffsetProperty, value);

        public static int? GetOffsetXs(BindableObject bindable) => (int?)bindable.GetValue(OffsetXsProperty);
        public static int? GetOffsetSm(BindableObject bindable) => (int?)bindable.GetValue(OffsetSmProperty);
        public static int? GetOffsetMd(BindableObject bindable) => (int?)bindable.GetValue(OffsetMdProperty);
        public static int? GetOffsetLg(BindableObject bindable) => (int?)bindable.GetValue(OffsetLgProperty);
        public static int? GetOffsetXl(BindableObject bindable) => (int?)bindable.GetValue(OffsetXlProperty);
        public static int? GetOffsetXxl(BindableObject bindable) => (int?)bindable.GetValue(OffsetXxlProperty);

        private static void OnOffsetXsPropertyChanged(BindableObject bindable, object oldValue, object newValue) => SetOffset(bindable, GetOffset(bindable) with { Xs = (int?)newValue });
        private static void OnOffsetSmPropertyChanged(BindableObject bindable, object oldValue, object newValue) => SetOffset(bindable, GetOffset(bindable) with { Sm = (int?)newValue });
        private static void OnOffsetMdPropertyChanged(BindableObject bindable, object oldValue, object newValue) => SetOffset(bindable, GetOffset(bindable) with { Md = (int?)newValue });
        private static void OnOffsetLgPropertyChanged(BindableObject bindable, object oldValue, object newValue) => SetOffset(bindable, GetOffset(bindable) with { Lg = (int?)newValue });
        private static void OnOffsetXlPropertyChanged(BindableObject bindable, object oldValue, object newValue) => SetOffset(bindable, GetOffset(bindable) with { Xl = (int?)newValue });
        private static void OnOffsetXxlPropertyChanged(BindableObject bindable, object oldValue, object newValue) => SetOffset(bindable, GetOffset(bindable) with { Xxl = (int?)newValue });
    }
}
