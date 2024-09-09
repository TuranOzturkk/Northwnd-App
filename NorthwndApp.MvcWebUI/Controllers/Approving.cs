using Microsoft.AspNetCore.Mvc;
using NorthwndApp.Business.Abstract;
using NorthwndApp.Model.Entities;

namespace NorthwndApp.MvcWebUI.Controllers
{
    public class Approving : Controller
    {
        private readonly IEmployeeBs _employeeBs;
        private readonly IMusterilerBs _musterilerBs;
        public Approving(IEmployeeBs employeeBs, IMusterilerBs musterilerBs)
        {
            _employeeBs = employeeBs;
            _musterilerBs = musterilerBs;
        }
        public IActionResult Approve(string id)
        {
            Employee employee = _employeeBs.Get(x => x.ApprovingCode == id);

            if (employee != null)
            {
                employee.IsActive = true;
                _employeeBs.Update(employee);

                ViewBag.Result = "<div class='alert alert-success'>Kaydınız Onaylandı</div>";
            }
            else
                ViewBag.Result = "<div class='alert alert-danger'>Kaydınız Onaylanmadı</div>";

            return View();
        }
        public IActionResult MusterilerApprove(string id)
        {
            Musteriler musteriler = _musterilerBs.Get(x => x.ApprovingCode == id);

            if (musteriler != null)
            {
                musteriler.IsActive = true;
                _musterilerBs.Update(musteriler);

                ViewBag.Result = "<div class='alert alert-success'>Kaydınız Onaylandı</div>";
            }
            else
                ViewBag.Result = "<div class='alert alert-danger'>Kaydınız Onaylanmadı</div>";

            return View();
        }
    }
}
