using api.Entities;
using api.Models;
using api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _context;
        public ProductService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<CreateProduct> CreateAsync(CreateProduct createProduct)
        {
            var product = new Product()
            {
                ProductName = createProduct.ProductName,
                Price = createProduct.Price,
                Deleted = false,
                Quantity = createProduct.Quantity,
                Discount = createProduct.Discount,
                DateCreated = DateTime.UtcNow
            };

            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            return createProduct;
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            var products = await _context.Products
                .OrderBy(x => x.ProductName)
                .ToListAsync();

            return products;
        }

        public async Task<Product> GetById(Guid id)
        {
            var product = await _context.Products
                .FirstOrDefaultAsync(x => x.Id == id);
            if (product == null)
                return null;
            return product;
        }

        public async Task<string> DeleteAsync(Guid id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return null;
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return product.ProductName;
        }

        public async Task<string> RemoveAsync(Guid id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return null;
            }

            product.Deleted = true;

            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return product.ProductName;
        }

        public async Task<EditProduct> UpdateAsync(EditProduct editProduct)
        {
            if (ProductExists(editProduct.Id))
            {
                var product = await _context.Products
                    .Where(x => x.Deleted == false)
                    .FirstOrDefaultAsync(x => x.Id == editProduct.Id);

                product.ProductName = editProduct.ProductName;
                product.Price = editProduct.Price;
                product.Quantity = editProduct.Quantity;
                product.Discount = editProduct.Discount;
                product.DateModified = DateTime.UtcNow;

                //updating product
                _context.Entry(product).State = EntityState.Modified;

                await _context.SaveChangesAsync();

                return editProduct;
            }
            else
                return null;
        }

        private bool ProductExists(Guid id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
