using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetTrainingBatch3.ConsoleApp.AdoDotNetExamples
{
    public class AdoDotNetExample
    {


        public void Read()
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            sqlConnectionStringBuilder.DataSource = "HA\\SQL2019";
            sqlConnectionStringBuilder.InitialCatalog = "TestDB";
            sqlConnectionStringBuilder.UserID = "sa";
            sqlConnectionStringBuilder.Password = "sasa";

            string query = "select " +
   "blogId," +
   "BlogTitle,"+
   "BlogAuthor," +
   "BlogContent from tbl_blog";
            SqlConnection sqlConnection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            Console.WriteLine("Connection Opening ...");
            sqlConnection.Open();
            Console.WriteLine("Connection Opened ...");
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);


            Console.WriteLine("Connection Closing ...");
            sqlConnection.Close();
            Console.WriteLine("Connection Closed ...");


            foreach (DataRow dr in dt.Rows)
            {
                //dataset
                //datatable
                //datarow
                //datacolumn
                Console.WriteLine("Id ..." + dr["BlogId"]);
                Console.WriteLine("Title ..." + dr["BlogTitle"]);
                Console.WriteLine("Author ..." + dr["BlogAuthor"]);
                Console.WriteLine("Content ..." + dr["BlogContent"]);
            }

        }

        public void Edit(int id)
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            sqlConnectionStringBuilder.DataSource = "HA\\SQL2019";
            sqlConnectionStringBuilder.InitialCatalog = "TestDB";
            sqlConnectionStringBuilder.UserID = "sa";
            sqlConnectionStringBuilder.Password = "sasa";

            string query = "select " +
   "blogId," +
   "BlogTitle,"+
   "BlogAuthor," +
   "BlogContent from tbl_blog";
            SqlConnection sqlConnection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            Console.WriteLine("Connection Opening ...");
            sqlConnection.Open();
            Console.WriteLine("Connection Opened ...");
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            cmd.Parameters.AddWithValue("@BlogId", id);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);


            Console.WriteLine("Connection Closing ...");
            sqlConnection.Close();
            Console.WriteLine("Connection Closed ...");


            foreach (DataRow dr in dt.Rows)
            {
                //dataset
                //datatable
                //datarow
                //datacolumn
                Console.WriteLine("Id ..." + dr["BlogId"]);
                Console.WriteLine("Title ..." + dr["BlogTitle"]);
                Console.WriteLine("Author ..." + dr["BlogAuthor"]);
                Console.WriteLine("Content ..." + dr["BlogContent"]);
            }
        }

        public void Create(string title, string author, string content)
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            sqlConnectionStringBuilder.DataSource = "HA\\SQL2019";
            sqlConnectionStringBuilder.InitialCatalog = "TestDB";
            sqlConnectionStringBuilder.UserID = "sa";
            sqlConnectionStringBuilder.Password = "sasa";

            string query = "INSERT INTO [dbo].[Tbl_Blog]([BlogTitle],[BlogAuthor],[BlogContent])  VALUES(@BlogTitle,@BlogAuthor,@BlogContent)";
            SqlConnection sqlConnection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            Console.WriteLine("Connection Opening ...");
            sqlConnection.Open();
            Console.WriteLine("Connection Opened ...");
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            cmd.Parameters.AddWithValue("@BlogTitle", title);
            cmd.Parameters.AddWithValue("@BlogAuthor", author);
            cmd.Parameters.AddWithValue("@BlogContent", content);

            int result = cmd.ExecuteNonQuery();
            //SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            //DataTable dt = new DataTable();
            //adapter.Fill(dt);


            Console.WriteLine("Connection Closing ...");
            sqlConnection.Close();
            Console.WriteLine("Connection Closed ...");

            string message = result > 0 ? "Saving Successful" : "Saving fail";
            Console.WriteLine(message);
        }


        public void Update(int id, string title, string author, string content)
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            sqlConnectionStringBuilder.DataSource = "HA\\SQL2019";
            sqlConnectionStringBuilder.InitialCatalog = "TestDB";
            sqlConnectionStringBuilder.UserID = "sa";
            sqlConnectionStringBuilder.Password = "sasa";

            string query = @"UPDATE [dbo].[Tbl_Blog]
   SET [BlogTitle] = @BlogTitle
      ,[BlogAuthor] = @BlogAuthor
      ,[BlogContent] = @BlogContent
 WHERE BlogId=@Id";
            SqlConnection sqlConnection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            Console.WriteLine("Connection Opening ...");
            sqlConnection.Open();
            Console.WriteLine("Connection Opened ...");
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.Parameters.AddWithValue("@BlogTitle", title);
            cmd.Parameters.AddWithValue("@BlogAuthor", author);
            cmd.Parameters.AddWithValue("@BlogContent", content);

            int result = cmd.ExecuteNonQuery();
            //SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            //DataTable dt = new DataTable();
            //adapter.Fill(dt);


            Console.WriteLine("Connection Closing ...");
            sqlConnection.Close();
            Console.WriteLine("Connection Closed ...");

            string message = result > 0 ? "Updating Successful" : "Updating fail";
            Console.WriteLine(message);
        }



        public void Delete(int id)
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            sqlConnectionStringBuilder.DataSource = "HA\\SQL2019";
            sqlConnectionStringBuilder.InitialCatalog = "TestDB";
            sqlConnectionStringBuilder.UserID = "sa";
            sqlConnectionStringBuilder.Password = "sasa";

            string query = @"DELETE from  [dbo].[Tbl_Blog]
    WHERE BlogId=@Id";
            SqlConnection sqlConnection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            Console.WriteLine("Connection Opening ...");
            sqlConnection.Open();
            Console.WriteLine("Connection Opened ...");
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            cmd.Parameters.AddWithValue("@Id", id);


            int result = cmd.ExecuteNonQuery();
            //SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            //DataTable dt = new DataTable();
            //adapter.Fill(dt);


            Console.WriteLine("Connection Closing ...");
            sqlConnection.Close();
            Console.WriteLine("Connection Closed ...");

            string message = result > 0 ? "Deleting Successful" : "Deleting fail";
            Console.WriteLine(message);
        }

    }
}