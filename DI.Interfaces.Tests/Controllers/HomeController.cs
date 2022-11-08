using DI.Interfaces.Tests.Integrations.Models;
using DI.Interfaces.Tests.Manager;
using DI.Interfaces.Tests.Models;
using Microsoft.AspNetCore.Mvc;

namespace DI.Interfaces.Tests.Controllers
{
    public class HomeController : Controller
    {
        private readonly IntegrationManager _integrations;

        public HomeController(IntegrationManager integrations)
        {
            _integrations = integrations;
        }


        public IActionResult Example(int salesChannelId)
        {
            var salesChannel = GetTheSalesChannelBasedOnId(salesChannelId);
            var myCustomProduct = new Publication { };
            var concreteProductHiddenUnderInterface = _integrations.CreatePublication_Wrapper(salesChannel, myCustomProduct);
            var customPropertyValue = concreteProductHiddenUnderInterface;
            return Json(concreteProductHiddenUnderInterface);
        }

        private SalesChannel GetTheSalesChannelBasedOnId(int salesChannelId)
        {
            throw new NotImplementedException();
        }
    }
}