using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace Toolbox.ASPMVC.HtmlHelpers
{
    public static class HtmlHelperExtensions
    {
        public static IHtmlContent HTag(this IHtmlHelper html, int titleLevel, string content)
        {
            return new HtmlString($"<h{titleLevel}>{content}</h{titleLevel}>");
        }

        public static IHtmlContent NumericTable(this IHtmlHelper html, int rows, int cells)
        {
            string result = "<table><tbody>";
            for (int i = 0; i < rows; i++)
            {
                result += "<tr>";
                for (int j = 0; j < cells; j++)
                {
                    result += $"<td>{(i*cells)+j}</td>";
                }
                result += "</tr>";
            }
            result += "</tbody></table>";
            return new HtmlString(result);
        }

        public static IDisposable BeginNavBar(this IHtmlHelper html)
        {
            html.ViewContext.Writer.WriteLine("<nav><ul>");
            return new DisposableHtmlHelper(html.EndingNavBar);
        }

        private static void EndingNavBar(this IHtmlHelper html)
        {
            html.ViewContext.Writer.WriteLine("</ul></nav>");
        }

        public static IHtmlContent NavBarItem(this IHtmlHelper html,string content, string link)
        {
            return new HtmlString($"<li><a href=\"{link}\"><div>{content}</div></a></li>");
        }
    }
}
