using ProductManagement.Products;

namespace ProductManagement.EntityFrameworkCore.Applications.Products;
using Xunit;

[Collection("ProductManagementTestConsts.CollectionDefinitionName")]
public class EfCoreProductAppServiceTest :
    ProductAppServiceTest<ProductManagementEntityFrameworkCoreTestModule>
{
    
}