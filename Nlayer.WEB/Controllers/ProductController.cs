using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Nlayer.Core.DTOs;
using Nlayer.Core.Entities;
using Nlayer.Core.Services;
using Nlayer.WEB.Services;

namespace Nlayer.WEB.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        private readonly ProductAPIService _productAPIService;
        private readonly CategoryAPIService _categoryAPIService;

        public ProductController(IProductService productService, ICategoryService categoryService, IMapper mapper, CategoryAPIService categoryAPIService, ProductAPIService productAPIService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _mapper = mapper;
            _categoryAPIService = categoryAPIService;
            _productAPIService = productAPIService;
        }
        public async Task<IActionResult> Index()
        {
           
            return View(await _productAPIService.GetProductWithCategoryAsync());
        }
        public async Task<IActionResult> Save()
        {
            var categoriesDto = await _categoryAPIService.GetAllAsync();


            ViewBag.categories = new SelectList(categoriesDto, "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Save(ProductDto productDto)
        {
            if(ModelState.IsValid)
            {
                await _productAPIService.SaveAsync(productDto);

                return RedirectToAction("Index");
            }
            var categoriesDto = await _categoryAPIService.GetAllAsync();


            ViewBag.categories = new SelectList(categoriesDto, "Id", "Name");
            return View();

        }
        [ServiceFilter(typeof(NotFoundFilter<Product>))]
        public async Task<IActionResult> Update(int id)
        {
            var product = await _productAPIService.GetByIdAsync(id);

            var categoriesDto = await _categoryAPIService.GetAllAsync();



            ViewBag.categories = new SelectList(categoriesDto, "Id", "Name",product.CategoryId);
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Update(ProductDto productDto)
        {
            if(ModelState.IsValid)
            {
                await _productAPIService.UpdateAsync(productDto);
                return RedirectToAction(nameof(Index));
            }
            var categoriesDto =await _categoryService.GetAllAsync();


            ViewBag.categories = new SelectList(categoriesDto, "Id", "Name");
            return View(productDto);
        }

        public async Task<IActionResult> Remove(int id)
        {
            await _productAPIService.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
