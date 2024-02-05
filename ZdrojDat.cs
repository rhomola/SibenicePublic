using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Sibenice
{
    /// <summary>
    /// třída sloužící k vytvoření pole vstupního slovníku pro hádání 
    /// </summary>
    class ZdrojDat
    {
        public string[] PoleSlov { get; set; }
        public string Uloziste { get; private set; }
        public string ConnectionString { get; private set; }
        public string Slova { get; private set; }



        public ZdrojDat(string uloziste, string connectionString, string slova)
        {
            Uloziste = uloziste;
            ConnectionString = connectionString;
            Slova = slova;

            NaplSlova(poleSlov);
        }



        // vytvoření lokálního uložiště slov
        private string[] poleSlov = new string[] { "Konopiště", "nádraží", "automobil", "lokomotiva", "kobyla", "traktor", "monitor", "instituce", "lékárna", "peněženka", "masokombinát", "opice", "škola", "koloběžka", "okurek", "abeceda" };




        public void NaplSlova(string[] poleSlov)
        {
            if (Uloziste == "interni")
            {
                PoleSlov = poleSlov;
            }
            else
            {
                NactiDatabazi();
            }
        }

        private void NactiDatabazi()
        {
            string sqlQuery = "";
            //var cs = "Host=localhost;Username=postgres;Password=admin;Database=Slovnik";
            // var cs = "postgresql://postgres:admin@localhost:5432/Slovnik";
            //var cs = "postgresql://postgres:admin@localhost:5432/mydb";
            // using var conection = new NpgsqlConnection(cs);

            using var connection = new NpgsqlConnection(ConnectionString);
            connection.Open();

            switch (Slova)
            {
                case "anglické":

                    sqlQuery = "SELECT anglicke_slovicko FROM slovnik_pro_sibenici " +
                    "WHERE length(anglicke_slovicko)>6 AND anglicke_slovicko NOT LIKE '% %' " +
                    " ORDER BY Random() LIMIT 100";

                    break;

                case "české":
                    sqlQuery = "SELECT ceske_slovicko FROM slovnik_pro_sibenici" +
                    " WHERE length(ceske_slovicko)>6 AND ceske_slovicko NOT LIKE '% %'" +
                    " ORDER BY Random() LIMIT 100";

                    break;

                case "česko-anglické":

                    sqlQuery = "WITH combined AS" +
                    " ((SELECT anglicke_slovicko AS slovicko FROM slovnik_pro_sibenici" +
                    "    WHERE (length(anglicke_slovicko) > 5) AND anglicke_slovicko NOT LIKE '% %')" +
                    "      UNION" +
                    "      (SELECT ceske_slovicko AS slovicko FROM slovnik_pro_sibenici" +
                    "     WHERE (length(ceske_slovicko) > 5 AND ceske_slovicko NOT LIKE '% %')))" +
                    "     SELECT slovicko FROM combined" +
                    "    ORDER BY RANDOM()" +
                    "     LIMIT 100";

                    break;

            }


            using var cmd = new NpgsqlCommand(sqlQuery, connection);

            using NpgsqlDataReader rdr = cmd.ExecuteReader();
            List<string> list = new List<string>();

            while (rdr.Read())

            {
                list.Add(rdr[0].ToString());

            }

            PoleSlov = list.ToArray();
        }




    }
}
