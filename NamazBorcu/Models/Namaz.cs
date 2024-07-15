using System;

namespace NamazBorcu.Service
{
    public  class Namaz
    {
        public String Id { get; set; }
        public String Tarih{ get; set; }
        public int Rekat { get; set; }
        public Namaz(String v1, String v2, int v3)
        {
            this.Id = v1;
            this.Tarih = v2;
            this.Rekat = v3;
        }

    }
}