namespace Urbonas_Ernestas_BikeStores;
using EEFBikeStores;
using NegocioBikeStores;

class Program {
    static void Main() {
        using (var context = new BikeStoresContext()) {
            // Obtener la lista de marcas
            var brands = context.Customers.ToList();

            // Iterar y mostrar las marcas
            foreach (var brand in brands) {
                Console.WriteLine(brand.ToString());
            }
            Console.WriteLine();
            Console.WriteLine("------------------------");


        }
        Ventas v = new Ventas();
        List<Order> o = v.ListarPedidosCLiente(1);
        foreach (var order in o) {
            Console.WriteLine(order.ToString());
        }
        Console.WriteLine("------------------------");
        o = v.ListarPedidosEmpleado(1);
        foreach (var order in o) {
            Console.WriteLine(order.ToString());
        }
    }
}