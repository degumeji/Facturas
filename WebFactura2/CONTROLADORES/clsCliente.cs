using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CONTROLADORES
{
    [Serializable]
    public class clsCliente
    {
        private int id;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        private string cedula;

        public string CEDULA
        {
            get { return cedula; }
            set { cedula = value; }
        }

        private string nombre;

        public string NOMBRE
        {
            get { return nombre; }
            set { nombre = value; }
        }

        private string apellido;

        public string APELLIDO
        {
            get { return apellido; }
            set { apellido = value; }
        }

        private string direccion;

        public string DIRECCION
        {
            get { return direccion; }
            set { direccion = value; }
        }

        private string ciudad;

        public string CIUDAD
        {
            get { return ciudad; }
            set { ciudad = value; }
        }

        private string telefono;

        public string TELEFONO
        {
            get { return telefono; }
            set { telefono = value; }
        }

        private string correo;

        public string CORREO
        {
            get { return correo; }
            set { correo = value; }
        }


        public clsCliente() {
            this.id = 0;
            this.cedula = "";
            this.nombre = "";
            this.apellido = "";
            this.direccion = "";
            this.ciudad = "";
            this.telefono = "";
            this.correo = "";
        }

        public clsCliente(int ID,
                            string CEDULA,
                            string NOMBRE,
                            string APELLIDO,
                            string DIRECCION,
                            string CIUDAD,
                            string TELEFONO,
                            string CORREO)
        {
            this.id = ID;
            this.cedula = CEDULA;
            this.nombre = NOMBRE;
            this.apellido = APELLIDO;
            this.direccion = DIRECCION;
            this.ciudad = CIUDAD;
            this.telefono = TELEFONO;
            this.correo = CORREO;
        }
    }
}
