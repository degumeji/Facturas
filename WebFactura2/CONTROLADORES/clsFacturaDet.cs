using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CONTROLADORES
{
    [Serializable]
    public class clsFacturaDet
    {
        private int id;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        private int id_cabecera;

        public int ID_CABECERA
        {
            get { return id_cabecera; }
            set { id_cabecera = value; }
        }

        private string descripcion;

        public string DESCRIPCION
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        private int cantidad;

        private string bases;

        public string BASES
        {
            get { return bases; }
            set { bases = value; }
        }

        public int CANTIDAD
        {
            get { return cantidad; }
            set { cantidad = value; }
        }

        private double valor;

        public double VALOR
        {
            get { return valor; }
            set { valor = value; }
        }

        public clsFacturaDet() {
            this.id = 0;
            this.id_cabecera = 0;
            this.descripcion = "";
            this.bases = "No";
            this.cantidad = 0;
            this.valor = 0;
        }

        public clsFacturaDet(int ID,
                                int ID_CABECERA,
                                string DESCRIPCION,
                                string BASE,
                                int CANTIDAD,
                                double VALOR)
        {
            this.id = ID;
            this.id_cabecera = ID_CABECERA;
            this.descripcion = DESCRIPCION;
            this.bases = BASES;
            this.cantidad = CANTIDAD;
            this.valor = VALOR;
        }
    }
}
