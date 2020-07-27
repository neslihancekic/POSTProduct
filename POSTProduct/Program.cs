using Data.Model.Request;
using System;
using System.Threading.Tasks;
using POSTProduct.ReadCsv;

namespace POSTProduct
{
    class Program
    {
        static void Main(string[] args)
        {
            ImportProductsRequest list = ProductReader.GetProduct("sample.csv"); 

            var t = PostProduct.PostURI(new Uri("http://dev.shopiconnect.com/api/productImport/ImportDeltaProducts"), list);

            /* HTTPCLIENT'lı fonksiyon için => */
           // var t = Task.Run(() => ReadCsv.ProductReader.PostURI(new Uri("http://dev.shopiconnect.com/api/productImport/ImportDeltaProducts"),list));
           //t.Wait();

        }
    }
}
