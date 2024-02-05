﻿// See https://aka.ms/new-console-template for more information
using System.Data;
using System.Data.SqlClient;

Console.WriteLine("Hello, World!");
//Console.ReadLine();

//Ctorl+ .
//F9 => Break point
// Shift + F5 => stop 

#region Read
SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
sqlConnectionStringBuilder.DataSource = "HA\\SQL2019";
sqlConnectionStringBuilder.InitialCatalog = "TestDB";
sqlConnectionStringBuilder.UserID = "sa";
sqlConnectionStringBuilder.Password = "sasa";

string query = "select * from tbl_blog";
SqlConnection sqlConnection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);

sqlConnection.Open();
SqlCommand cmd = new SqlCommand(query, sqlConnection);
SqlDataAdapter adapter = new SqlDataAdapter(cmd);
DataTable dt=new DataTable();
adapter.Fill(dt);



sqlConnection.Close();


foreach (DataRow dr in dt.Rows)
{
    //dataset
    //datatable
    //datarow
    //datacolumn
    Console.WriteLine(dr["BlogId"]);
    Console.WriteLine(dr["BlogTitle"]);
    Console.WriteLine(dr["BlogAuthor"]);
    Console.WriteLine(dr["BlogContent"]);
}
#endregion

Console.ReadKey();


//F5
//////Ctrl+K , C
/// Ctrl + K , U
/// 
//install system.data.sqlClient