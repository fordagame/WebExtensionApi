using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebExtensionApi.BlogCore.Proxy
{
    public class BlogProxy
    {
        public int ID { get; set; }
        public string Text { get; set; }
        public string Category { get; set; }
        public int CategoryID { get; set; }
        public List<BlogCommentProxy> Comments { get; set; }
        public List<BlogImageProxy> Images { get; set; }

    }

    public class BlogCommentProxy
    {
        public int ID { get; set; }
        public string Text { get; set; }
    }

    public class BlogImageProxy
    {
        public int ID { get; set; }
        public string ImageURL { get; set; }
    }
}
