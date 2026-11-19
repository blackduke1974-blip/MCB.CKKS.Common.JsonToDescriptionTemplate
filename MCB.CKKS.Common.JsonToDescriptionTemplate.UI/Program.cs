using Microsoft.Extensions.DependencyInjection;
using MCB.CKKS.Common.DependencyInjection;
using MCB.CKKS.Common.JsonToDescriptionTemplate.Interfaces;

namespace MCB.CKKS.Common.JsonToDescriptionTemplate.UI
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            var services = new ServiceCollection();
            // Регистрация всех сервисов с маркировкой интерфейсами ITransientService/IScopedService
            services.RegisterServices();
            // Создание контейнера и разрешение главной формы через DI
            var serviceProvider = services.BuildServiceProvider();

            var formMain = serviceProvider.GetRequiredService<FormMain>();
            Application.Run(formMain);
        }
    }
}