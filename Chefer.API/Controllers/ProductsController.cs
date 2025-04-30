using AutoMapper;
using Chefer.API.Context;
using Chefer.API.DTOs.ProductDtos;
using Chefer.API.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Chefer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly CheferContext _context;
        private readonly IMapper _mapper;

        public ProductsController(CheferContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var products = _context.Products.ToList();
            return Ok(products);
        }

        [HttpPost]
        public IActionResult Create(CreateProductDto createProductDto)
        {
            var product = _mapper.Map<Product>(createProductDto);
            _context.Add(product);
            _context.SaveChanges();
            return Ok(product);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null)
            {
                return BadRequest("Ürün bulunamadı");
            }

            return Ok(product);
        }

        [HttpPut]
        public IActionResult Update(UpdateProductDto updateProductDto)
        {
            var product = _context.Products.Find(updateProductDto.ProductId);
            if (product == null)
            {
                return BadRequest("Güncellenecek ürün bulunamadı");
            }

           product = _mapper.Map(updateProductDto,product);

            _context.Update(product);
            _context.SaveChanges();
            return Ok("Ürün başarıyla güncellendi");
            
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null)
            {
                return BadRequest("Silinecek ürün bulunamadı");
            }
            _context.Remove(product);
            _context.SaveChanges();
            return Ok("Ürün başarıyla silindi");
        }
    }
}
