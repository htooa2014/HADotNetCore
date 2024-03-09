using DotNetTrainingBatch3.HW.ATMapp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotNetTrainingBatch3.HW.ATMapp.Controllers
{
    public class ATMController : Controller
    {
        private readonly AppDBContext _db;

        public ATMController()
        {
            _db = new AppDBContext();
        }

        [ActionName("Index")]
        public IActionResult Index()
        { 
            List<ATMModel> ATMs = _db.ATMs.ToList();
            return View("Index", ATMs);
            
        }


        [ActionName("Create")]
        public IActionResult ATMCreate()
        {

            return View("Create");
        }

        [HttpPost]
        [ActionName("Save")]
        public IActionResult ATMSave(ATMModel atm)
        {
            _db.ATMs.Add(atm);
            _db.SaveChanges();
            return Redirect("/ATM");
        }

        [ActionName("Edit")]
        public IActionResult Edit(int id)
        {
            var item = _db.ATMs.FirstOrDefault(x => x.AtmId == id);
            if (item is null)
            {
                return Redirect("/ATM");
            }


            return View("Edit", item);
        }


        [HttpPost]
        [ActionName("Update")]
        public IActionResult BlogUpdate(int id, ATMModel aTMModel)
        {
            var item = _db.ATMs.FirstOrDefault(x => x.AtmId == id);
            if (item is null)
            {
                return Redirect("/ATM");
            }

            item.UserName = aTMModel.UserName;
            item.Password = aTMModel.Password;
            item.CardNumber = aTMModel.CardNumber;
            item.Balance = aTMModel.Balance;

            _db.SaveChanges();
            return Redirect("/ATM");
        }


        [ActionName("Delete")]
        public IActionResult Delete(int id)
        {
            var item = _db.ATMs.FirstOrDefault(x => x.AtmId == id);
            if (item is null)
            {
                return Redirect("/ATM");
            }

            _db.Remove(item);
            _db.SaveChanges();


            return Redirect("/ATM");
        }


    }
}
