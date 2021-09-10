using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travelus.DA.Book.DA;
using Travelus.DA.Models;

namespace Travelus.BI.BookBI
{
    public class BookBusiness
    {
        private readonly BDTravelContext _db;
        public BookBusiness(BDTravelContext bDTravelContext)
        {
            _db = bDTravelContext;
        }
        public List<TblLibro> ListBooks()
        {
            try
            {
                return new BookData(_db).ListBooks();
            }
            catch (Exception ex) {
                return new List<TblLibro>();
            }
        }
        public TblLibro GetDetails(int id) {
            TblLibro tblLibro = new BookData(_db).GetDetails(id);
            return tblLibro;
        }
        public void Update(TblLibro tblLibro) {
            try
            {
                new BookData(_db).Update(tblLibro);
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
                new BookData(_db).Create(tblLibro);
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
                new BookData(_db).Delete(id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
