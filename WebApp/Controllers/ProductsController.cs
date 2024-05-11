using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using WebApp.ViewModels;


namespace WebApp.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            var products= ProductsRepository.GetProducts(loadCategory:true);
            return View(products);
        }
        public IActionResult Add()
        {
            ViewBag.Action = "add";
            var productViewModel = new ProductViewModel
            {
                Categories= CategoriesRepository.GetCategories()
            };
            return View(productViewModel);
        }
        [HttpPost]
        public IActionResult Add(ProductViewModel ProductViewModel)
        {
            if (ModelState.IsValid)
            {
                ProductsRepository.AddProduct(ProductViewModel.Product);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Action = "add";
            ProductViewModel.Categories = CategoriesRepository.GetCategories();
            return View(ProductViewModel);
        }
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "edit";
            var productViewModel = new ProductViewModel
            {
                Product = ProductsRepository.GetProductById(id) ?? new Product(),
                Categories = CategoriesRepository.GetCategories()
            };
            return View(productViewModel);
        }
        [HttpPost]
        public IActionResult Edit(ProductViewModel productViewModel)
        {
            if (ModelState.IsValid)
            {
               ProductsRepository.UpdateProduct(productViewModel.Product.ProductId, productViewModel.Product);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Action = "edit";
            productViewModel.Categories = CategoriesRepository.GetCategories();
            return View(productViewModel);
        }
        public IActionResult Delete(int id)
        {
            ProductsRepository.DeleteProduct(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult ProductsByCategoryPartial(int categoryId)
        {
            var products = ProductsRepository.GetProductByCategoryId(categoryId);
            return PartialView("_Products", products);
        }
    }
    
}
