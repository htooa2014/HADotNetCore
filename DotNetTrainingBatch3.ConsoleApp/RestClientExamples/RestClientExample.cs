using DotNetTrainingBatch3.ConsoleApp.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace DotNetTrainingBatch3.ConsoleApp.RestClientExamples
{
    public class RestClientExample
    {
        private readonly string _api_url = "https://localhost:7091/api/Blog";
        public async Task Run()
        {
             await Read();
            //  await Edit(1);
          //  await Edit(1444);
             // await Create("What ", "is ", "your name");
           //  await Update(48, "Where", "are ", "you from?");
            //  await Delete(48);


        }

        public async Task Read()
        {
            RestRequest request= new RestRequest(_api_url,Method.Get);
            RestClient client = new RestClient();
            RestResponse response=await client.ExecuteAsync(request);
           
            if (response.IsSuccessStatusCode)
            {
                string jsonStr = response.Content!;
              //  Console.WriteLine(jsonStr);


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
                Console.WriteLine(response.Content!);
            }
        }

        public async Task Edit(int id)
        {
          
            
            RestRequest request = new RestRequest($"{_api_url}/{id}", Method.Get);
            RestClient client = new RestClient();
            RestResponse response = await client.ExecuteAsync(request);

            if (response.IsSuccessStatusCode)
            {
                string jsonStr =  response.Content!;
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
                Console.WriteLine(response.Content!);
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
          


            RestRequest request = new RestRequest(_api_url, Method.Post);
            request.AddJsonBody(model);

            RestClient client = new RestClient();
            RestResponse response = await client.ExecuteAsync(request);
             
            

            
            if (response.IsSuccessStatusCode)
            {
                //  string jsonStr = await response.Content.ReadAsStringAsync();
                // Console.WriteLine(jsonStr);

                Console.WriteLine(response.Content!);
            }
            else
            {
                Console.WriteLine(response.Content!);
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

            RestRequest request = new RestRequest($"{_api_url}/{id}", Method.Put);
            request.AddJsonBody(model);

            RestClient client = new RestClient();
            RestResponse response = await client.ExecuteAsync(request);

            if (response.IsSuccessStatusCode)
            {
                string jsonStr = response.Content!;
                //  Console.WriteLine(jsonStr);


                Console.WriteLine(response.Content!);

            }
            else
            {
                Console.WriteLine(response.Content!);
            }

        }

        public async Task Delete(int id)
        {


            RestRequest request = new RestRequest($"{_api_url}/{id}", Method.Delete);
            RestClient client = new RestClient();
            RestResponse response = await client.ExecuteAsync(request);

            if (response.IsSuccessStatusCode)
            {
                string jsonStr = response.Content!;


                Console.WriteLine(response.Content!);

            }
            else
            {
                Console.WriteLine(response.Content!);
            }

        }
    }
}
