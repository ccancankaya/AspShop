using Shop.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.ProductsAdmin
{
    public class UpdateProduct
    {
        private ApplicationDbContext _ctx;
        public UpdateProduct(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }


        public async Task<Response> Do(Request request)
        {


            await _ctx.SaveChangesAsync();
            return new Response();
        }

        public class Request
        {
            public string Name { get; set; }
            public string Description { get; set; }
            [Column(TypeName = "decimal(18,4)")]
            public decimal Value { get; set; }
        }

        public class Response
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public decimal Value { get; set; }
        }

    }
}
