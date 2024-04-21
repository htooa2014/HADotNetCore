namespace DotNetTrainingBatch3.WebAPI.Models
{
    public class BlogResponseModel
    {
        public int PageNumber { get; set; }
        public int PageSize {  get; set; }

        public int PageCount { get; set; }
        public bool IsEndOfPage => PageNumber == PageCount;
        public List<BlogModel> Data { get; set; }

    }
}
