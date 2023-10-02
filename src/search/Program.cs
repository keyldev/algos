using System.Diagnostics;
using System.Net;

namespace search
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string url = "https://www.dropbox.com/s/im722je8vi6xzki/app-debug.apk?dl=1";
            DownloadFileAsync(url).Wait();

            Console.WriteLine("Загрузка завершена.");
            Console.ReadLine();
        }

        private static async Task DownloadFileAsync(string url)
        {
            using (var client = new WebClient())
            {
                // Включаем события прогресса скачивания
                client.DownloadProgressChanged += (sender, e) =>
                {
                    Console.Write($"\rСкачивание: {e.ProgressPercentage}% ({e.BytesReceived}/{e.TotalBytesToReceive} байт)");
                };

                // Включаем событие завершения скачивания
                client.DownloadFileCompleted += (sender, e) =>
                {
                    Console.WriteLine($"\nСкачивание файла завершено.");
                };

                // Запускаем асинхронную загрузку файла
                await client.DownloadFileTaskAsync(new Uri(url), "file.txt");
            }
        }
    }
}