using System;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace ConnectionAPIGUI
{
    internal class Commands
    {

        public static string addFilm(ConnectionWithDataBase conn, string keyword)
        {
            string strInsert = "";
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://www.omdbapi.com/");
            client.DefaultRequestHeaders.Accept.Add(
               new MediaTypeWithQualityHeaderValue("application/json"));
            var response = client.GetAsync($"?apikey=d554bc03&s={keyword}&page=1").Result;
            if (response.IsSuccessStatusCode)
            {
                // Parse the response body
                var dataObjects = response.Content.ReadAsStringAsync().Result;
                Answer ans = JsonConvert.DeserializeObject<Answer>(dataObjects);
                if (ans != null)
                {
                    
                    strInsert = conn.Insert(ans);
                }
                else
                {
                    Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                }

            }
            return strInsert;
        }
        public static void DeleteMovie(ConnectionWithDataBase conn,string titleToDelete)
        {
            conn.Delete(titleToDelete);
            Console.WriteLine($"Фильм с названием {titleToDelete} удален");
        }
        public static void Count(ConnectionWithDataBase conn)
        {
            int movieCount = conn.Count();
            Console.WriteLine($"Количество фильмов в базе данных: {movieCount}");
        }

        
        public static void InfoByTitle(ConnectionWithDataBase conn)
        {
            Console.WriteLine("Введите часть названия для поиска информации: ");
            string partialTitle = Console.ReadLine();

            conn.InfoByTitle(partialTitle);
        }

    }
   }




