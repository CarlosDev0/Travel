using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travelus.BI.BookBI;
using Travelus.DA.Models;

namespace Travelus.NUnit.Test.Tests
{
    [TestFixture]
    public partial class TravelTest
    {
        private readonly IConfiguration Configuration;
        DbContextOptions<BDTravelContext> options = new DbContextOptionsBuilder<BDTravelContext>()
                .UseSqlServer("Data Source=(localdb)\\ProjectsV12;Initial Catalog=BDTravel;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
            .Options;
        public TravelTest(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        public TravelTest()
        {  
        }
        
        [Test]
        public void Test_Read_Books_From_DB() {
            
            using (var context = new BDTravelContext(options, Configuration))
            {
                BookBusiness BookRepository = new BookBusiness(context);
                List<TblLibro> listBooks = BookRepository.ListBooks();

            Assert.AreEqual(5, listBooks.Count);
            }
        }

        
    }
}
