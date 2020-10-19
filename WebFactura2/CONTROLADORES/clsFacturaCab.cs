using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CONTROLADORES
{
    [Serializable]
    public class clsFacturaCab
    {
        private int id;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        private string descripcion;

        public string DESCRIPCION
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        private int id_cliente;

        public int ID_CLIENTE
        {
            get { return id_cliente; }
            set { id_cliente = value; }
        }

        private double baseiva0;

        public double BASEIVA0
        {
            get { return baseiva0; }
            set { baseiva0 = value; }
        }

        private double baseiva12;

        public double BASEIVA12
        {
            get { return baseiva12; }
            set { baseiva12 = value; }
        }

        private Double iva;

        public Double IVA
        {
            get { return iva; }
            set { iva = value; }
        }

        private double total;

        public double TOTAL
        {
            get { return total; }
            set { total = value; }
        }

        public clsFacturaCab() {
            this.id = 0;
            this.descripcion = "";
            this.id_cliente = 0;
            this.baseiva0 = 0;
            this.baseiva12 = 0;
            this.iva = 0;
            this.total = 0;
        }

        public clsFacturaCab(int ID,
                                string DESCRIPCION,
                                int ID_CLIENTE,                                
                                double BASEIVA0,
                                double BASEIVA12,
                                double IVA,
                                double TOTAL) {
            this.id = ID;
            this.descripcion = DESCRIPCION;
            this.id_cliente = ID_CLIENTE;
            this.baseiva0 = BASEIVA0;
            this.baseiva12 = BASEIVA12;
            this.iva = IVA;
            this.total = TOTAL;
        }

    }
}
