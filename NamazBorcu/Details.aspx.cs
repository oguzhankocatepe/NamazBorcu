using NamazBorcu.Service;
using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NamazBorcu
{
    public partial class Details : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                getNamazDetail();
        }

        private void getNamazDetail()
        {
            string day = Request.QueryString["day"];
            Namaz namaz = NamazService.getNamaz(day);
            if (namaz != null)
            {
                SABAHSUNNET.Checked = namaz.SabahSünnet > 0;
                SABAHFARZ.Checked = namaz.SabahFarz > 0;
                OGLESUNNET.Checked = namaz.ÖğleSünnet > 0;
                OGLEFARZ.Checked = namaz.ÖğleFarz > 0;
                OGLESONSUNNET.Checked = namaz.ÖğleSonSünnet > 0;
                IKINDISUNNET.Checked = namaz.İkindiSünnet > 0;
                IKINDIFARZ.Checked = namaz.İkindiFarz > 0;
                AKSAMFARZ.Checked = namaz.AkşamFarz > 0;
                AKSAMSONSUNNET.Checked = namaz.AkşamSonSünnet > 0;
                YATSISUNNET.Checked = namaz.YatsıSünnet > 0;
                YATSIFARZ.Checked = namaz.YatsıFarz > 0;
                YATSISONSUNNET.Checked = namaz.YatsıSonSünnet > 0;
                VITR.Checked = namaz.Vitr > 0;
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

        protected void Namaz_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkbox = (CheckBox)sender;
            NamazService.UpdateNamaz(checkbox.ID, Request.QueryString["day"], checkbox.Checked ?(int) Enum.Parse(typeof(NamazService.REKAT),checkbox.ID) : (int)NamazService.REKAT.NAMAZYOK);
            getNamazDetail();
        }
    }
}