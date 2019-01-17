using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class DiscosRepository
    {

        private MySqlConnection Connect()
        {
            string connString = "Server=18.236.250.200;Port=3306;Database=musica;Uid=juanmi;password=juanmi.15;SslMode=none";
            MySqlConnection con = new MySqlConnection(connString);
            return con;
        }

        internal List<Disco> Retrieve()
        {

            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select * from discos";

            try
            {
                con.Open();
                MySqlDataReader res = command.ExecuteReader();

                Disco d = null;
                List<Disco> discos = new List<Disco>();
                while (res.Read())
                {
                    Debug.WriteLine("Recuperado: " + res.GetInt32(0) + " " + res.GetString(1) + " " + res.GetInt32(2) + " " + res.GetString(3));
                    d = new Disco(res.GetInt32(0), res.GetString(1), res.GetInt32(2), res.GetString(3));
                    discos.Add(d);
                }

                con.Close();
                return discos;
            }
            catch(MySqlException e)
            {
                Debug.WriteLine("Se ha producido un error de conexión");
                return null;
            }
        }

        internal List<Disco> RetrievebyYear(int anyo, int anyo2)
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select * from discos where anyo > @A and anyo < @A2";
            command.Parameters.AddWithValue("@A", anyo);
            command.Parameters.AddWithValue("@A2", anyo2);

            try
            {
                con.Open();
                MySqlDataReader res = command.ExecuteReader();

                Disco d = null;
                List<Disco> discos = new List<Disco>();
                while (res.Read())
                {
                    Debug.WriteLine("Recuperado: " + res.GetInt32(0) + " " + res.GetString(1) + " " + res.GetInt32(2) + " " + res.GetString(3));
                    d = new Disco(res.GetInt32(0), res.GetString(1), res.GetInt32(2), res.GetString(3));
                    discos.Add(d);
                }

                con.Close();
                return discos;
            }
            catch (MySqlException e)
            {
                Debug.WriteLine("Se ha producido un error de conexión");
                return null;
            }

        }

            internal void Save(Disco d)
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "insert into discos(titulo, anyo, grupo) values ('" + d.Titulo + "','" + d.Anyo + "','" + d.Grupo + "');";
            Debug.WriteLine("comando " + command.CommandText);
            try
            {
                con.Open();
                command.ExecuteNonQuery();
                con.Close();
            }
            catch (MySqlException e)
            {
                Debug.WriteLine("Se ha producido un error de conexión");
            }

        }


    }
}