using System;
using System.Diagnostics;
using System.Net.Http;
//use newtonsoft to convert json to c# objects.
using Newtonsoft.Json.Linq;
namespace PokeAPI
{
    class Program
    {
        static void Main(string[] args)
        {

            GetPokemon();
            Console.WriteLine("Enter Pokemon id : ");
            int num = Convert.ToInt16(Console.ReadLine());
            GetOnePokemon(num);
            Console.ReadLine();
            Console.ReadKey();
        }

        public static async void GetPokemon()
        {

            string baseUrl = "http://pokeapi.co/api/v2/pokemon/";

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    using (HttpResponseMessage res = await client.GetAsync(baseUrl))
                    {
                        using (HttpContent content = res.Content)
                        {
                            var data = await content.ReadAsStringAsync();
                            Debug.WriteLine(data);
                            if (data != null)
                            {
                                Console.WriteLine("data------------{0}", JObject.Parse(data)["results"]);
                            }
                            else
                            {
                                Console.WriteLine("NO Data----------");
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine("Exception Hit------------");
                Console.WriteLine(exception);
            }
        } // GetPokemon

        public static async void GetOnePokemon(int id)
        {

            string baseUrl = "http://pokeapi.co/api/v2/pokemon/" + id;

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    using (HttpResponseMessage res = await client.GetAsync(baseUrl))
                    {
                        using (HttpContent content = res.Content)
                        {
                            var data = await content.ReadAsStringAsync();
                            //Debug.WriteLine(data);

                            if (data != null)
                            {

                                //var dataObj = JObject.Parse(data);

                                var result = JObject.Parse(data)["abilities"];
                                Debug.WriteLine(result);

                                PokeItem pokeItem = new PokeItem(name: $"{result[0]["ability"]["name"]}");

                                Console.WriteLine("Pokemon Name: {0}", pokeItem.Name);

                            }
                            else
                            {
                                Console.WriteLine("NO Data----------");
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine("Exception Hit------------");
                Console.WriteLine(exception);
            }
        } // GetPokemon


    }
}
