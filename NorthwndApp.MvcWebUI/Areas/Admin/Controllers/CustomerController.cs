using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NorthwndApp.Business.Abstract;
using NorthwndApp.Business.Concrete;
using NorthwndApp.Model.Entities;
using NorthwndApp.MvcWebUI.Areas.Admin.Filters;
using System;
using System.Collections.Generic;

namespace NorthwndApp.MvcWebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [CheckSession]
    public class CustomerController : Controller
    {
        private readonly ICustomerBs _customerBs;
        private readonly IMapper _mapper;


        public CustomerController(ICustomerBs customerBs, IMapper mapper)
        {
            _customerBs = customerBs;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            List<Customer> customers = _customerBs.GetList();
            return View(customers);

        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            _customerBs.DeleteById(id);

            return Json(new { IsSuccess = true });
        }

        public override bool Equals(object obj)
        {
            return obj is CustomerController controller &&
                   EqualityComparer<IMapper>.Default.Equals(_mapper, controller._mapper);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_mapper);
        }
    }
}
