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
            if (namaz != null)
            {
                SabahSünnet.Checked = namaz.SabahSünnet > 0;
                SabahFarz.Checked = namaz.SabahFarz > 0;
                ÖğleSünnet.Checked = namaz.ÖğleSünnet > 0;
                ÖğleFarz.Checked = namaz.ÖğleFarz > 0;
                ÖğleSonSünnet.Checked = namaz.ÖğleSonSünnet > 0;
                İkindiSünnet.Checked = namaz.İkindiSünnet > 0;
                İkindiFarz.Checked = namaz.İkindiFarz > 0;
                AkşamFarz.Checked = namaz.AkşamFarz > 0;
                AkşamSonSünnet.Checked = namaz.AkşamSonSünnet > 0;
                YatsıSünnet.Checked = namaz.YatsıSünnet > 0;
                YatsıFarz.Checked = namaz.YatsıFarz > 0;
                YatsıSonSünnet.Checked = namaz.YatsıSonSünnet > 0;
                Vitr.Checked = namaz.Vitr > 0;
                GenelToplam.Text = namaz.GenelToplam + "";
                SabahToplam.Text = namaz.SabahToplam + "";
                ÖğleToplam.Text = namaz.ÖğleToplam + "";
                İkindiToplam.Text = namaz.İkindiToplam + "";
                YatsıToplam.Text = namaz.YatsıToplam + "";
                AkşamToplam.Text = namaz.AkşamToplam + "";
                SünnetToplam.Text = namaz.SünnetToplam + "";
                FarzToplam.Text = namaz.FarzToplam + "";
                SonSünnetToplam.Text = namaz.SonSünnetToplam + "";
                VitrToplam.Text = namaz.VitrToplam + "";
            }
        }
    }
}