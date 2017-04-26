using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.UI.WebControls;

namespace Store.Web.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }

        [Required(ErrorMessage = "Product name is required")]
        [MaxLength(256,ErrorMessage = "Product name must be smaller than 256 characters.")]
        [Display(Name = "Product Name")]
        public string Name { get; set; }

        [Display(Name = "Specifications")]
        [MaxLength(5000, ErrorMessage = "Specifications must be smaller than 5000 characters.")]
        public string Specification { get; set; }

        [Display(Name = "Price")]
        [Required(ErrorMessage = "Price is required")]
        public double Price { get; set; }

        [DataType(DataType.Upload)]
        [Display(Name = "Upload Image")]
        public HttpPostedFileBase FileImage { get; set; }
    }
}
