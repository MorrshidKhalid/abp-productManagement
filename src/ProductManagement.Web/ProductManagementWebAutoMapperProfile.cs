using AutoMapper;
using ProductManagement.Web.Pages.Products;
using ProductManagement.Products;

namespace ProductManagement.Web;

public class ProductManagementWebAutoMapperProfile : Profile
{
    public ProductManagementWebAutoMapperProfile()
    {
        CreateMap<CreateEditProductViewModel, CreateUpdateProductDto>();
    }
}
