using Microsoft.Maui;
using Microsoft.Maui.Controls;

namespace My.Maui.Responsive.Extensions
{
    internal static class ViewExtensions
    {
        internal static int GetColumnSpan(this IView view) => Row.GetColumnSpan((BindableObject)view).Current;

        internal static int GetOrder(this IView view) => Row.GetOrder((BindableObject)view).Current;

        internal static int GetOffset(this IView view) => Row.GetOffset((BindableObject)view).Current;
    }
}
