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
            await Read();
        }

        private async Task Read()
        {
           
            var list = await refitApi.GetBlogs();


           
        }

        private async Task Edit(int id)
        {
            try
            {
                var item = await refitApi.GetBlog(1);
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
    }
}
