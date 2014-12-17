using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WebExtensionApi.BlogServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IBlogServices" in both code and config file together.
    [ServiceContract]
    public interface IBlogServices
    {
        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "/json/GetBlogs")]
        string GetBlogs();
    }
}
