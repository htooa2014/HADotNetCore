using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using DotNetTrainingBatch3.ConsoleApp.Models;
using Dapper;
using System.Reflection.Metadata;

namespace DotNetTrainingBatch3.ConsoleApp.DapperExamples
{
    public class DapperExample
    {

        private readonly SqlConnectionStringBuilder sqlBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = "HA\\SQL2019",
            InitialCatalog = "TestDB",
            UserID = "sa",
            Password = "sasa"
        };

       
       
       
       public void Read()
        {
            string query = "select " +
             "blogId," +
             "BlogTitle," +
             "BlogAuthor," +
             "BlogContent from tbl_blog";

            using IDbConnection db = new SqlConnection(sqlBuilder.ConnectionString);
           List<BlogModel> list= db.Query<BlogModel>(query).ToList();

            foreach (BlogModel item in list)
            {
                Console.WriteLine(item.BlogId);
                Console.WriteLine(item.BlogTitle);
                Console.WriteLine(item.BlogAuthor);
                Console.WriteLine(item.BlogContent);
            }
           
        }

        public void Edit(int id)
        {
            BlogModel blog = new BlogModel()
            {
                BlogId = id
            };

            string query = @"SELECT [BlogId],[BlogTitle],[BlogAuthor],[BlogContent]
                        FROM [dbo].[Tbl_Blog] WHERE blogId=@BlogId";

            using IDbConnection db = new SqlConnection(sqlBuilder.ConnectionString);
            var item = db.Query<BlogModel>(query, blog).FirstOrDefault();
            if (item is null)
            {
                Console.WriteLine("No data found.");
                return;
            }

            Console.WriteLine(item.BlogId);
            Console.WriteLine(item.BlogTitle);
            Console.WriteLine(item.BlogAuthor);
            Console.WriteLine(item.BlogContent);


        }
       
        public void Create(string title, string author,string content)
        {
            string query = "INSERT INTO [dbo].[Tbl_Blog]([BlogTitle],[BlogAuthor],[BlogContent])  VALUES(@BlogTitle,@BlogAuthor,@BlogContent)";

            BlogModel blog = new BlogModel()
            {
                BlogTitle=title,
                BlogAuthor=author,
                BlogContent=content
            };
            using IDbConnection db = new SqlConnection(sqlBuilder.ConnectionString);
            int result = db.Execute(query, blog);
            string message = result > 0 ? "Saving Successful" : "Saving fail";
            Console.WriteLine(message);

        }

        public void Update(int Id, string title, string author, string content)
        {
            string query = @"UPDATE [dbo].[Tbl_Blog]
   SET [BlogTitle] = @BlogTitle
      ,[BlogAuthor] = @BlogAuthor
      ,[BlogContent] = @BlogContent
 WHERE BlogId=@BlogId";

            BlogModel blog = new BlogModel()
            {
                BlogId= Id,
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };
            using IDbConnection db = new SqlConnection(sqlBuilder.ConnectionString);
            int result = db.Execute(query, blog);
            string message = result > 0 ? "Update Successful" : "Update fail";
            Console.WriteLine(message);
        }

        public void Delete(int id)
        {
            BlogModel blog = new BlogModel()
            {
                BlogId = id
              
            };

            string query = @"DELETE from  [dbo].[Tbl_Blog]
    WHERE BlogId=@BlogId";

            using IDbConnection db = new SqlConnection(sqlBuilder.ConnectionString);
            int result = db.Execute(query, blog);
            string message = result > 0 ? "Delete Successful" : "Delete fail";
            Console.WriteLine(message);

        }

    }
}
