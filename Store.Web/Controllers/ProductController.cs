using System.IO;
using System.Web.Mvc;
using AutoMapper;
using Store.Web.Models;
using Store.Web.ProductService;
using Store.Web.Security;

namespace Store.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductServiceClient productServiceClient;

        public ProductController(ProductServiceClient productServiceClient)
        {
            this.productServiceClient = productServiceClient;
        }

        [HttpGet]
        [AuthorizeUsers(RequireAdmin = true)]
        // GET: Product
        public ActionResult Edit(int? id)
        {
            if (id.HasValue)
            {
                var product = productServiceClient.GetProductById(id.Value);
                if (product != null)
                {
                    var productViewMdoel = Mapper.Map<ProductViewModel>(product);
                    return View(productViewMdoel);
                }
            }
            return View(new ProductViewModel {Id = 0});
        }

        [HttpPost]
        [AuthorizeUsers(RequireAdmin = true)]
        public ActionResult Edit(ProductViewModel productViewModel)
        {
            if (ModelState.IsValid)
            {
                if (productViewModel.Id <= 0)
                {
                    //Create
                    var product = Mapper.Map<Product>(productViewModel);
                    var file = productViewModel.FileImage;
                    if (file.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        var path = Path.Combine(Server.MapPath("~/Content/Images/Products"), fileName);
                        file.SaveAs(path);
                        var imageUrl = Url.Content(path);
                        productViewModel.ImageUrl = imageUrl;
                        product.ImageUrl = imageUrl;
                    }

                    var createdProduct = productServiceClient.GetProductById(productViewModel.Id);
                    var createdProductViewModel = Mapper.Map<ProductViewModel>(createdProduct);
                    return View(createdProductViewModel);
                }
                else
                {
                    //Update

                }
            }

            return View(productViewModel);
        }
    }
}