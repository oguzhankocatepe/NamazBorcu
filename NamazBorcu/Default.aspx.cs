using NamazBorcu.Service;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NamazBorcu
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DateTime today = DateTime.Today;
        }
        protected void ThisMonth_DayRender(object sender, DayRenderEventArgs e)
        {
            String cday = e.Day.Date.Year + "-" + (e.Day.Date.Month < 10 ? "0" : "") + e.Day.Date.Month + "-" + (e.Day.Date.Day < 10 ? "0" : "") + e.Day.Date.Day;
            Namaz namaz = NamazService.Namazlar.Where(day => day.Tarih.Equals(cday)).FirstOrDefault();
            if (namaz != null)
            {
                if (namaz.Rekat == NamazService.NAMAZYOK)
                    e.Cell.BackColor = Color.Red;
                else if (namaz.Rekat == NamazService.NAMAZFULL)
                    e.Cell.BackColor = Color.Green;
                else
                    e.Cell.BackColor = Color.Yellow;
            }
        }

        protected void ThisMonth_SelectionChanged(object sender, EventArgs e)
        {
            String day = ThisMonth.SelectedDate.Year + "-" + (ThisMonth.SelectedDate.Month < 10 ? "0" : "") + ThisMonth.SelectedDate.Month + "-" + (ThisMonth.SelectedDate.Day < 10 ? "0" : "") + ThisMonth.SelectedDate.Day;
            Response.Redirect("Details.aspx?Day="+day);
        }
    }
}