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
        public static int NAMAZFULL = 13;
        static NamazService()
        {
            string connString = @"Server =.; Database = NAMAZBORCU; Trusted_Connection = True; TrustServerCertificate=True;";
            Namazlar = new List<Namaz>();
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = @"SELECT KULLANICI,TARIH, SUM(SABAHFARZ+SABAHSUNNET) FROM NAMAZ GROUP BY  KULLANICI,TARIH";
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
                        Namazlar.Add(new Namaz(dr.GetString(0), dr.GetString(1), dr.GetInt32(2)));
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