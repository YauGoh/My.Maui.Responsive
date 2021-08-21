using Microsoft.Maui;
using System;
using System.Collections.Generic;
using System.Text;

namespace My.Maui.Responsive.Layouts
{
    internal interface IContainerLayout : ILayout
    {
        IEnumerable<IView> GetOrderedVisibleRows();
    }
}
