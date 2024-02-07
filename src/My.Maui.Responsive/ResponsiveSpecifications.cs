using Microsoft.Extensions.Logging;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace My.Maui.Responsive;

public record ResponsiveSpecifications<TValue> where TValue: struct
{
    public TValue Default { get; init; }

    public TValue? Xs { get; init; }

    public TValue? Sm { get; init; }

    public TValue? Md { get; init; }

    public TValue? Lg { get; init; }

    public TValue? Xl { get; init; }

    public TValue? Xxl { get; init; }

    public TValue Current => IDeviceSizeProvider.Instance.Get() switch
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

public class ResponsiveSpecificationsTypeConverter<TSpecifications, TValue> : TypeConverter 
    where TSpecifications : ResponsiveSpecifications<TValue>, new()
    where TValue : struct
{
    public override bool CanConvertFrom(ITypeDescriptorContext? context, Type sourceType)
        => sourceType == typeof(string);

    public override bool CanConvertTo(ITypeDescriptorContext? context, Type? destinationType)
        => destinationType == typeof(string);

    public override object ConvertFrom(ITypeDescriptorContext? context, CultureInfo? culture, object? value)
    {
        if (value == null) return new TSpecifications { };

        var values = ((string)value)
            .Split(',', StringSplitOptions.TrimEntries)
            .Select(str => TryConvert(str, out var intValue) ? (TValue?)intValue : null)
            .ToList();

        var specifications = new TSpecifications
        {
            Xs = values?.FirstOrDefault(),
            Sm = values?.Skip(1)?.FirstOrDefault(),
            Md = values?.Skip(2)?.FirstOrDefault(),
            Lg = values?.Skip(3)?.FirstOrDefault(),
            Xl = values?.Skip(4)?.FirstOrDefault(),
            Xxl = values?.Skip(5)?.FirstOrDefault()
        };

        return specifications;
    }

    private bool TryConvert(string str, out TValue value)
    {
        value = default;

        if (string.IsNullOrEmpty(str)) return false;

        var converter = TypeDescriptor.GetConverter(value);

        if (!converter.CanConvertFrom(typeof(string))) return false;

        try
        {
            var convertedValue = converter.ConvertFrom(str);

            if (convertedValue == null) return false;

            value = (TValue)convertedValue;

            return true;
        }
        catch
        {
            System.Diagnostics.Debug.WriteLine("Unable to convert string {string} to {type}", str, typeof(TValue));
            return false;
        }

    }

    public override object ConvertTo(ITypeDescriptorContext? context, CultureInfo? culture, object? value, Type destinationType)
    {
        if (value is not ResponsiveSpecifications<TValue> specs)
            throw new NotSupportedException();

        return $"{specs.Xs},{specs.Sm},{specs.Md},{specs.Lg},{specs.Xl},{specs.Xxl}";
    }
}

[TypeConverter(typeof(ResponsiveSpecificationsTypeConverter))]
public record ResponsiveSpecifications : ResponsiveSpecifications<int>
{ }

public class ResponsiveSpecificationsTypeConverter : ResponsiveSpecificationsTypeConverter<ResponsiveSpecifications, int>
{ }

