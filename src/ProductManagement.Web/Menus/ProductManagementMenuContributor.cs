using System.Threading.Tasks;
using ProductManagement.Localization;
using ProductManagement.MultiTenancy;
using Volo.Abp.SettingManagement.Web.Navigation;
using Volo.Abp.Identity.Web.Navigation;
using Volo.Abp.UI.Navigation;
using Volo.Abp.TenantManagement.Web.Navigation;

namespace ProductManagement.Web.Menus;

public class ProductManagementMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
    }

    private static Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        var l = context.GetLocalizer<ProductManagementResource>();

        //Home
        context.Menu.AddItem(
            new ApplicationMenuItem(
                ProductManagementMenus.Home,
                l["Menu:Home"],
                "~/",
                icon: "fa fa-home",
                order: 1
            )
        );


        //Administration
        var administration = context.Menu.GetAdministration();
        administration.Order = 6;

        //Administration->Identity
        administration.SetSubItemOrder(IdentityMenuNames.GroupName, 1);

        if (MultiTenancyConsts.IsEnabled)
        {
            administration.SetSubItemOrder(TenantManagementMenuNames.GroupName, 1);
        }
        else
        {
            administration.TryRemoveMenuItem(TenantManagementMenuNames.GroupName);
        }

        administration.SetSubItemOrder(SettingManagementMenuNames.GroupName, 3);

        //Administration->Settings
        administration.SetSubItemOrder(SettingManagementMenuNames.GroupName, 7);

        context.Menu.AddItem(
            new ApplicationMenuItem(
                ProductManagementMenus.ProductManagement,
                l["Menu:ProductManagement"],
                icon: "fas fa-shopping-cart"
                ).AddItem(
                new ApplicationMenuItem(
                    ProductManagementMenus.Product,
                    l["Menu:Products"],
                    url: "/Products"
                    )
                )
            );
        
        return Task.CompletedTask;
    }
}
