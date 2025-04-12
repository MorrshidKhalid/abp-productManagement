using System.Threading.Tasks;
using Shouldly;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Modularity;
using Xunit;

namespace ProductManagement.Products;

public abstract class ProductAppServiceTest<TStartupModule> : 
    ProductManagementApplicationTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{
    private readonly IProductAppService _productAppService;

    protected ProductAppServiceTest()
    {
        _productAppService = GetRequiredService<IProductAppService>();
    }

    [Fact]
    public async Task Should_Get_List_Of_Products_Dtos()
    {
        var result = await _productAppService.GetListAsync(
            new PagedAndSortedResultRequestDto()
        );

        //Assert
        result.TotalCount.ShouldBeGreaterThan(0);
        result.Items.ShouldContain(x => x.Name == "XP VH240a 23.8-Inch Full HD 1080p IPS LED Monitor");
    }
    
    /*
     *[Fact]
    public async Task Should_Create_A_Valid_Book()
    {
        var exception = await Assert.ThrowsAsync<AbpValidationException>(async () =>
        {
            await _productAppService.CreateAsync(
                new CreateUpdateProductDto()
                {
                    CategoryId = new Guid("0EBAA93D-8D7C-A892-2152-3A193AC900E6"),
                    Name = "Sample product in order to rest",
                    Price = 123,
                    IsFreeCargo = true,
                    StockState = 0,
                    ReleaseDate = new DateTime(2020, 10, 20)
                }
            );
        });

        exception.ValidationErrors
            .ShouldNotContain(err => err.MemberNames.Any(mem => mem == "Name"));
    }
    
    [Fact]
    public async Task Should_Create_Not_Create_In_Valid_Book()
    {
        var exception = await Assert.ThrowsAsync<AbpValidationException>(async () =>
        {
            await _productAppService.CreateAsync(
                new CreateUpdateProductDto()
                {
                    CategoryId = new Guid("0EBAA93D-8D7C-A892-2152-3A193AC900E6"),
                    Name = "",
                    Price = 123,
                    IsFreeCargo = true,
                    StockState = 0,
                    ReleaseDate = new DateTime(2020, 10, 20)
                }
            );
        });

        exception.ValidationErrors
            .ShouldContain(err => err.MemberNames.Any(mem => mem == "Name"));
    }
     * 
     */
}