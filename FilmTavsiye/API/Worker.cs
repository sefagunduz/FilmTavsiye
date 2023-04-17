using BLL.Abstract;

namespace API
{
    public class Worker : BackgroundService
    {
        private readonly IApiManager apiManager;
        public Worker(IApiManager apiManager)
        {
            this.apiManager = apiManager;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            bool reply = await apiManager.SaveDatabaseAsync();
            Console.WriteLine("api service is worked : {0}", reply);

            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(3600000, stoppingToken);
                bool reply2 = await apiManager.SaveDatabaseAsync();
                Console.WriteLine("api worker is worked : {0}", reply2);
            }
        }
    }
}
