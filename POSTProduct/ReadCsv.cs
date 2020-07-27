using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Model.Request;
using System.Text;
using System.IO;
using CsvHelper;
using System.Globalization;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net;
using Newtonsoft.Json.Linq;

namespace POSTProduct.ReadCsv
{
    public class ProductReader
    {
        /**************************************/
        /* CSV DOSYASINI OKUYUP CLASS'A ATAMA */
        /**************************************/

        public static ImportProductsRequest GetProduct(string u)  
        {
            
            using (var reader = new StreamReader(u))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Configuration.Delimiter = "|";
                csv.Configuration.RegisterClassMap<ProductMap>();
                var list = csv.GetRecords<Product>().ToList();
                var products = new ImportProductsRequest();
                products.ProductList = list;

                for(int i = 0; i < products.ProductList.Count();i++)    //IntegrationId atama
                {
                    products.ProductList[i].IntegrationId = i.ToString();
                }

                return products;

            }
        }
    }
    public class PostProduct
    {
        /*************************
         /* HTTPCLIENT KULLANIMI */
        /************************/
        /*
        public static async Task<HttpResponseMessage> PostURI(Uri u, ImportProductsRequest list)
        {

            using (HttpClient httpClient = new HttpClient())
            {

                var json = JsonConvert.SerializeObject(list);
                var data = new StringContent(json, Encoding.UTF8, "application/json");


                var responseMessage = await httpClient.PostAsync(u, data);
                string result = responseMessage.Content.ReadAsStringAsync().Result;

                Console.WriteLine(result);

                return responseMessage;

            }
        }
        */

        /****************************/
        /* HTTPWEBREQUEST KULLANIMI */
        /****************************/

        public static string PostURI(Uri u, ImportProductsRequest list)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(u);

            // httpWebRequest.AllowAutoRedirect = false;  //redirect engelleyince 302 hatası alıyorum.

            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                var json = JsonConvert.SerializeObject(list);

                streamWriter.Write(json);
            }
            try
            {
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    return result.ToString();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }
    }
}