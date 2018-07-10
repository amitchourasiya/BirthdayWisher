using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
//using ConsoleApp2.Models;
using System.Net.Http.Formatting;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
           // RunAsync().Wait();
            getExcluion().Wait();
        }


        static async Task getExcluion()
        {
            /// api / BirthdayWishExclusions
            /// 
            
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://eohmc-acme-api.azurewebsites.net/swagger/");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                var response = await client.GetAsync("/api/BirthdayWishExclusions");
                if (response.IsSuccessStatusCode)
                {
                    //var objRes= JsonConvert.DeserializeObject<List<Employee>>
                    var jsonstring = await response.Content.ReadAsStreamAsync();
                    var data = JsonConvert.DeserializeObject<List<Int64>>(await response.Content.ReadAsStringAsync());

                    foreach (Int64 emp in data)
                    {
                        //Employee emp = response.Content.ReadAsStringAsync<Employee>;              
                                                
                        Console.WriteLine("First Name =>{0}", emp);
                    }

                    Console.ReadLine();


                }

            }

            //var result;
            Console.WriteLine("GET");
        }
        static async Task RunAsync()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://eohmc-acme-api.azurewebsites.net/swagger/");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //var result;
                Console.WriteLine("GET");


                string date2 = "10/10/1980";
                DateTime date1 = Convert.ToDateTime(date2);
                var response = await client.GetAsync("/api/Employees");
                if (response.IsSuccessStatusCode)
                {
                    //var objRes= JsonConvert.DeserializeObject<List<Employee>>
                    var jsonstring = await response.Content.ReadAsStreamAsync();
                    var data = JsonConvert.DeserializeObject<List<Employee>>(await response.Content.ReadAsStringAsync());

                    var results = data.Where(x => x.DateOfBirth >= date1);
                    var count = 0;
                    foreach (Employee emp in results)
                    {
                        //Employee emp = response.Content.ReadAsStringAsync<Employee>;              

                        count++;
                        Console.WriteLine("First Name =>{0}\t{1}\t{2}", emp.Name, emp.Lastname, count);
                    }

                    Console.ReadLine();


                }
            }
        }
    }
}
