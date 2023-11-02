using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using shopBackEnd.Exception;
using shopBackEnd.Models.BusinessModels;
using shopBackEnd.Models.DataModels;
using shopBackEnd.ModelsDTO.Common;
using shopBackEnd.ModelsDTO.Request;
using shopBackEnd.ModelsDTO.Response;
using System.ComponentModel.DataAnnotations;

namespace shopBackEnd.Repositories
{
    public class ProductService : IProductService
    {
        private readonly ShopDbContext _context;
        private const string USER_CONTENT_FOLDER_NAME = "images";

        public ProductService(ShopDbContext context)
        {
            _context = context;
        }

        public async Task<int> Create(ProductCreateRequest request)
        {
            var productS = await _context.Products.FirstOrDefaultAsync(x => x.Name.Equals(request.Name));
            if (productS != null)
            {
                throw new ShopException($"Product name {request.Name} is duplicate");
            }
            var image = "";

            if (request.Image != null && request.Image.Length > 0)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "product", request.Image.FileName);
                using (var stream = System.IO.File.Create(path))
                {
                    request.Image.CopyTo(stream);
                }
                image = System.IO.Path.GetFileNameWithoutExtension(request.Image.FileName);
            }
            else
            {
                image = "";

            }
            var product = new Product()
            {
                Price = request.Price,
                Sale_Price = request.Price,
                Stock = request.Stock,
                ViewCount = 0,
                Name = request.Name,
                Description = request.Description,
                Details = request.Details,
                SeoDescription = request.SeoDescription,
                SeoTitle = request.SeoTitle,
                SeoAlias = request.SeoAlias,
                CategoryId = request.CategoryId,
                Image = image,
                DateCreated = DateTime.Now,
            };
            _context.Products.Add(product);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Update(ProductUpdateRequest request)
        {
            var product = await _context.Products.FindAsync(request.Id);
            if (product == null)
            {
                throw new ShopException($"Cannot find a product : {request.Id}");
            }
            else
            {

                var productS = await _context.Products.FirstOrDefaultAsync(x => x.Name.Equals(request.Name) && x.Id != request.Id);
                if (productS != null)
                {
                    throw new ShopException($"Product name {request.Name} is duplicate");
                }
                var image = product?.Image;
                if (request.Image != null && request.Image.Length > 0)
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "product", request.Image.FileName);
                    using (var stream = System.IO.File.Create(path))
                    {
                        request.Image.CopyTo(stream);
                    }
                    image = System.IO.Path.GetFileNameWithoutExtension(request.Image.FileName);
                }

                product.Name = request.Name;
                product.Description = request.Description;
                product.Details = request.Details;
                product.SeoDescription = request.SeoDescription;
                product.SeoTitle = request.SeoTitle;
                product.SeoAlias = request.SeoAlias;
                product.CategoryId = request.CategoryId;
                product.Image = image;
                product.DateUpdated = DateTime.Now;
                _context.Products.Update(product);
                return await _context.SaveChangesAsync();
            }
        }

        public async Task<int> Delete(int productId)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null)
            {
                throw new ShopException($"Cannot find a product : {productId}");
            }
            _context.Products.Remove(product);
            return await _context.SaveChangesAsync();
        }

        public Task<ProductViewModel> GetById(int productId)
        {
            throw new NotImplementedException();
        }

        public async Task<PagedResult<ProductViewModel>> GetAllPaging(GetManageProductPagingRequest request)
        {
            //1 Join
            var query = from p in _context.Products
                        join c in _context.Categories on p.CategoryId equals c.Id
                        select new { p, c };
            //2 Filter
            if (!string.IsNullOrEmpty(request.Keyword))
            {
                query = query.Where(x => x.p.Name.Contains(request.Keyword));
            }
            if (!string.IsNullOrEmpty(request.CategoryId))
            {
                query = query.Where(x => x.p.CategoryId == int.Parse(request.CategoryId));
            }
            //3 paging
            int totalRow = await query.CountAsync();
            var data = await query.Skip((request.PageIndex - 1) * request.PageSize).Take(request.PageSize).Select(x => new ProductViewModel()
            {
                Id = x.p.Id,
                Name = x.p.Name,
                DateCreated = x.p.DateCreated,
                Description = x.p.Description,
                Details = x.p.Details,
                CategoryId = x.p.CategoryId,
                Sale_Price = x.p.Sale_Price,
                Price = x.p.Price,
                SeoAlias = x.p.SeoAlias,
                SeoDescription = x.p.SeoDescription,
                SeoTitle = x.p.SeoTitle,
                Stock = x.p.Stock,
                ViewCount = x.p.ViewCount,
                Image = x.p.Image,
                CategoryName = x.c.Name
            }).ToListAsync();
            //4 Select
            var pageResult = new PagedResult<ProductViewModel>()
            {
                TotalRecords = totalRow,
                PageSize = request.PageSize,
                PageIndex = request.PageIndex,
                Items = data
            };
            return pageResult;
        }

        public Task<List<ProductViewModel>> GetAll()
        {
            var query = from p in _context.Products
                        join c in _context.Categories on p.CategoryId equals c.Id
                        select new { p, c };

            var data = query.Select(x => new ProductViewModel()
            {
                Id = x.p.Id,
                Name = x.p.Name,
                DateCreated = x.p.DateCreated,
                Description = x.p.Description,
                Details = x.p.Details,
                CategoryId = x.p.CategoryId,
                Sale_Price = x.p.Sale_Price,
                Price = x.p.Price,
                SeoAlias = x.p.SeoAlias,
                SeoDescription = x.p.SeoDescription,
                SeoTitle = x.p.SeoTitle,
                Image = x.p.Image,
                Stock = x.p.Stock,
                ViewCount = x.p.ViewCount,
                CategoryName = x.c.Name
            }).ToListAsync();
            return data;
        }
    }
}
