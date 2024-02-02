using System.ComponentModel;
using System.Globalization;

namespace My.Maui.Responsive;

[TypeConverter(typeof(ResponsiveSpecificationsTypeConverter))]
public record ResponsiveSpecifications
{
    public int Default { get; init; }

    public int? Xs { get; init; }

    public int? Sm { get; init; }

    public int? Md { get; init; }

    public int? Lg { get; init; }

    public int? Xl { get; init; }

    public int? Xxl { get; init; }

    public int Current => IDeviceSizeProvider.Instance.Get() switch
    {
        DeviceSize.XSmall => Xs ?? Default,
        DeviceSize.Small => Sm ?? Xs ?? Default,
        DeviceSize.Medium => Md ?? Sm ?? Xs ?? Default,
        DeviceSize.Large => Lg ?? Md ?? Sm ?? Xs ?? Default,
        DeviceSize.XLarge => Xl ?? Lg ?? Md ?? Sm ?? Xs ?? Default,
        DeviceSize.XXLarge => Xxl ?? Xl ?? Lg ?? Md ?? Sm ?? Xs ?? Default,
        _ => Default
    };
}

public class ResponsiveSpecificationsTypeConverter : TypeConverter
{
    public override bool CanConvertFrom(ITypeDescriptorContext? context, Type sourceType)
        => sourceType == typeof(string);

    public override bool CanConvertTo(ITypeDescriptorContext? context, Type? destinationType)
        => destinationType == typeof(string);

    public override object ConvertFrom(ITypeDescriptorContext? context, CultureInfo? culture, object? value)
    {
        if (value == null) return new ResponsiveSpecifications { };

        var values = ((string)value)
            .Split(',', StringSplitOptions.TrimEntries)
            .Select(str => int.TryParse(str, out var intValue) ? (int?)intValue : null)
            .ToList();

        var specifications = new ResponsiveSpecifications
        {
            Xs = values.FirstOrDefault(),
            Sm = values.Skip(1).FirstOrDefault(),
            Md = values.Skip(2).FirstOrDefault(),
            Lg = values.Skip(3).FirstOrDefault(),
            Xl = values.Skip(4).FirstOrDefault(),
            Xxl = values.Skip(5).FirstOrDefault()
        };

        return specifications;
    }

    public override object ConvertTo(ITypeDescriptorContext? context, CultureInfo? culture, object? value, Type destinationType)
    {
        if (value is not ResponsiveSpecifications specs)
            throw new NotSupportedException();

        return $"{specs.Xs},{specs.Sm},{specs.Md},{specs.Lg},{specs.Xl},{specs.Xxl}";
    }
}