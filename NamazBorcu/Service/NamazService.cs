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
        public enum REKAT : int
        {
            NAMAZYOK = 0, SABAHSUNNET = 2, SABAHFARZ = 2, OGLESUNNET = 4, OGLEFARZ = 4, OGLESONSUNNET = 2, IKINDISUNNET = 4,
            IKINDIFARZ = 4, AKSAMFARZ = 3, AKSAMSONSUNNET = 2, YATSISUNNET = 4, YATSIFARZ = 4, YATSISONSUNNET = 2, VITR = 3, NAMAZFULL=40
        }
        static string connString = @"Server =.; Database = NAMAZBORCU; Trusted_Connection = True; TrustServerCertificate=True;";
        
        internal static List<Namaz> getNamazlar()
        {
            List<Namaz> Namazlar;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = @"SELECT KULLANICI, TARIH, SABAHSUNNET, SABAHFARZ, OGLESUNNET, OGLEFARZ, OGLESONSUNNET, IKINDISUNNET, IKINDIFARZ, AKSAMFARZ, AKSAMSONSUNNET, YATSISUNNET, YATSIFARZ, YATSISONSUNNET, VITR FROM NAMAZ"; // GROUP BY KULLANICI,TARIH";
                //define the SqlCommand object
                SqlCommand cmd = new SqlCommand(query, conn);

                //open connection
                conn.Open();
                Namazlar = new List<Namaz>();
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
                return Namazlar;
            }
        }
        internal static Namaz getNamaz(string day)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                Namaz namaz = null;
                string query = @"SELECT * FROM NAMAZ WHERE TARIH = '" + day + "'";
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
                        namaz = new Namaz(dr.GetString(0), dr.GetString(1), dr.GetByte(2), dr.GetByte(3), dr.GetByte(4), dr.GetByte(5), dr.GetByte(6), dr.GetByte(7), dr.GetByte(8), dr.GetByte(9), dr.GetByte(10), dr.GetByte(11), dr.GetByte(12), dr.GetByte(13), dr.GetByte(14));
                    }
                }
                //close data reader
                dr.Close();

                //close connection
                conn.Close();
                return namaz;
            }
        }
        internal static void UpdateNamaz(string v1, string v2, int v3)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = @"UPDATE NAMAZ SET "+v1+"="+v3+" WHERE TARIH='" + v2 + "'";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }


    }
}