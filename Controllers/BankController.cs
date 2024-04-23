using BankBranchesMiniProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace BankBranchesMiniProject.Controllers
{
    public class BankController : Controller
    {
        private readonly BankContext _bankContext;
       
        public BankController(BankContext bankContext)
        {
            _bankContext = bankContext;
        }
        public IActionResult Index()
        {
            using (var context =  _bankContext)
            {
                var banks = context.BankBranches.ToList();

                return View(banks);
            }

        }

        public IActionResult Details(int Id) {

            using (var context =  _bankContext) {

                var banks = context.BankBranches.Include(r => r.Employees).SingleOrDefault(r=>r.Id==Id);
                if (banks == null) 
                {
                    return NotFound();
                }
                return View(banks);
            }
        }

        //[HttpGet]
        //public IActionResult Edit(int Id)
        //{

        //    return View(); 
        //}

        //[HttpPost]
        //public IActionResult Edit(int Id,)
        //{

        //    using(var context = new BankContext()){

        //        context.Update(bankBranchData[Id]); 
        //        context.SaveChanges();

        //    }
        //    return RedirectToAction("Details");
        //}




        [HttpGet]
        public IActionResult AddEmployee(int id)
        {

            return View();
        }


        [HttpPost]
        public IActionResult AddEmployee(int id, IFormCollection Form)
        {
            if (ModelState.IsValid)
            {

                var employeeName = Form["EmployeeName"];
                var employeeCivilId = Form["EmployeeCivilId"];
                var employeePosition = Form["EmployeePosition"];
                
                var m = new Employee();

                m.Name = employeeName;
                m.civilID = double.Parse(employeeCivilId);
                m.Position = employeePosition;
                
                
                using (var context =  _bankContext)
                {
                  var  branch = context.BankBranches.Find(id);
                    m.Workplace = branch; 
                    context.Employees.Add(m);
                    context.SaveChanges();
                }



                return RedirectToAction("Index");
            }
            return View(Form);

        }














        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(IFormCollection form)
        {
           



            if (ModelState.IsValid)
            {
                var id = form["Id"];
                var branchManager = form["BranchManager"];
                var locationName = form["LocationName"];
                var locationURL = form["LocationURL"];
                var employeeCount = form["EmployeeCount"];
                var e = new BankBranch();

                e.Id = int.Parse(id);
                e.BranchManager = branchManager;
                e.LocationName = locationName;
                e.LocationURL = locationURL;
                e.EmployeeCount = int.Parse(employeeCount);

                using (var context = _bankContext)
                {
                   context.BankBranches.Add(e);
                    context.SaveChanges();
                }



                return RedirectToAction("Index");
            }
            return View(form);

        }
    }
}
