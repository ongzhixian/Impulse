using System;

namespace Impulse.Web
{
    public class DummyWebClass
    {
        public DummyWebClass()
        {
        } // public DummyWebClass()

        public void DoWork()
        {
            Microsoft.AspNetCore.Html.HtmlString htmlString = new Microsoft.AspNetCore.Html.HtmlString("TestHtmlString");
        }
    }
}
