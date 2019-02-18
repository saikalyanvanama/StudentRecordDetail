using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TestApp.Lib.Common;
using TestApp.Lib.Models;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;

namespace TestApp.Lib
{
    public static class Factory
    {
        public static async Task<WeatherData> GetCurrentWeather(string cityName)
        {

            WeatherData result = null;
            try
            {
                using (var client = new HttpClient())
                {
                    
                    var appId = ConfigurationManager.AppSettings[Constants.WeatherAppId].ToString();
                    var weatherRequestUri = ConfigurationManager.AppSettings[Constants.WeatherRequestUri].ToString();
                    weatherRequestUri = String.Format(weatherRequestUri, cityName, appId);
                    var jsonData = await client.GetStringAsync(weatherRequestUri);
                    result = JsonConvert.DeserializeObject<WeatherData>(jsonData);
                }
                return result;
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public static async Task<ProductResult> GetProductList()
        {
            
            ProductResult result = null;
            try
            {
                using (var client = new HttpClient())
                {
                    //var productRequestUri = ConfigurationManager.AppSettings["http://api.bklo.in:3000/getAllProductsJson"].ToString();
                    var productRequestUri = String.Format("http://api.bklo.in:3000/getAllProductsJson");
                    var jsonData = await client.GetStringAsync(productRequestUri);
                    
                    result = JsonConvert.DeserializeObject<ProductResult>(jsonData);
                   // System.IO.File.WriteAllText(@"D:\KalyanWork\Git\Classroom-Demo\TestApp\Data\BooksData.txt", jsonData);

                    System.IO.File.WriteAllText(@"E:\SumWork\Git\Classroom-Demo\TestApp\Data\BooksData.txt", jsonData);
                    var text = System.IO.File.ReadAllText(@"E:\SumWork\Git\Classroom-Demo\TestApp\Data\BooksData.txt");
                  var  text2 = JsonConvert.DeserializeObject<ProductResult>(text);
                    if(result.timeStamp!=text2.timeStamp)
                    {
                        System.IO.File.WriteAllText(@"E:\SumWork\Git\Classroom-Demo\TestApp\Data\BooksData.txt", jsonData);
                    }
                    
                    
                    

                }
              //  return result;
            }
            catch (Exception ex)
            {

            }
            return result;
        }

    }
}
