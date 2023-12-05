namespace HttpClientExample.Web.Models
{
    public class BrandListResponseModel
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public List<BrandViewModel> Data { get; set; }
    }
}
