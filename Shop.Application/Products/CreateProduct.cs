using Shop.Database;
using Shop.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.CreateProducts
{
    public class CreateProduct
    {
        private ApplicationDbContext _context;

        public CreateProduct(ApplicationDbContext context)
        {
            _context = context;
        }

        // eger Task<specified> belirtmezsek void gibi çalışır
        public async Task Do(ProductViewModel vm)
        {
            _context.Products.Add(new Product
            {
                Name = vm.Name,
                Description = vm.Description,
                Value = vm.Value
            });

            await _context.SaveChangesAsync();
        }
    }

    public class ProductViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Value { get; set; }
    }

}
