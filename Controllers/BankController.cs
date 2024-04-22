using BankBranchesMiniProject.Models;
using Microsoft.AspNetCore.Mvc;


namespace BankBranchesMiniProject.Controllers
{
    public class BankController : Controller
    {

        private static List<BankBranch> bankBranchData = [
        new BankBranch {Id=1, BranchManager="Waleed",LocationName="Kaifan",LocationURL="https://maps.app.goo.gl/P7vvY2tDXqPbsGpL7",EmployeeCount=20},
        new BankBranch {Id=2, BranchManager="Mohammed",LocationName="Adaliya",LocationURL="https://maps.app.goo.gl/wK6Hc6BNACFiV7sR6",EmployeeCount=30}
        ];
        public IActionResult Index()
        {
            using (var context = new BankContext())
            {
                var banks = context.BankBranches.ToList();

                return View(banks);
            }

        }

        public IActionResult Details(int Id) {

            using (var context = new BankContext()) {

                var banks = context.BankBranches.FirstOrDefault(b => b.Id == Id);
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

                using (var context = new BankContext())
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
