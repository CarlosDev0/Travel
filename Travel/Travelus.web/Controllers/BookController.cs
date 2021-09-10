using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Travelus.BI.BookBI;
using Travelus.DA.Models;
using Travelus.Tr.Utilities;

namespace Travelus.web.Controllers
{
    public class BookController : Controller
    {
        private readonly BDTravelContext _db;
        public BookController(BDTravelContext bDTravelContext) {
            _db = bDTravelContext;
        }
            
        
        public ActionResult Index()
        {
           
            var books = new BookBusiness(_db).ListBooks().OrderBy(l=> l.Id);
            return View(books);
        }

        // GET: BookController/Details/5
        public ActionResult Details(int id)
        {
            var book = new BookBusiness(_db).GetDetails(id);
            return View(book);
        }

        // GET: BookController/Create
        public ActionResult Create()
        {
            var locations = new SelectList(_db.TblEditorials.OrderBy(l => l.Nombre)
           .ToDictionary(us => us.Id, us => us.Nombre), "Key", "Value");
            ViewBag.Editorials = locations;
            return View();
        }

        // POST: BookController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                TblLibro tblLibro = new TblLibro();
                var book = new ConverterFunctions().CollectionToObject(collection, tblLibro.GetType());
                tblLibro = (TblLibro)book;
                tblLibro.UsuarioCreacion = "Admin";
                tblLibro.FechaCreacion = DateTime.Now;
                new BookBusiness(_db).Create(tblLibro);
                return RedirectToAction(nameof(Index));
                
            }
            catch
            {
                return View();
            }
        }

        // GET: BookController/Edit/5
        public ActionResult Edit(int id)
        {
            var book = new BookBusiness(_db).GetDetails(id);
            return View(book);
        }

        // POST: BookController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                TblLibro tblLibro = new TblLibro();
                var book = new ConverterFunctions().CollectionToObject(collection, tblLibro.GetType());
                tblLibro = (TblLibro)book;
                tblLibro.UsuarioModificacion = "Admin2";
                tblLibro.FechaModificacion = DateTime.Now;

                new BookBusiness(_db).Update(tblLibro);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

            // GET: BookController/Delete/5
        public ActionResult Delete(int id)
        {
            var book = new BookBusiness(_db).GetDetails(id);
            return View(book);
        }

        // POST: BookController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                new BookBusiness(_db).Delete(id);
                
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
