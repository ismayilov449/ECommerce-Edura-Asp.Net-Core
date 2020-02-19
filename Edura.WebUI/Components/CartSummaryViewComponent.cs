using Edura.WebUI.Infrastructure;
using Edura.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edura.WebUI.Components
{
    public class CartSummaryViewComponent : ViewComponent
    {
        public string Invoke()
        {
            return HttpContext.Session.GetJSon<Cart>("Cart")?.Products.Count().ToString() ?? "0";
        }
    }
}
