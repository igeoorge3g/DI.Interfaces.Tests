using DI.Interfaces.Core.Manager;
using DI.Interfaces.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace DI.Interfaces.Core.Controllers
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