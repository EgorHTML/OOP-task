using System;
using System.Net.Http;
class Program
{
    static public void Main()
    {
        HttpClient client = new HttpClient();
        client.DefaultRequestHeaders.Add("User-Agent", "C# agent");
        string res = getVacanciesSync(2);
        Console.WriteLine(res);

        string getVacanciesSync(int page)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            HttpResponseMessage result =  client.GetAsync("https://api.hh.ru/vacancies?page=" + page).Result;
            watch.Stop();
            Console.WriteLine($"Cинхронный вызов getVacanciesSync: {watch.ElapsedMilliseconds} ms");

            if(!result.IsSuccessStatusCode) throw new Exception("vacancies sync error");

            string vacancies =  result.Content.ReadAsStringAsync().Result;
            return vacancies;
        }
    }
}