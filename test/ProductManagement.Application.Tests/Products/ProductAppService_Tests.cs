//using Shouldly;
//using System.Threading.Tasks;
//using Volo.Abp.Application.Dtos;
//using Volo.Abp.Modularity;
//using Xunit;

//namespace ProductManagement.Products
//{
//    public class ProductAppService_Tests :
//        ProductManagementApplicationTestBase<ProductManagementApplicationTestModule>
//    {
//        private readonly IProductAppService _productAppService;

//        public ProductAppService_Tests()
//        {
//            _productAppService = GetRequiredService<IProductAppService>();
//        }

//        /* TODO: Test methods */

//        [Fact]
//        public async Task Should_Get_Product_List()
//        {
//            //Act
//            PagedResultDto<ProductDto> output = await _productAppService.GetListAsync(
//            new PagedAndSortedResultRequestDto()
//            );

//            //Assert
//            output.TotalCount.ShouldBe(3);
//            output.Items.ShouldContain(
//                x => x.Name.Contains("Acme Monochrome Laser Printer")
//            );
//        }
//    }

//}