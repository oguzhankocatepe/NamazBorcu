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
        List<Namaz> Namazlar = new List<Namaz>();
        protected void Page_Load(object sender, EventArgs e)
        {
            Namazlar = NamazService.getNamazlar();
            var years = Namazlar.Select(year => new {
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
            CalendarPanel.Controls.Add(new LiteralControl("KılınanFarz : " + (Namazlar.Sum(x => x.FarzToplam) + Namazlar.Sum(x => x.VitrToplam)) + "&nbsp"));
            CalendarPanel.Controls.Add(new LiteralControl("KılınanSünnet : " + (Namazlar.Sum(x => x.SünnetToplam) + Namazlar.Sum(x => x.SonSünnetToplam)) + "&nbsp"));
            CalendarPanel.Controls.Add(new LiteralControl("KılınanToplam : <font color=green> " + Namazlar.Sum(x => x.GenelToplam) + " </font> &nbsp"));
            CalendarPanel.Controls.Add(new LiteralControl("Kılınması Gereken : <font color=brown >" + Namazlar.Count * (int)NamazService.REKAT.FARZFULL + "(" + Namazlar.Count+ " Gün) </font> &nbsp"));
            CalendarPanel.Controls.Add(new LiteralControl("Namaz Borcu : <font color=red> <b><u>" + (Namazlar.Count * (int)NamazService.REKAT.FARZFULL - Namazlar.Sum(x => x.GenelToplam)) + " </b></u></font> &nbsp"));
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
            Namaz namaz = Namazlar.Where(day => day.Tarih.Equals(cday)).FirstOrDefault();
            if (namaz != null)
            {
                if (namaz.GenelToplam == (int)NamazService.REKAT.NAMAZYOK)
                    e.Cell.BackColor = Color.Red;
                else if (namaz.GenelToplam == (int)NamazService.REKAT.NAMAZFULL)
                    e.Cell.BackColor = Color.DarkGreen;
                else if (namaz.FarzToplam == (int)NamazService.REKAT.FARZFULL && namaz.GenelToplam > (int)NamazService.REKAT.FARZFULL)
                    e.Cell.BackColor = Color.Green;
                else if (namaz.FarzToplam == (int)NamazService.REKAT.FARZFULL)
                    e.Cell.BackColor = Color.LightGreen;
                else
                    e.Cell.BackColor = Color.Yellow;
            }
        }

        protected void AddFarzNamaz(object sender, EventArgs e)
        {
            NamazService.AddNamaz(addTextBox.Text);
            Response.Write("<script>alert('" + addTextBox.Text + " rekat nafile namaz kaza olarak eklenmiştir." + "')</script>");
            addTextBox.Text = "";
        }
    }
}