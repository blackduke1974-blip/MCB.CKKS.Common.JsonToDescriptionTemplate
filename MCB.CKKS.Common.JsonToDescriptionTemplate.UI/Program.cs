using Microsoft.Extensions.DependencyInjection;
using MCB.CKKS.Common.DependencyInjection;
using MCB.CKKS.Common.JsonToDescriptionTemplate.Interfaces;
using MCB.CKKS.Common.JsonToDescriptionTemplate.UI;

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

            // Регистрация сервисов из DLL
            services.AddTransient<IJsonDescriptionTemplate, JsonDescriptionTemplate>();
            services.AddTransient<FormMain>();

            // Создание контейнера
            var serviceProvider = services.BuildServiceProvider();

            // Разрешение главной формы через DI
            var formMain = serviceProvider.GetRequiredService<FormMain>();

            Application.Run(formMain);
        }
    }
}