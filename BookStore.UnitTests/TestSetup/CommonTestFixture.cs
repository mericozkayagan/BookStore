using AutoMapper;
using BookStore.Common;
using BookStore.DbOperation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.UnitTests.TestSetup
{
    public class CommonTestFixture
    {
        public Context context { get; set; }
        public IMapper mapper { get; set; }
        public CommonTestFixture()
        {
            var options = new DbContextOptionsBuilder<Context>().UseInMemoryDatabase(databaseName: "BookStoreTestDb").Options;
            context = new Context(options);

            context.Database.EnsureCreated();
            context.AddBooks();
            context.AddGenres();            
            context.SaveChanges();

            mapper = new MapperConfiguration(cfg => { cfg.AddProfile<MappingProfile>(); }).CreateMapper();
        }
        

        
        
    }
}
