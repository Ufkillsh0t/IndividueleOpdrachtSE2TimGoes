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

        public bool RegistreerGebruiker(string naam, string email, string wachtwoord)
        {
            try
            {
                string sql = "SELECT GEBRUIKERSNAAM FROM GEBRUIKER";

                OracleCommand command = MaakOracleCommand(sql);

                string text = command.CommandText;

                OracleDataReader reader = VoerQueryUit(command);

                string test = reader["GEBRUIKERSNAAM"].ToString();

                return false;
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
    }
}