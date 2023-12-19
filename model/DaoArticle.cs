using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace model
{
    public class DaoArticle
    {

       

        public List<Article> SelectByPrixBetween(int reference, double prix)
        {
            List<Article> articles = new List<Article>();
            string connectionString = @"Data Source=DESKTOP-SU8Q4QI;Initial Catalog=cs-db;Integrated Security=True";
            string sql = "SELECT * FROM articles WHERE prix BETWEEN @Reference AND @Top";


            SqlConnection connexion = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(sql, connexion);

            connexion.Open();

            command.Parameters.Add("Reference", SqlDbType.Int).Value = reference;
            command.Parameters.Add("Top", SqlDbType.NVarChar).Value = prix;

            SqlDataReader reader = command.ExecuteReader();


            while (reader.Read())
            {
                Article a = new Article(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2));
                articles.Add(a);

            }

            connexion.Close();
            return articles;


        }


        public bool Insert(Article a)
        {
            string connectionString = @"Data Source=DESKTOP-SU8Q4QI;Initial Catalog=cs-db;Integrated Security=True";
            string sql = "insert into articles values(@reference, @marque, @prix)";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(sql, connection);
            connection.Open();
            command.CommandText = sql;

            command.Parameters.Add("reference", SqlDbType.Int).Value = a.Reference;
            command.Parameters.Add("marque", SqlDbType.NVarChar).Value = a.Marque;
            command.Parameters.Add("prix", SqlDbType.NVarChar).Value = a.Prix;

            command.ExecuteNonQuery();
            connection.Close();
            return true;

        }


       public Article SelectByReference(int reference)
       {
            Article article = null;
            string connectionString = @"Data Source=DESKTOP-SU8Q4QI;Initial Catalog=cs-db;Integrated Security=True";
            string sql = " select * from articles where reference=" + reference;
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(sql, connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())

                article = new Article(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2));


            connection.Close();

            return article;


        }

        public List<Article> SelectAll()
        {
            List<Article> list = new List<Article>();

            string connectionString = @"Data Source=DESKTOP-SU8Q4QI;Initial Catalog=cs-db;Integrated Security=True";
            string sql = "select * from articles";
            SqlConnection connexion = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(sql, connexion);

            connexion.Open();

            SqlDataReader reader = command.ExecuteReader();


            while (reader.Read())
            {
                Article a = new Article(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2));
                list.Add(a);

            }


            connexion.Close();
            return list;
        }


    }
}
