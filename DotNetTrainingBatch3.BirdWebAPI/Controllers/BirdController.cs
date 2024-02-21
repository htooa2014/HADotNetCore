using DotNetTrainingBatch3.BirdWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace DotNetTrainingBatch3.BirdWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BirdController : ControllerBase
    {
        private readonly string _url = "https://burma-project-ideas.vercel.app/birds";


        [HttpGet]
        public  async Task<IActionResult> Get () {

            HttpClient client = new HttpClient();
            var response=await client.GetAsync(_url);
            if(response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                List<BirdDataModel> birds = JsonConvert.DeserializeObject<List<BirdDataModel>>(json);
                List<BirdViewModel> lst=birds.Select(bird => ChangeModel(bird)).ToList();
                return Ok(lst);
            }
            else { return BadRequest(); }
           
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync($"{_url}/{id}");
            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                BirdDataModel birds = JsonConvert.DeserializeObject<BirdDataModel>(json);
                BirdViewModel item = ChangeModel(birds);
                return Ok(item);
            }
            else { return BadRequest(); }
        }


        private BirdViewModel ChangeModel(BirdDataModel bird)
        {
            BirdViewModel lst = new BirdViewModel()
            {
                BirdId = bird.Id,
                BirdName = bird.BirdMyanmarName,
                Desp = bird.Description,
                PhotoUrl = $"https://burma-project-ideas.vercel.app/birds/{bird.ImagePath}"
            };
            

            return lst;
        }

    }
}
