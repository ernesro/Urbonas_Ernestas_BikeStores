using BikeStoresEntidades;
using Microsoft.EntityFrameworkCore;

///<author> Ernestas Urbonas </author>
namespace EEFBikeStores {
    public class StaffDAO : IDisposable {
        bool disposed;

        BikeStoresContext context = new BikeStoresContext();
        public StaffDAO() {
            disposed = false;
        }

        public IList<Staff> Listar() {
            using (var context = new BikeStoresContext()) {
                // Return the list of data from the database
                var data = context.Staffs

                .Include(Stores => Stores.Store)
                .Include(Orders => Orders.Orders)
                .Include(Managers => Managers.Manager)
                .Include(InverseManagers => InverseManagers.InverseManager)
                .ToList();
                return data;
            }
        }

        public Staff Listar(String ID) {
            using (var _context = new BikeStoresContext()) {
                var query = from st in _context.Staffs
                            where st.StaffId.ToString() == ID
                            select st;

                var Staff = query.FirstOrDefault<Staff>();
                return Staff;
            }
        }

        public void Insertar(Staff dato) {
            using (var context = new BikeStoresContext()) {
                context.Entry(dato).State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Actualizar(Staff modificado) {
            using (var context = new BikeStoresContext()) {
                context.Entry(modificado).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void Borrar(Staff dato) {
            using (var context = new BikeStoresContext()) {
                context.Entry(dato).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public BikeStoresContext Context() {
            return context;
        }

        public void Dispose() {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing) {
            if (disposed)
                return;

            if (disposing) {
                // Free any other managed objects here.
                //Liberar recursos no manejados como ficheros, conexiones a bd, etc.
            }

            disposed = true;
        }
    }
}
