using System;
using System.Net.Http;
using System.Threading.Tasks;

class Program
{
    async static public Task Main()
    {
        HttpClient client = new HttpClient();
        client.DefaultRequestHeaders.Add("User-Agent", "C# agent");
        string res = await getVacanciesAsync(1);
        Console.WriteLine(res);

        string res2 = await getLanguagesAsync(1);
        Console.WriteLine(res2);

        async Task<string> getVacanciesAsync(int page)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            HttpResponseMessage result =await client.GetAsync("https://api.hh.ru/vacancies?page="+ page);
            watch.Stop();
            Console.WriteLine($"Асинхронный вызов getVacanciesAsync: {watch.ElapsedMilliseconds} ms");

            if (!result.IsSuccessStatusCode) throw new Exception("vacancies Async error");

            string vacancies = await result.Content.ReadAsStringAsync();
            return vacancies;
        }

        async Task<string> getLanguagesAsync(int page)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            HttpResponseMessage result = await client.GetAsync("https://api.hh.ru/languages?page=" + page);
            watch.Stop();
            Console.WriteLine($"Асинхронный вызов getVacanciesAsync: {watch.ElapsedMilliseconds} ms");

            if (!result.IsSuccessStatusCode) throw new Exception("vacancies Async error");

            string vacancies = await result.Content.ReadAsStringAsync();
            return vacancies;
        }

       
    }
}