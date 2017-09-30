using System.Web.Mvc;
using SonataStore.Domain.Abstract;
using SonataStore.Domain.Entities;
using System.Linq;

namespace SonataStore.WebUI.Controllers
{
    public class AdminController : Controller
    {
        IProductRepository repository;

        public AdminController(IProductRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index()
        {
            return View(repository.Products);
        }

        public ViewResult Edit(int productId)
        {
            Product product = repository.Products
                .FirstOrDefault(p => p.ProductId == productId);
            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                repository.SaveProduct(product);
                TempData["message"] = string.Format("Изменения в товаре \"{0}\" были сохранены", product.Name);
                return RedirectToAction("Index");
            }
            else
            {
                //Что-то не так со значениями данных
                return View(product);
            }
        }

        public ViewResult Create()
        {
            return View("Edit", new Product());
        }

        [HttpPost]
        public ActionResult Delete(int productId)
        {
            Product deletedProduct = repository.DeleteProduct(productId);
            if(deletedProduct != null)
            {
                TempData["message"] = string.Format("Товар \"{0}\" был удален", deletedProduct.Name);
            }
            return RedirectToAction("Index");
        }
    }
}