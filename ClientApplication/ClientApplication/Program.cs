using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ClientApplication
{
    class Program
    {
        static HttpClient client = new HttpClient();
        static void Main()
        {
            HttpResponseMessage response;
            string responseBody;
            for (int i = 0; i < 1; i++)
            {
                Console.WriteLine($"Введите предложение {i+1}:");
                response = client.GetAsync($"https://localhost:44324/?text={Console.ReadLine()}").Result;
                responseBody = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine(responseBody);
            }

            Random random = new Random();
            for (int i = 0; i < 10; i++)
            {
                response = client.PostAsync("https://localhost:44324/",
                                    new StringContent(JsonConvert.SerializeObject(new User
                                    {
                                        Id = random.Next(),
                                        Name = random.Next().ToString(),
                                        IIN = random.Next().ToString(),
                                        Surname = random.Next().ToString(),
                                        MiddleName = random.Next().ToString(),
                                        DateOfBirth = DateTime.Now
                                    }), Encoding.UTF8, "application/json")).Result;
                responseBody = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine(responseBody);
            }


            response = client.GetAsync($"https://localhost:44324/?text=").Result;
            List<User> listUsers = JsonConvert.DeserializeObject<List<User>>(response.Content.ReadAsStringAsync().Result);
            for (int i = 0; i < listUsers.Count; i++)
            {
                Console.WriteLine(listUsers[i].Id);
                Console.WriteLine(listUsers[i].IIN);
                Console.WriteLine(listUsers[i].Surname);
                Console.WriteLine(listUsers[i].Name);
                Console.WriteLine(listUsers[i].MiddleName);
                Console.WriteLine(listUsers[i].DateOfBirth);
                Console.WriteLine();
 
            }

        }
    }
}