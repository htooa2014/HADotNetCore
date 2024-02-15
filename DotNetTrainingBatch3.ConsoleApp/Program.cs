// See https://aka.ms/new-console-template for more information
using DotNetTrainingBatch3.ConsoleApp.AdoDotNetExamples;
using DotNetTrainingBatch3.ConsoleApp.DapperExamples;
using DotNetTrainingBatch3.ConsoleApp.EFCoreExamples;
using DotNetTrainingBatch3.ConsoleApp.HttpClientExamples;
using System.Data;
using System.Data.SqlClient;

Console.WriteLine("Hello, World!");





//Console.ReadLine();

//Ctorl+ .
//F9 => Break point
// Shift + F5 => stop 

//#region Read
//SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
//sqlConnectionStringBuilder.DataSource = "HA\\SQL2019";
//sqlConnectionStringBuilder.InitialCatalog = "TestDB";
//sqlConnectionStringBuilder.UserID = "sa";
//sqlConnectionStringBuilder.Password = "sasa";

//string query = "select " +
//    "blogId," +
//    "BlogAuthor," +
//    "BlogContent from tbl_blog";
//SqlConnection sqlConnection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
//Console.WriteLine("Connection Opening ...");
//sqlConnection.Open();
//Console.WriteLine("Connection Opened ...");
//SqlCommand cmd = new SqlCommand(query, sqlConnection);
//SqlDataAdapter adapter = new SqlDataAdapter(cmd);
//DataTable dt=new DataTable();
//adapter.Fill(dt);


//Console.WriteLine("Connection Closing ...");
//sqlConnection.Close();
//Console.WriteLine("Connection Closed ...");


//foreach (DataRow dr in dt.Rows)
//{
//    //dataset
//    //datatable
//    //datarow
//    //datacolumn
//    Console.WriteLine("Id ..."+dr["BlogId"]);
//    Console.WriteLine("Title ..." + dr["BlogTitle"]);
//    Console.WriteLine("Author ..."+dr["BlogAuthor"]);
//    Console.WriteLine("Content ..." + dr["BlogContent"]);
//}
//#endregion




//F5
//////Ctrl+K , C
/// Ctrl + K , U
/// 
//install system.data.sqlClient

//UI, BL, DA => SQL - ADO.Net


//AdoDotNetExample adoDotNetExample = new AdoDotNetExample();
//Console.WriteLine("Read ...");
//adoDotNetExample.Read();
//Console.WriteLine("Edit ...");
//adoDotNetExample.Edit(1);
//Console.WriteLine("Create ...");
//adoDotNetExample.Create("title2", "author2", "content2");
//Console.WriteLine("Update ...");
//adoDotNetExample.Update(3,"title2", "author2", "content2");
//Console.WriteLine("Delete ...");
//adoDotNetExample.Delete(10);


//DapperExample dappterEx = new DapperExample();
//dappterEx.Read();
//dappterEx.Edit(1);
//dappterEx.Create("Title3","Author3","Content3");
//dappterEx.Update(2, "Title4", "Author4", "Content4");
//dappterEx.Delete(13);

//EFCoreExample eFCoreExample = new EFCoreExample();
//eFCoreExample.Read();
//eFCoreExample.Edit(1);
//eFCoreExample.Edit(122);
//eFCoreExample.Create("new title", "New author", "new content");
//eFCoreExample.Update(21, "211 title", "211 author", "211 content");
//eFCoreExample.Delete(9);
//eFCoreExample.Delete(223333333);

Console.WriteLine("Waiting for API ....");
Console.ReadKey();

HttpClientExample httpCClientExample =new HttpClientExample();
await httpCClientExample.Run();

Console.ReadKey();


