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
        ListBox listBox = new ListBox();
        protected void Page_Load(object sender, EventArgs e)
        {
            var years = NamazService.Namazlar.Select(year => new {
                Value = Int32.Parse(year.Tarih.Substring(0, 4)) - DateTime.Today.Year,
                Year = year.Tarih.Substring(0, 4)
            }).Distinct().OrderByDescending(x => x.Year).ToList();
            listBox.DataSource = years;
            listBox.DataTextField = "Year";
            listBox.DataValueField = "Value";
            listBox.DataBind();
            listBox.AutoPostBack = true;
            listBox.EnableViewState = false;
            listBox.SelectedIndexChanged += ListBox_SelectedIndexChanged;
            CalendarPanel.Controls.Add(listBox);
            if (!Page.IsPostBack)
            {
                listBox.SelectedIndex = 0;
                ListBox_SelectedIndexChanged(listBox, null);
            }
        }

        private void ListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Table table = new Table();
            TableRow row = new TableRow();
            table.Rows.Add(row);
            CalendarPanel.Controls.Add(table);
            for (int i = 1; i <= new System.Globalization.GregorianCalendar().GetMonthsInYear(DateTime.Today.Year); i++)
            {
                Calendar calendar = new Calendar();
                calendar.DayRender += Calendar_DayRender;
                calendar.SelectionChanged += Calendar_SelectionChanged;
                calendar.TodaysDate = DateTime.Today.AddMonths(-DateTime.Today.Month + i);
                calendar.TodaysDate = calendar.TodaysDate.AddYears(Int32.Parse(listBox.SelectedItem.Value));
                calendar.ToolTip = calendar.TodaysDate.ToString("MMM", CultureInfo.CreateSpecificCulture("tr"));
                TableCell cell = new TableCell();
                cell.Controls.Add(calendar);
                if (i == new System.Globalization.GregorianCalendar().GetMonthsInYear(DateTime.Today.Year) / 2 + 1)
                {
                    row = new TableRow();
                    table.Rows.Add(row);
                }
                row.Cells.Add(cell);
            }
            CalendarPanel.Controls.Add(new LiteralControl("KılınanFarz : " + (NamazService.Namazlar.Sum(x => x.FarzToplam) + NamazService.Namazlar.Sum(x => x.VitrToplam))));
            CalendarPanel.Controls.Add(new LiteralControl("KılınanSünnet : " + (NamazService.Namazlar.Sum(x => x.SünnetToplam) + NamazService.Namazlar.Sum(x => x.SonSünnetToplam))));
            CalendarPanel.Controls.Add(new LiteralControl("KılınanToplam : " + NamazService.Namazlar.Sum(x => x.GenelToplam)));
            CalendarPanel.Controls.Add(new LiteralControl("Kılınması Gereken : " + NamazService.Namazlar.Count * NamazService.NAMAZFULL));
            CalendarPanel.Controls.Add(new LiteralControl("Namaz Borcu : " + (NamazService.Namazlar.Count * NamazService.NAMAZFULL - NamazService.Namazlar.Sum(x => x.GenelToplam))));
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