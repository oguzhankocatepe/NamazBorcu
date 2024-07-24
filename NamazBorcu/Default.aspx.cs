using NamazBorcu.Service;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Calendar = System.Web.UI.WebControls.Calendar;

namespace NamazBorcu
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Table table = new Table();
            TableRow row = new TableRow();
            table.Rows.Add(row);
            CalendarPanel.Controls.Add(table);
            for (int i = 1; i <= 12; i++)
            {
                Calendar calendar = new Calendar();
                calendar.DayRender += Calendar_DayRender;
                calendar.SelectionChanged += Calendar_SelectionChanged;
                calendar.TodaysDate = DateTime.Today.AddMonths(-DateTime.Today.Month + i);
                TableCell cell = new TableCell();
                cell.Controls.Add(calendar);
                if (i == 7)
                {
                    row = new TableRow();
                    table.Rows.Add(row);
                }
                row.Cells.Add(cell);
            }

        }

        private void Calendar_SelectionChanged(object sender, EventArgs e)
        {
            Calendar calendar = (Calendar)sender;      
            String day = calendar.SelectedDate.Year + "-" + (calendar.SelectedDate.Month < 10 ? "0" : "") + calendar.SelectedDate.Month + "-" + (calendar.SelectedDate.Day < 10 ? "0" : "") + calendar.SelectedDate.Day;
            Response.Redirect("Details.aspx?Day=" + day);
        }

        private void Calendar_DayRender(object sender, DayRenderEventArgs e)
        {
            String cday = e.Day.Date.Year + "-" + (e.Day.Date.Month < 10 ? "0" : "") + e.Day.Date.Month + "-" + (e.Day.Date.Day < 10 ? "0" : "") + e.Day.Date.Day;
            Namaz namaz = NamazService.Namazlar.Where(day => day.Tarih.Equals(cday)).FirstOrDefault();
            if (namaz != null)
            {
                if (namaz.GenelToplam == NamazService.NAMAZYOK)
                    e.Cell.BackColor = Color.Red;
                else if (namaz.GenelToplam == NamazService.NAMAZFULL)
                    e.Cell.BackColor = Color.Green;
                else
                    e.Cell.BackColor = Color.Yellow;
            }
        }
    }
}