using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace TareaMVVM.Models
{
    public class Empleados
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string nombre { get; set; }    
        public string apellido { get; set; }
        public string edad { get; set; }
        public string direccion { get; set; }
        public string puesto { get; set; }
    }
}
