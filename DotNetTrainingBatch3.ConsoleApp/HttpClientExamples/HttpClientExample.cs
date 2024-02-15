using DotNetTrainingBatch3.ConsoleApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetTrainingBatch3.ConsoleApp.HttpClientExamples
{
    public class HttpClientExample
    {
        public async Task Run()
        {
            await ReadAsync();
        }

        public async Task ReadAsync()
        {
            HttpClient client=new HttpClient();
            HttpResponseMessage response=await client.GetAsync("https://localhost:7131/api/Blog");
            if(response.IsSuccessStatusCode)
            {
                string jsonStr=await response.Content.ReadAsStringAsync();
                Console.WriteLine(jsonStr);


                List<BlogModel> list = JsonConvert.DeserializeObject<List< BlogModel >> (jsonStr); ;

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
        }
    }
}
