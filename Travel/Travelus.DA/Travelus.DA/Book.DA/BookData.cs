using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travelus.DA.Models;

namespace Travelus.DA.Book.DA
{
    public class BookData
    {
        private readonly BDTravelContext _db;
        public BookData(BDTravelContext bDTravelContext)
        {
            _db = bDTravelContext;
        }
        public List<TblLibro> ListBooks() {
            List<TblLibro> ListBooks_ = new List<TblLibro>();
            ListBooks_ = _db.TblLibros.ToList();
            return ListBooks_;
        }
        public TblLibro GetDetails(int id)
        {
            TblLibro tblLibro = new TblLibro();
            try
            {

                tblLibro = _db.TblLibros.Find(id);
            }
            catch (Exception ex) {
                tblLibro = null;
            }
            return tblLibro;
        }
        public void Update(TblLibro tblLibro)
        {
            try
            {
                _db.Update(tblLibro);
                _db.BeforeSaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public void Create(TblLibro tblLibro)
        {
            try
            {
                _db.Add(tblLibro);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public void Delete(int id)
        {
            try
            {
                var bookToDelete = new TblLibro()
                {
                    Isbn = id
                };

            
                _db.Remove(bookToDelete);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
