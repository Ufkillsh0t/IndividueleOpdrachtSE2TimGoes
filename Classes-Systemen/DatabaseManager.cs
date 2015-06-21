using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Oracle.DataAccess.Client;

namespace IndividueleOpdrachtSE2
{
    public class DatabaseManager
    {
        public string PCN;
        public string Wachtwoord;
        public OracleConnection Verbinding;

        public DatabaseManager()
        {
            this.PCN = "dbi322878";
            this.Wachtwoord = "YB4G0mfwlX";

            Verbinding = new OracleConnection();

            Verbinding.ConnectionString = "User Id=" + this.PCN + ";Password=" + this.Wachtwoord + ";Data Source=" + "//192.168.15.50:1521/fhictora;";
        }

        /// <summary>
        /// Retourneert een instantie van OracleCommand met
        /// this.Verbinding & .CommandType.Text
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public OracleCommand MaakOracleCommand(string sql)
        {
            OracleCommand command = new OracleCommand(sql, this.Verbinding);
            command.CommandType = System.Data.CommandType.Text;

            return command;
        }

        /// <summary>
        /// Voert de query uit van meegegeven OracleCommand.
        /// Deze OracleCommand moet gemaakt zijn door MaakOracleCommand() en parameters moeten al ingesteld zijn.
        /// De teruggegeven lijst bevat voor elke rij een OracleDataReader.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public OracleDataReader VoerMultiQueryUit(OracleCommand command)
        {
            try
            {
                Verbinding.Open();

                OracleDataReader reader = command.ExecuteReader();

                return reader;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Voert de query uit van meegegeven OracleCommand.
        /// Deze OracleCommand moet gemaakt zijn door MaakOracleCommand() en parameters moeten al ingesteld zijn.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public OracleDataReader VoerQueryUit(OracleCommand command)
        {
            try
            {
                if (Verbinding.State == ConnectionState.Closed)
                {
                    Verbinding.Open();
                }

                OracleDataReader reader = command.ExecuteReader();

                reader.Read();

                return reader;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Voert een Delete, Update of Insert query uit op de database.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public bool VoerNonQueryUit(OracleCommand command)
        {
            try
            {
                if (Verbinding.State == ConnectionState.Closed)
                {
                    Verbinding.Open();
                }

                command.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Registreert een gebruiker in de database.
        /// </summary>
        /// <param name="naam"></param>
        /// <param name="wachtwoord"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        public bool RegistreerGebruiker(string naam, string wachtwoord, string email)
        {
            try
            {
                string sql = "INSERT INTO GEBRUIKER (ID, GEBRUIKERSNAAM, WACHTWOORD, EMAIL, REGISTRATIEDATUM) VALUES (:ID, :GEBRUIKERSNAAM, :WACHTWOORD, :EMAIL, :REGISTRATIEDATUM)";

                OracleCommand command = MaakOracleCommand(sql);

                command.Parameters.Add(":ID", VerkrijgNieuwGebruikerID());
                command.Parameters.Add(":GEBRUIKERSNAAM", naam);
                command.Parameters.Add(":WACHTWOORD", wachtwoord);
                command.Parameters.Add(":EMAIL", email);
                command.Parameters.Add(":REGISTRATIEDATUM", DateTime.Now);

                VoerNonQueryUit(command);
                
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                Verbinding.Close();
            }
        }

        /// <summary>
        /// Verkrijgt een nieuw gebruikers ID, zodat een nieuwe gebruiker in de database kan worden geplaatst.
        /// </summary>
        /// <returns></returns>
        public int VerkrijgNieuwGebruikerID()
        {
            try
            {
                string sql = "SELECT MAX(ID) AS ID FROM GEBRUIKER";

                OracleCommand command = MaakOracleCommand(sql);

                string text = command.CommandText;

                OracleDataReader reader = VoerQueryUit(command);

                return Convert.ToInt32(reader["ID"].ToString()) + 1;
            }
            catch
            {
                return -1;
            }
            finally
            {
                Verbinding.Close();
            }
        }

        /// <summary>
        /// Verkrijgt het HashWachtwoord van een account.
        /// </summary>
        /// <param name="gebruikersnaam"></param>
        /// <returns></returns>
        public string VerkrijgWachtwoord(string gebruikersnaam)
        {
            try
            {
                string sql = "SELECT WACHTWOORD FROM GEBRUIKER WHERE GEBRUIKERSNAAM = :GEBRUIKERSNAAM";

                OracleCommand command = MaakOracleCommand(sql);

                command.Parameters.Add(":GEBRUIKERSNAAM", gebruikersnaam);

                string text = command.CommandText;

                OracleDataReader reader = VoerQueryUit(command);

                return reader["WACHTWOORD"].ToString();
            }
            catch
            {
                return null;
            }
            finally
            {
                Verbinding.Close();
            }
        }

        public List<Categorie> VerkrijgHoofdCategorieen()
        {
            try
            {
                string sql = "SELECT ID, NAAM FROM CATEGORIE WHERE CAT_ID IS NULL";

                OracleCommand command = MaakOracleCommand(sql);

                OracleDataReader reader = VoerMultiQueryUit(command);

                List<Categorie> hoodCategorieen = new List<Categorie>();

                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["ID"]);
                    string naam = reader["NAAM"].ToString();

                    hoodCategorieen.Add(new Categorie(id, naam));
                }

                return hoodCategorieen;

            }
            catch
            {
                return null;
            }
            finally
            {
                Verbinding.Close();
            }
        }

        public List<Categorie> VerkrijgSubCategorieen(Categorie cat)
        {
            try
            {
                string sql = "SELECT ID, NAAM FROM CATEGORIE WHERE CAT_ID = :ID";

                OracleCommand command = MaakOracleCommand(sql);

                command.Parameters.Add(":ID", cat.ID);

                OracleDataReader reader = VoerMultiQueryUit(command);

                List<Categorie> hoodCategorieen = new List<Categorie>();

                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["ID"]);
                    string naam = reader["NAAM"].ToString();

                    hoodCategorieen.Add(new Categorie(id, cat, naam));
                }

                return hoodCategorieen;

            }
            catch
            {
                return null;
            }
            finally
            {
                Verbinding.Close();
            }
        }

        public List<Productgroep> VerkrijgProductGroepen(Categorie cat)
        {
            try
            {
                string sql = "SELECT ID, NAAM, PLAATJE FROM PRODUCTGROEP WHERE CATEGORIE_ID = :ID";

                OracleCommand command = MaakOracleCommand(sql);

                command.Parameters.Add(":ID", cat.ID);

                OracleDataReader reader = VoerMultiQueryUit(command);

                List<Productgroep> productGroepen = new List<Productgroep>();

                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["ID"]);
                    string naam = reader["NAAM"].ToString();
                    string plaatje = reader["PLAATJE"].ToString();

                    productGroepen.Add(new Productgroep(id, naam, plaatje));
                }

                return productGroepen;

            }
            catch
            {
                return null;
            }
            finally
            {
                Verbinding.Close();
            }
        }

        public Productgroep VerkrijgProductGroep(int productGroepID)
        {
            try
            {
                string sql = "SELECT ID, CATEGORIE_ID, NAAM, PLAATJE FROM PRODUCTGROEP WHERE ID = :ID";

                OracleCommand command = MaakOracleCommand(sql);

                command.Parameters.Add(":ID", productGroepID);

                OracleDataReader reader = VoerQueryUit(command);

                int id = Convert.ToInt32(reader["ID"]);
                string naam = reader["NAAM"].ToString();
                string plaatje = reader["PLAATJE"].ToString();
                Categorie cat = VerkrijgCategorie(Convert.ToInt32(reader["CATEGORIE_ID"]));

                Productgroep productGroep = new Productgroep(id, cat, naam, plaatje);
                return productGroep;

            }
            catch
            {
                return null;
            }
            finally
            {
                Verbinding.Close();
            }
        }

        public List<Specificatiesoort> VerkrijgSpecificatieSoorten(Productgroep productGroep)
        {
            try
            {
                string sql = "SELECT ID, NAAM FROM SPECIFICATIESOORT WHERE PRODUCTGROEP_ID = :ID";

                OracleCommand command = MaakOracleCommand(sql);

                command.Parameters.Add(":ID", productGroep.ID);

                OracleDataReader reader = VoerMultiQueryUit(command);

                List<Specificatiesoort> specificatieSoorten = new List<Specificatiesoort>();

                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["ID"]);
                    string naam = reader["NAAM"].ToString();

                    specificatieSoorten.Add(new Specificatiesoort(id, productGroep, naam));
                }

                return specificatieSoorten;

            }
            catch
            {
                return null;
            }
            finally
            {
                Verbinding.Close();
            }
        }

        public Categorie VerkrijgCategorie(int catID)
        {
            try
            {
                string sql = "SELECT ID, NAAM FROM CATEGORIE WHERE ID = :ID";

                OracleCommand command = MaakOracleCommand(sql);

                command.Parameters.Add(":ID", catID);

                OracleDataReader reader = VoerQueryUit(command);

                int id = Convert.ToInt32(reader["ID"]);
                string naam = reader["NAAM"].ToString();
                Categorie cat = new Categorie(id, naam);

                return cat;
            }
            catch
            {
                return null;
            }
            finally
            {
                Verbinding.Close();
            }
        }


        public List<Product> VekrijgProducten(int productGroepID)
        {
            try
            {
                string sql = "SELECT ID, NAAM, MERK, TESTDATUM FROM PRODUCT WHERE PRODUCTGROEP_ID = :ID";

                OracleCommand command = MaakOracleCommand(sql);

                command.Parameters.Add(":ID", productGroepID);

                OracleDataReader reader = VoerMultiQueryUit(command);

                List<Product> producten = new List<Product>();

                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["ID"]);
                    string naam = reader["NAAM"].ToString();
                    string merk = reader["MERK"].ToString();
                    DateTime testDatum = Convert.ToDateTime(reader["TESTDATUM"]);

                    producten.Add(new Product(id, naam, merk, testDatum));
                }

                return producten;

            }
            catch
            {
                return null;
            }
            finally
            {
                Verbinding.Close();
            }
        }

        public Product VerkrijgProduct(int productID)
        {
            try
            {
                string sql = "SELECT ID, PRODUCTGROEP_ID, EANCODE, CODE, NAAM, MERK, TESTDATUM, PLAATJE, FABRIKANTSITE FROM PRODUCT WHERE ID = :ID";

                OracleCommand command = MaakOracleCommand(sql);

                command.Parameters.Add(":ID", productID);

                OracleDataReader reader = VoerQueryUit(command);

                int id = Convert.ToInt32(reader["ID"]);
                Productgroep productGroep = VerkrijgProductProductGroep(Convert.ToInt32(reader["PRODUCTGROEP_ID"]));
                string eancode = reader["EANCODE"].ToString();
                string code = reader["CODE"].ToString();
                string naam = reader["NAAM"].ToString();
                string merk = reader["MERK"].ToString();
                DateTime testDatum = Convert.ToDateTime(reader["TESTDATUM"]);
                string plaatje = reader["PLAATJE"].ToString();
                string fabrikantsite = reader["FABRIKANTSITE"].ToString();

                Product prod = new Product(id, productGroep, eancode, code, naam, merk, testDatum, plaatje, fabrikantsite);

                return prod;
            }
            catch
            {
                return null;
            }
            finally
            {
                Verbinding.Close();
            }
        }

        public Productgroep VerkrijgProductProductGroep(int productGroepID)
        {
            try
            {
                string sql = "SELECT ID, NAAM, PLAATJE FROM PRODUCTGROEP WHERE ID = :ID";

                OracleCommand command = MaakOracleCommand(sql);

                command.Parameters.Add(":ID", productGroepID);

                OracleDataReader reader = VoerQueryUit(command);

                int id = Convert.ToInt32(reader["ID"]);
                string naam = reader["NAAM"].ToString();
                string plaatje = reader["PLAATJE"].ToString();

                Productgroep productGroep = new Productgroep(id, naam, plaatje);
                return productGroep;
            }
            catch
            {
                return null;
            }
        }

        public List<Specificatie> VerkrijgSpecificaties(int productID)
        {
            try
            {
                string sql = "SELECT ss.ID AS SPECIFICATIESOORT_ID, ss.NAAM AS SPECIFICATIESOORT, s.ID AS SPECIFICATIE_ID, s.NAAM AS SPECIFICATIE, s.OMSCHRIJVING AS OMSCHRIJVING, ps.WAARDE AS WAARDE"
                           + " FROM PRODUCT p, PRODUCTSPECIFICATIE ps"
                           + " INNER JOIN SPECIFICATIE s"
                           + " ON s.ID = ps.SPECIFICATIE_ID"
                           + " INNER JOIN SPECIFICATIESOORT ss"
                           + " ON ss.ID = s.SPECIFICATIESOORT_ID"
                           + " WHERE ps.PRODUCT_ID = p.ID"
                           + " AND p.ID = :ID";

                OracleCommand command = MaakOracleCommand(sql);

                command.Parameters.Add(":ID", productID);

                OracleDataReader reader = VoerMultiQueryUit(command);

                List<Specificatie> specificaties = new List<Specificatie>();

                while (reader.Read())
                {
                    int specificatiesoortID = Convert.ToInt32(reader["SPECIFICATIESOORT_ID"]);
                    string specificatiesoort = reader["SPECIFICATIESOORT"].ToString();
                    int specificatieID = Convert.ToInt32(reader["SPECIFICATIE_ID"]);
                    string specificatie = reader["SPECIFICATIE"].ToString();
                    string omschrijving = reader["OMSCHRIJVING"].ToString();
                    string waarde = reader["WAARDE"].ToString();

                    specificaties.Add(new Specificatie(specificatieID, new Specificatiesoort(specificatiesoortID, specificatiesoort), specificatie, omschrijving, waarde));
                }

                return specificaties;
            }
            catch
            {
                return null;
            }
            finally
            {
                Verbinding.Close();
            }
        }
    }
}