using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebExtensionApi.BlogCore.DAL;
using WebExtensionApi.BlogCore.Proxy;

namespace WebExtensionApi.BlogCore.Repository
{
    public class BlogRepo : BaseRepo<Blog>
    { 
        [InjectionConstructor]
        public BlogRepo(BlogEntities context)
            : base(context)
        {
        }

        public List<BlogProxy> GetAllBlogs()
        {
            return (from blog in Context.Blogs
                    select new BlogProxy
                    {
                        ID = blog.ID,
                        Category = blog.Category.Name,
                        CategoryID = blog.CategoryID,
                        Text = blog.Text,
                        Images = blog.BlogImages.Select(image => new BlogImageProxy() { ID = image.ID, ImageURL = image.ImageURL }).ToList(),
                        Comments = blog.BlogComments.Select(comment => new BlogCommentProxy() {  ID = comment.ID, Text = comment.Text}).ToList()
                    }).ToList();
        }
    }
}
