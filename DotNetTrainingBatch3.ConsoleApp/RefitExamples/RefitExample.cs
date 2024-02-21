using DotNetTrainingBatch3.ConsoleApp.Models;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetTrainingBatch3.ConsoleApp.RefitExamples
{
    public class RefitExample
    {

        //private readonly string _apiUrl = "https://localhost:7091";
        private readonly IBlogApi refitApi = RestService.For<IBlogApi>("https://localhost:7091");

        public async Task Run()
        {
            //  await Read();
            //  await Edit(1);
            // await Edit(13333);
            //  await Create("Kyaw Kyaw", "is", "a student");
            //  await Update(1, "Meow Meow", "come","here !");
            await Delete(33);
        }

        private async Task Read()
        {
           
            var list = await refitApi.GetBlogs();

            foreach (BlogModel item in list)
            {
                Console.WriteLine(item.BlogId);
                Console.WriteLine(item.BlogTitle);
                Console.WriteLine(item.BlogAuthor);
                Console.WriteLine(item.BlogContent);
            }

        }

        private async Task Edit(int id)
        {
            try
            {
                var item = await refitApi.GetBlog(id);

                Console.WriteLine(item.BlogId);
                Console.WriteLine(item.BlogTitle);
                Console.WriteLine(item.BlogAuthor);
                Console.WriteLine(item.BlogContent);

            }
            catch(Refit.ApiException ex)
            {
                Console.WriteLine(ex.Content);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private async Task Create(string title,string author,string content) 
        {
            try
            {
                BlogModel blog = new BlogModel()
                {
                    BlogAuthor = author,
                    BlogContent = content,
                    BlogTitle = title
                };
                var result = await refitApi.CreateBlog(blog);

                Console.WriteLine(result);
            

            }
            catch (Refit.ApiException ex)
            {
                Console.WriteLine(ex.Content);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }


        private async Task Update(int id,string title, string author, string content)
        {
            try
            {
                BlogModel blog = new BlogModel()
                {
                    BlogAuthor = author,
                    BlogContent = content,
                    BlogTitle = title
                };
                var result = await refitApi.UpdateBlog(id,blog);

                Console.WriteLine(result);


            }
            catch (Refit.ApiException ex)
            {
                Console.WriteLine(ex.Content);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private async Task Delete(int id)
        {
            try
            {
                var result = await refitApi.DeleteBlog(id);

               
                Console.WriteLine(result);

            }
            catch (Refit.ApiException ex)
            {
                Console.WriteLine(ex.Content);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
