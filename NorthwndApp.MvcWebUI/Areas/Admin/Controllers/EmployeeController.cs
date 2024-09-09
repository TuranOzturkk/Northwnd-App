using AutoMapper;
using Infrastructure.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using NorthwndApp.Business.Abstract;
using NorthwndApp.Business.Concrete;
using NorthwndApp.Model.Entities;
using NorthwndApp.MvcWebUI.Areas.Admin.Filters;
using NorthwndApp.MvcWebUI.Areas.Admin.Models;
using System.Collections.Generic;

namespace NorthwndApp.MvcWebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [CheckSession]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeBs _employeeBs;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public EmployeeController(IEmployeeBs employeeBs, IMapper mapper, IConfiguration configuration)
        {
            _employeeBs = employeeBs;
            _mapper = mapper;
            _configuration = configuration;
        }
        public IActionResult Index()
        {
            List<Employee> employees = _employeeBs.GetList();
            return View(employees);
        }

        [HttpPost]
        public IActionResult Add(EmployeeAddDto model)
        {
            Employee employee = _mapper.Map<Employee>(model);
            employee.Password = CryptoHelper.AESEncrypt(employee.Password, _configuration.GetSection("EncryptionKey").Value);
            employee.IsActive = false;
            employee.ApprovingCode = RandomValueGenerator.GenerateApprovingCode();

            _employeeBs.Insert(employee);

            // MAIL GÖNDER
            string email = _configuration.GetSection("EmailAddress").Value;
            string pass = _configuration.GetSection("EmailPassword").Value;

            string message = $"Sayın {employee.FirstName} {employee.LastName} <br /> Kaydınızın onaylanması için lütfen tıklayın : <br /><a href='http://localhost:57985/Approving/Approve/{employee.ApprovingCode}'>ONAYLA</a>";

            MailHelper.SendMail(email, employee.Email, "Deneme Atışı", message, pass);

            //----------------------------

            return Json(new { IsSuccess = true, Message = "Personel Kaydedildi" });

        }
    }
}
