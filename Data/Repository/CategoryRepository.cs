using System.Collections.Generic;
using WebShop.Data.Interfaces;
using WebShop.Data.Models;

namespace WebShop.Data.Repository
{
    public class CategoryRepository : IPhonesCategory
    {

        private readonly AppDBContent appDBContent;

        public CategoryRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
    
        }

        public IEnumerable<Category> AllCategories => appDBContent.Category;
    }
}
