using Microsoft.AspNetCore.Mvc;
using UniversityWebApplication.Controllers;
using UniversityWebApplication.Tests.Repository;
using Xunit;

namespace UniversityWebApplication.Tests.Controller
{
    public class ToDoCategoriesControllerShould
    {
        
        private AppDbContext _context;
        private ToDoCategoriesController _categoryController;

        public ToDoCategoriesControllerShould()
        {
            _context = InMemoryAppDbContext.GetInMemoryAppDbContext();
            _categoryController = new ToDoCategoriesController(_context);
        }
        

        [Fact(DisplayName = "Index should return default view")]
        public void IndexShouldReturnDefaultView()
        {
            var result = _categoryController.Index() as ViewResult;

            Assert.NotNull(result);
            Assert.True(string.IsNullOrEmpty(result.ViewName) || result.ViewName == "Index");
        }
    }
}
