using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity.Core.Objects;
using WebApplication_Kaido15.Class;

namespace WebApplication_Kaido15.Controllers
{
    public class CrudOperationsController : Controller
    {

        [HttpPost]
        public ActionResult Index(Models.Student student, int? id)
        {
            if (ModelState.IsValid)
            {
                using (var context = new Entities())
                {
                    ObjectParameter result = new ObjectParameter("result", typeof(String));
                    ObjectParameter createdId = new ObjectParameter("createdId", typeof(String));
                    if (id == null)
                        context.sp_InsertStudent(student.name, student.address, student.age, student.standard, student.percent, student.status, result, createdId);
                    else
                        context.sp_UpdateStudent(id, student.name, student.address, student.age, student.standard, student.percent, student.status, result);

                    TempData["Result"] = createdId.Value == null ? result.Value : result.Value + " New Student Id is " + createdId.Value;
                }
            }
            ViewBag.Operation = id == null ? "Add Student" : "Update Student";
            BindStudent(0);
            return View();
        }

        public ActionResult Index(int? id, int? page)
        {
            BindStudent(Convert.ToInt32(page));
            Models.Student mStudent = new Models.Student();
            if (id != null)
            {
                using (var context = new Entities())
                {
                    var result = context.sp_GetStudentById(id);
                    var targetList = result.Select(x => new Models.Student() { id = x.Id, name = x.Name, address = x.Address, age = x.Age, standard = x.Standard, percent = x.Percent, addedOn = x.AddedOn, status = x.Status }).ToList();
                    mStudent = targetList.ToList().FirstOrDefault();
                    ViewBag.Operation = "Update Student";
                    return View(mStudent);
                }
            }
            else
                ViewBag.Operation = "Insert Student";
            return View();
        }

        public void BindStudent(int page)
        {
            using (var context = new Entities())
            {
                int pageSize = 4;
                int pageNo = page == 0 ? 1 : page;

                PagingInfo pagingInfo = new PagingInfo();
                pagingInfo.CurrentPage = pageNo;
                pagingInfo.TotalItems = context.Student.Count();
                pagingInfo.ItemsPerPage = pageSize;
                ViewBag.Paging = pagingInfo;

                List<Models.Student> mStudentList = new List<Models.Student>();
                var result = context.sp_GetStudent(pageNo, pageSize);
                var targetList = result.Select(x => new Models.Student() { id = x.Id, name = x.Name, address = x.Address, age = x.Age, standard = x.Standard, percent = x.Percent, addedOn = x.AddedOn, status = x.Status }).ToList();
                mStudentList = targetList.ToList();
                ViewBag.StudentList = mStudentList;
            }
        }
    }

}