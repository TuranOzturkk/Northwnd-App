using Infrastructure.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using NorthwndApp.Business.Abstract;
using NorthwndApp.Model.Entities;
using NorthwndApp.MvcWebUI.Areas.Admin.Models;
using NorthwndApp.MvcWebUI.Extensions;
using NorthwndApp.MvcWebUI.Statics;

namespace NorthwndApp.MvcWebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AuthenticationController : Controller
    {
        private readonly IEmployeeBs _employeeBs;
        private readonly IConfiguration _configuration;
        public AuthenticationController(IEmployeeBs employeeBs, IConfiguration configuration)
        {
            _employeeBs = employeeBs;
            _configuration = configuration;
        }
        public IActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LogIn(AuthenticationLogInVm model)
        {
            model.Password = CryptoHelper.AESEncrypt(model.Password, _configuration.GetSection("EncryptionKey").Value);

            Employee employee = _employeeBs.LogIn(model.UserName, model.Password);

            if (employee == null)
                return Json(new { IsSuccess = false, Message = Messages.USER_NOT_FOUND });

            HttpContext.Session.SetObject("LoggedInUser", employee);

            return Json(new { IsSuccess = true });
        }
    }
}
