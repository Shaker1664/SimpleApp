using api.Entities;
using api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Services.Interfaces
{
    public interface IProductService
    {
        Task<CreateProduct> CreateAsync(CreateProduct createProduct);
        Task<string> DeleteAsync(Guid id);
        Task<string> RemoveAsync(Guid id);
        Task<EditProduct> UpdateAsync(EditProduct editProduct);
        Task<IEnumerable<Product>> GetAll();
        Task<Product> GetById(Guid id);
    }
}
