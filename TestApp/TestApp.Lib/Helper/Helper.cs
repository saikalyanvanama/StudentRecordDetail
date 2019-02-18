using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Lib;
using TestApp.Lib.Models;

namespace TestApp.Helper
{
    public static class Helper
    {
        
        public static async Task<String> GetWeatherByCity(string cityName)
        {
            var weatherData = await Factory.GetCurrentWeather(cityName);
            if (weatherData != null)
                return weatherData.main.temp.ToString();
            return "0";
        }
    }
}
