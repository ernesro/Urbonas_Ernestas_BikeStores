using NegocioBikeStores;
///<author> Ernestas Urbonas </author>
namespace BikeStoresPresentacion {
    internal static class Program {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.

            ApplicationConfiguration.Initialize();
            using (var ventas = new Ventas())
                Application.Run(new AltaPedido(
                  ventas.ListarEmpleados().FirstOrDefault()!,
                  ventas.ListarCustomers().FirstOrDefault()!
                ));
            //Application.Run(new Login());
            //Application.Run(Log);

            //fabiola.jackson@bikes.shop
        }
    }
}