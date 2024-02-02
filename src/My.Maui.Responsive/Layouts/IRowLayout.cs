namespace My.Maui.Responsive.Layouts;

internal interface IRowLayout : Microsoft.Maui.ILayout
{
    IEnumerable<IView> GetOrderedVisibleElements();

    int Columns { get; set; }
}
