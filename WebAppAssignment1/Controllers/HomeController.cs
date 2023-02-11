using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAppAssignment1.Models;

namespace WebAppAssignment1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _db;

        public HomeController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Person person)
        {
            if (ModelState.IsValid)
            {
                _db.People.Add(person);
                _db.SaveChanges();
                return RedirectToAction(nameof(ListAll));
            }
            else return View();

        }
        public IActionResult ListAll()
        {
            IEnumerable<Person> people = _db.People.ToList();
            return View(people);
        }
        public IActionResult Update(int id)
        {
           
            var person = _db.People.FirstOrDefault(x => x.Id == id);

            return View(person);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Update")]
        public IActionResult UpdatePost(Person p)
        {
            if (ModelState.IsValid)
            {
                var person = _db.People.AsNoTracking().FirstOrDefault(x => x.Id == p.Id);

                if (person == p)  // if there is no changes we just return to page ListAll
                {
                    return RedirectToAction(nameof(ListAll));
                }

                _db.People.Update(p);
                _db.SaveChanges();

                return RedirectToAction(nameof(ListAll));
            }
            else return View();
        }

        public IActionResult Delete(int id)
        {
            var person = _db.People.FirstOrDefault(x => x.Id == id);
            
            _db.People.Remove(person);
            _db.SaveChanges();

            return RedirectToAction(nameof(ListAll));
        }


        public IActionResult DeleteAll()
        {
            IEnumerable<Person> people = _db.People.Where(o => o.Id > 0); // take all people
            _db.People.RemoveRange(people);
            _db.SaveChanges();

            return RedirectToAction(nameof(ListAll));
        }

    }
}
