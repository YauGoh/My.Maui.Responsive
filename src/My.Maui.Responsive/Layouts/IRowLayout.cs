using Microsoft.Maui;
using System.Collections.Generic;

namespace My.Maui.Responsive.Layouts
{
    internal interface IRowLayout : ILayout
    {
        IEnumerable<IView> GetOrderedVisibleElements();

        int GetTotalColumns();
    }
}
