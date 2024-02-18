using DotNetTrainingBatch3.ConsoleApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DotNetTrainingBatch3.ConsoleApp.HttpClientExamples
{
    public class HttpClientExample
    {
        public async Task Run()
        {
         //  await Read();
          // await Edit(1);
          // await Create("Today", "is ", "not tommrrow");
         //  await Update(47, "Tommorw", "Never", "Die");
        await Delete(45);


        }

        public async Task Read()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://localhost:7091/api/Blog");
            if (response.IsSuccessStatusCode)
            {
                string jsonStr = await response.Content.ReadAsStringAsync();
                Console.WriteLine(jsonStr);


                List<BlogModel> list = JsonConvert.DeserializeObject<List<BlogModel>>(jsonStr); ;

                //JsonConvert.SerializeObject()    // C# obj to json
                //JsonConvert.DeserializeObject()   // json to c# obj 


                foreach (BlogModel item in list)
                {
                    Console.WriteLine(item.BlogId);
                    Console.WriteLine(item.BlogTitle);
                    Console.WriteLine(item.BlogAuthor);
                    Console.WriteLine(item.BlogContent);
                }

            }
            else
            {
                Console.WriteLine(await response.Content.ReadAsStringAsync());
            }
        }

        public async Task Edit(int id)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync($"https://localhost:7091/api/Blog/{id}");
            if (response.IsSuccessStatusCode)
            {
                string jsonStr = await response.Content.ReadAsStringAsync();
              //  Console.WriteLine(jsonStr);


                BlogModel item = JsonConvert.DeserializeObject<BlogModel>(jsonStr); ;

                //JsonConvert.SerializeObject()    // C# obj to json
                //JsonConvert.DeserializeObject()   // json to c# obj 


              
                    Console.WriteLine(item.BlogId);
                    Console.WriteLine(item.BlogTitle);
                    Console.WriteLine(item.BlogAuthor);
                    Console.WriteLine(item.BlogContent);
              

            }
            else
            {
                Console.WriteLine(await response.Content.ReadAsStringAsync());
            }

        }

        public async Task Create(string title, string author, string body)
        {
            BlogModel model = new BlogModel()
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = body
            };
            string josnBlog=JsonConvert.SerializeObject(model);

            HttpClient client = new HttpClient();
            HttpContent content = new StringContent(josnBlog,Encoding.UTF8,MediaTypeNames.Application.Json);

            HttpResponseMessage response = await client.PostAsync("https://localhost:7091/api/Blog", content);
            if (response.IsSuccessStatusCode)
            {
              //  string jsonStr = await response.Content.ReadAsStringAsync();
               // Console.WriteLine(jsonStr);

                Console.WriteLine(await response.Content.ReadAsStringAsync());
            }
            else
            {
                Console.WriteLine(await response.Content.ReadAsStringAsync());
            }

        }

        public async Task Update(int id, string title, string author, string body)
        {
            BlogModel model = new BlogModel()
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = body
            };
            string josnBlog = JsonConvert.SerializeObject(model);

            HttpClient client = new HttpClient();
            HttpContent content = new StringContent(josnBlog, Encoding.UTF8, MediaTypeNames.Application.Json);

            HttpResponseMessage response = await client.PutAsync($"https://localhost:7091/api/Blog/{id}", content);
            if (response.IsSuccessStatusCode)
            {
                string jsonStr = await response.Content.ReadAsStringAsync();
              //  Console.WriteLine(jsonStr);


                Console.WriteLine(await response.Content.ReadAsStringAsync());

            }
            else
            {
                Console.WriteLine(await response.Content.ReadAsStringAsync());
            }

        }

        public async Task Delete(int id)
        {
            HttpClient client = new HttpClient(); 
            HttpResponseMessage response = await client.DeleteAsync($"https://localhost:7091/api/Blog/{id}");
            if (response.IsSuccessStatusCode)
            {
                string jsonStr = await response.Content.ReadAsStringAsync();


                Console.WriteLine(await response.Content.ReadAsStringAsync());

            }
            else
            {
                Console.WriteLine(await response.Content.ReadAsStringAsync());
            }

        }
    }
}
