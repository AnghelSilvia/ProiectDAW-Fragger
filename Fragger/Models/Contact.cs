using System.ComponentModel.DataAnnotations.Schema;

namespace Fragger.Models
{
    public class Contact
    {
        public int ContactId { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public int BrandRef {  get; set; }
        public Brand Brand { get; set; }
    }
}
