using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TareaMVVM.Models;

namespace TareaMVVM.Controller
{
    public class DataBaseSQLite
    {
        readonly SQLiteAsyncConnection db;

        public DataBaseSQLite(string pathdb)
        {
            db = new SQLiteAsyncConnection(pathdb);
            db.CreateTableAsync<Empleados>().Wait();
        }

        
        public Task<List<Empleados>> ObtenerListaEmpleados()
        {
            return db.Table<Empleados>().ToListAsync();
        }

        
        public Task<Empleados> ObtenerEmpleado(int pcodigo)
        {
            return db.Table<Empleados>()
                .Where(i => i.id == pcodigo)
                .FirstOrDefaultAsync();
        }

        
        public Task<int> GrabarEmpleado(Empleados empl)
        {
            if (empl.id != 0)
            {
                return db.UpdateAsync(empl);
            }
            else
            {
                return db.InsertAsync(empl);
            }

        }

        public Task<int> EliminarEmpleado(Empleados emp)
        {
            return db.DeleteAsync(emp);
        }
    }
}
