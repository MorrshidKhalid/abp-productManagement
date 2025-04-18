﻿using ProductManagement.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace ProductManagement.Products
{
    public class ProductAppService :
        ProductManagementAppService, IProductAppService
    {
        private readonly IRepository<Product, Guid> _productRepository;
        private readonly IRepository<Category, Guid> _categoryRepository;
        public ProductAppService(IRepository<Product, Guid> productRepository, IRepository<Category, Guid> categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }
        public async Task CreateAsync(CreateUpdateProductDto input)
        {
            await _productRepository.InsertAsync(
                ObjectMapper.Map<CreateUpdateProductDto, Product>(input)
                );
        }
        public async Task<ListResultDto<CategoryLookupDto>> GetCategoriesAsync()
        {
            var categories = await _categoryRepository.GetListAsync();

            return new ListResultDto<CategoryLookupDto>(
                ObjectMapper.Map
                <List<Category>, List<CategoryLookupDto>>(categories));
        }
        public async Task<ProductDto> GetAsync(Guid id)
        => ObjectMapper.Map<Product, ProductDto>(await _productRepository.GetAsync(id));
        public async Task UpdateAsync(Guid id, CreateUpdateProductDto input)
        {
            var product = await _productRepository.GetAsync(id);
             ObjectMapper.Map(input, product);
        }
        public async Task DeleteAsync(Guid id) => await _productRepository.DeleteAsync(id);
        public async Task<PagedResultDto<ProductDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            // WithDetailsAsync is similar to incloud.
            IQueryable<Product> queryable = await _productRepository.WithDetailsAsync(x => x.Category);

            queryable = queryable
                .Skip(input.SkipCount)
                .Take(input.MaxResultCount)
                .OrderBy(input.Sorting ?? nameof(Product.Name));


            List<Product> products = await AsyncExecuter.ToListAsync(queryable); // to perform query asynchronously.
            long count = await _productRepository.GetCountAsync(); // Map List of Entity => (Product)To (ProductDto).

            return new PagedResultDto<ProductDto>(
                count, ObjectMapper.Map<List<Product>, List<ProductDto>>(products));
        }
    }
}
