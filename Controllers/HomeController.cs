using CustomerOrders.Models;
using CustomerOrders.Validators.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerOrders.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IModelValidator<CustomerOrdersViewModel> _orderValidator;
        public HomeController(ILogger<HomeController> logger, IModelValidator<CustomerOrdersViewModel> orderValidator)
        {
            _logger = logger;
            _orderValidator = orderValidator;
        }

        public IActionResult Index()
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            var ordersParsed = BigShoeDataImport.Load(currentDirectory + "\\XmlHelpers\\test.xml");

            var orders = ordersParsed.Order;
            var ordersDto = new List<CustomerOrdersViewModel>();

            foreach (var order in orders)
            {
                var orderDto = CustomerOrdersMapper.ToDto(order);
                orderDto.ValidationStatus = this._orderValidator.Validate(orderDto);

                ordersDto.Add(orderDto);
            }

            return View(ordersDto);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
