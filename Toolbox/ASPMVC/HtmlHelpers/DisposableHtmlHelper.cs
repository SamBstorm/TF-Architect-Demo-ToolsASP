using System;
using System.Collections.Generic;
using System.Text;

namespace Toolbox.ASPMVC.HtmlHelpers
{
    internal class DisposableHtmlHelper : IDisposable
    {
        private readonly Action _endAction;

        public DisposableHtmlHelper(Action endAction)
        {
            _endAction = endAction;
        }

        public void Dispose()
        {
            _endAction();
        }
    }
}
