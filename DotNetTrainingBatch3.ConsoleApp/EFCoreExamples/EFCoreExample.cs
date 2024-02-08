using DotNetTrainingBatch3.ConsoleApp.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetTrainingBatch3.ConsoleApp.EFCoreExamples
{
    public class EFCoreExample
    {
        public void Read()
        {
            AppDBContext db = new AppDBContext();
            List<BlogModel> list = db.Blogs.ToList();

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
            AppDBContext db = new AppDBContext();
            BlogModel item = db.Blogs.Where(item => item.BlogId == id).FirstOrDefault();

            if(item == null)
            {
                Console.WriteLine("No Data Found.");
                return;
            }
           
                Console.WriteLine(item.BlogId);
                Console.WriteLine(item.BlogTitle);
                Console.WriteLine(item.BlogAuthor);
                Console.WriteLine(item.BlogContent);
            
        }

        public void Create(string blogTitle,string author,string content)
        {
            BlogModel item = new BlogModel()
            {
                BlogTitle = blogTitle,
                BlogAuthor = author,
                BlogContent = content
            };

            AppDBContext db=new AppDBContext();
            db.Blogs.Add(item);
            int result=db.SaveChanges();
            string message = result > 0 ? "Saving Successful" : "Saving fail";
            Console.WriteLine(message);
        }

        public void Update(int id,string blogTitle, string author, string content)
        {
           

            AppDBContext db = new AppDBContext();
            BlogModel item=db.Blogs.Where(item=>item.BlogId == id).FirstOrDefault();
            if (item == null)
            {
                Console.WriteLine("No Data Found");
                return;
            }


            item.BlogTitle = blogTitle;
            item.BlogAuthor = author;
            item.BlogContent = content;
           
           
            int result = db.SaveChanges();
            string message = result > 0 ? "Updating Successful" : "Updating fail";
            Console.WriteLine(message);
        }

        public void Delete(int id)
        {
            AppDBContext db = new AppDBContext();
            BlogModel item = db.Blogs.Where(item => item.BlogId == id).FirstOrDefault();
            if (item == null)
            {
                Console.WriteLine("No Data Found");
                return;
            }

            db.Blogs.Remove(item);
            int result = db.SaveChanges();
            string message = result > 0 ? "Deleting Successful" : "Deleting fail";
            Console.WriteLine(message);

        }
    }
}
