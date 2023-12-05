using System.ComponentModel;

namespace HttpClientExample.Web.Models
{
    public class BrandViewModel
    {
        [DisplayName("Marka Numarası")]
        public int BrandId { get; set; }

        [DisplayName("Marka İsmi")]
        public string Name { get; set; }
    }
}
