using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Student_system.Data;
using Student_system.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_system.Controllers
{
    public class Student_infoController : Controller
    {
        
        private readonly  ApplicationDbContext _context;
        



        public Student_infoController(ApplicationDbContext context)
        {
            _context = context;
            
        }

        
        [HttpGet]
        public  async Task<IActionResult> Index()
        {

            var model = await _context.student_Infos.ToListAsync();
            return View(model);
        }


        [HttpPost]//Find Student
        public async Task<IActionResult> Index(String name)
        {
            //var connectionstring = "Data Source = LAPTOP - M3PGP64P\\SQLEXPRESS; Initial Catalog = Web_demo; Integrated Security = True";
            //var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            //optionsBuilder.UseSqlServer(connectionstring);

            //ApplicationDbContext dbContext = new ApplicationDbContext(optionsBuilder.Options);


            var Find_student = from s in _context.student_Infos
                               where s.Fname.Contains(name)
                               select s;



            //if (Find_student.GetEnumerator().MoveNext() == false)
            //{
            //    ViewBag.showAlert = true;
            //    ViewBag.AlertMessage = "ไม่พบข้อมูล";


            //    return View();
            //}
           
                return View(Find_student.ToList());
            



            // retutn list
           
            
            
                         
           
        }






        // Get student
        [HttpGet]
        public IActionResult Addstudent()
        {
            return View();
        }
        
        
        // Add student
        
        [HttpPost]
        public async Task<IActionResult> Addstudent(Student_info model)
        {
            
            // เป็นการเช็คว่า ถ้ากรอกข้อมูลไม่ครบจะอยู่ค้างหน้าเดิม
            if (ModelState.IsValid)
            {
                var oldstudent = await _context.student_Infos.AnyAsync(m => m.Email == model.Email);

                // เป็นการเช็คว่า ถ้ากรอกข้อมูลแล้วอีเมลล์ซ้ำกันจะอยู่ค้างหน้าเดิม
                if (oldstudent)
                {
                    TempData["message"] = "อีเมลล์นี้มีผู้ใช้งานแล้ว";
                    return View();
                }
                else
                {
                    _context.student_Infos.Add(model);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }

            }
            else
            {
                TempData["message"] = "";
                return View();
            }




        }

        //Get Edit student
        public async Task <IActionResult> Studentedit(int ID)
        {
            var oldstudent = await _context.student_Infos.FirstOrDefaultAsync(m => m.ID == ID);
            if (oldstudent == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(oldstudent);
            }
        
        }


        //Post Student (Update and save)
        
        [HttpPost]
        public async Task<IActionResult> Editstudent(Student_info model)
        {
            var oldstudent =  await _context.student_Infos.FirstOrDefaultAsync(m => m.ID == model.ID);
            {
               if(oldstudent != null)
                {
                    oldstudent.ID = model.ID;
                    oldstudent.Fname = model.Fname;
                    oldstudent.Lname = model.Lname;
                    oldstudent.Email = model.Email;
                    oldstudent.Tel = model.Tel;
                    await _context.SaveChangesAsync();
                }

                return RedirectToAction("Index");
            
            }
        }


        //Delete Student
        public async Task<IActionResult> Deletestudent(int ID)
        {
            var Oldstudent =  await _context.student_Infos.FirstOrDefaultAsync(m => m.ID == ID);
            if( Oldstudent != null)
            {
                _context.student_Infos.Remove(Oldstudent);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Index");

        }


        
        
       

        // Back To Home
        public IActionResult Back_toHome()
        {
             if( ModelState.IsValid || !ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }



    }
}
