using NamazBorcu.Service;
using System;
using System.Linq;
using System.Web.UI;

namespace NamazBorcu
{
    public partial class Details : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string cday = Request.QueryString["day"];
            Namaz namaz = NamazService.Namazlar.Where(day => day.Tarih.Equals(cday)).FirstOrDefault();
            DetailsPanel.Controls.Add(new LiteralControl(namaz.Rekat+""));
        }
    }
}