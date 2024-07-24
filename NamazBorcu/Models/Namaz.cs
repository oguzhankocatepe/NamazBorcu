using System;

namespace NamazBorcu.Service
{
    public  class Namaz
    {
        public String Id { get; set; }
        public String Tarih{ get; set; }
        public int SabahSünnet { get; set; }
        public int SabahFarz { get; set; }
        public int ÖğleSünnet { get; set; }
        public int ÖğleFarz { get; set; }
        public int ÖğleSonSünnet { get; set; }
        public int İkindiSünnet { get; set; }
        public int İkindiFarz { get; set; }
        public int AkşamFarz { get; set; }
        public int AkşamSonSünnet { get; set; }
        public int YatsıSünnet { get; set; }
        public int YatsıFarz { get; set; }
        public int YatsıSonSünnet { get; set; }
        public int Vitr { get; set; }
        public int SabahToplam { get { return SabahSünnet + SabahFarz; } }
        public int ÖğleToplam { get { return ÖğleSünnet + ÖğleFarz + ÖğleSonSünnet; } }
        public int İkindiToplam { get { return İkindiSünnet + İkindiFarz; } }
        public int AkşamToplam{ get { return AkşamFarz + AkşamSonSünnet; } }
        public int YatsıToplam { get { return YatsıSünnet + YatsıFarz + YatsıSonSünnet + Vitr; } }
        public int SünnetToplam { get { return SabahSünnet + ÖğleSünnet + İkindiSünnet + YatsıSünnet ; } }
        public int FarzToplam { get { return SabahFarz + ÖğleFarz + İkindiFarz + AkşamFarz + YatsıFarz; } }
        public int SonSünnetToplam { get { return ÖğleSonSünnet + AkşamSonSünnet + YatsıSonSünnet; } }
        public int VitrToplam { get { return Vitr; } }
        public int GenelToplam { get { return SabahToplam + ÖğleToplam + İkindiToplam + AkşamToplam + YatsıToplam; } }

        public Namaz(String v1, String v2, int i1, int i2, int i3, int i4, int i5, int i6, int i7, int i8, int i9, int i10, int i11, int i12, int i13)
        {
            this.Id = v1;
            this.Tarih = v2;
            this.SabahSünnet = i1;
            this.SabahFarz = i2;
            this.ÖğleSünnet = i3;
            this.ÖğleFarz = i4;
            this.ÖğleSonSünnet = i5;
            this.İkindiSünnet = i6;
            this.İkindiFarz = i7;
            this.AkşamFarz = i8;
            this.AkşamSonSünnet = i9;
            this.YatsıSünnet = i10;
            this.YatsıFarz = i11;
            this.YatsıSonSünnet = i12;
            this.Vitr = i13;
        }

    }
}