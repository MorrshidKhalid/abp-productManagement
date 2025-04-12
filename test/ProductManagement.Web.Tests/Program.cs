using Microsoft.AspNetCore.Builder;
using ProductManagement;
using Volo.Abp.AspNetCore.TestBase;

var builder = WebApplication.CreateBuilder();
builder.Environment.ContentRootPath = GetWebProjectContentRootPathHelper.Get("ProductManagement.Web.csproj"); 
await builder.RunAbpModuleAsync<ProductManagementWebTestModule>(applicationName: "ProductManagement.Web");

public partial class Program
{
}
