namespace My.Maui.Responsive.Layouts;

internal interface IContainerLayout : Microsoft.Maui.ILayout
{
    IEnumerable<IView> GetOrderedVisibleRows();
}