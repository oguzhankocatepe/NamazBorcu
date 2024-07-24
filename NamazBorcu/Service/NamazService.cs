using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace NamazBorcu.Service
{
    public static class NamazService
    {
        public static List<Namaz> Namazlar { get; }
        public static int NAMAZYOK = 0;
        public static int SABAHSUNNET = 2;
        public static int SABAHFARZ = 2;
        public static int OGLESUNNET = 4;
        public static int OGLEFARZ= 4;
        public static int OGLESONSUNNET = 2;
        public static int IKINDISUNNET = 4;
        public static int IKINDIFARZ = 4;
        public static int AKSAMFARZ = 3;
        public static int AKSAMSONSUNNET = 2;
        public static int YATSISUNNET = 4;
        public static int YATSIFARZ = 4;
        public static int YATSISONSUNNET = 2;
        public static int VITR = 3;
        public static int NAMAZFULL = SABAHSUNNET+ SABAHFARZ+ OGLESUNNET+ OGLEFARZ+ OGLESONSUNNET+ IKINDISUNNET+ IKINDIFARZ+ AKSAMFARZ+ AKSAMSONSUNNET+ YATSISUNNET+ YATSIFARZ+ YATSISONSUNNET+ VITR;


        static NamazService()
        {
            string connString = @"Server =.; Database = NAMAZBORCU; Trusted_Connection = True; TrustServerCertificate=True;";
            Namazlar = new List<Namaz>();
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = @"SELECT KULLANICI, TARIH, SABAHSUNNET, SABAHFARZ, OGLESUNNET, OGLEFARZ, OGLESONSUNNET, IKINDISUNNET, IKINDIFARZ, AKSAMFARZ, AKSAMSONSUNNET, YATSISUNNET, YATSIFARZ, YATSISONSUNNET, VITR FROM NAMAZ"; // GROUP BY KULLANICI,TARIH";
                //define the SqlCommand object
                SqlCommand cmd = new SqlCommand(query, conn);

                //open connection
                conn.Open();

                //execute the SQLCommand
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Namazlar.Add(new Namaz(dr.GetString(0), dr.GetString(1), dr.GetByte(2), dr.GetByte(3), dr.GetByte(4), dr.GetByte(5), dr.GetByte(6), dr.GetByte(7), dr.GetByte(8), dr.GetByte(9), dr.GetByte(10), dr.GetByte(11), dr.GetByte(12), dr.GetByte(13), dr.GetByte(14)));
                    }
                }
                //close data reader
                dr.Close();

                //close connection
                conn.Close();
            }
        }
    }
}