namespace HttpClientExample.Web.Models
{
    public class SinglelResponseModel<T> : ResponseModel
    {
        public T Data { get; set; }
    }
}
