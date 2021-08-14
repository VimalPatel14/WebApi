using DurableTask.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class ProductController : ApiController
    {
        CategoryEntities db = new CategoryEntities();

        //Add Post Request
        /*
                public string Post(Category category)
                {

                    db.Categories.Add(category);
                    db.SaveChanges();

                    return "Category added";
                }
        */

        public string Post(Category category)
        {

            db.Categories.Add(category);
            db.SaveChanges();

 

            return "Category added";
        }

        //Get All Records
        public IEnumerable<Category> Get()
        {
            return db.Categories.ToList();
        }

        //Get Single Records
        public Category Get(int id)
        {
            Category category = db.Categories.Find(id);
           return category;
        }

        //Update Record
        public string Put(int id,Category category)
        {
            var category_ = db.Categories.Find(id);
            category_.CategoryName = category.CategoryName;
            category_.CategoryURL = category.CategoryURL;
            category_.Active = category.Active;

            db.Entry(category_).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            return "Category Updated";
        }

        //Delete Record
        public string Delete(int id)
        {
            Category category = db.Categories.Find(id);

            db.Categories.Remove(category);
            db.SaveChanges();

            return "Category Deleted";
        }
    }
}
