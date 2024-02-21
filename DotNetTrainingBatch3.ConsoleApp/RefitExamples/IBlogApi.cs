using DotNetTrainingBatch3.ConsoleApp.Models;
using Microsoft.Identity.Client;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetTrainingBatch3.ConsoleApp.RefitExamples
{
    public interface IBlogApi
    {
        //must have / 
        [Get("/api/blog")]
        Task<List<BlogModel>> GetBlogs();

        [Get("/api/blog/id")]
        Task<List<BlogModel>> GetBlog(int id);
    }
}
