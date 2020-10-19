using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CONTROLADORES;
using System.Data;
using System.Data.Odbc;
using System.Data.SqlClient;

namespace CONTROLADORES
{
    public class bdFacturaCab
    {
        private clsFacturaCab clsfacturacab;
        private List<clsFacturaCab> listfacturacab;

        private Boolean respuesta;
        private int numero;

        //conexión             
        private SqlConnection conn;
        private SqlCommand cmd;
        private SqlDataReader reader;

        private string CadenaConexion = "";

        public SqlCommand opencadenaConexion(string query)
        {
            try
            {
                CadenaConexion = "Server=localhost;Database=dbFacturas2;User Id=sa;Password=1234;";
                conn = new SqlConnection(CadenaConexion);
                conn.Open();
                cmd = new SqlCommand(query, conn);
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Exception caught.", ex);
            }
            return cmd;
        }

        public List<clsFacturaCab> consultarCab()
        {
            listfacturacab = new List<clsFacturaCab>();
            try
            {
                string query = "select * from cabFactura;";
                cmd = opencadenaConexion(query);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    clsfacturacab = new clsFacturaCab();
                    clsfacturacab.ID = reader.GetInt32(0);
                    clsfacturacab.DESCRIPCION = reader.GetString(1);
                    clsfacturacab.ID_CLIENTE = reader.GetInt32(2);
                    clsfacturacab.BASEIVA0 = reader.GetDouble(3);
                    clsfacturacab.BASEIVA12 = reader.GetDouble(4);
                    clsfacturacab.IVA = reader.GetDouble(5);
                    clsfacturacab.TOTAL = reader.GetDouble(6);

                    listfacturacab.Add(clsfacturacab);
                }
                reader.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Exception caught.", ex);
            }
            return listfacturacab;

        }
        public clsFacturaCab consultarCabxID(int id)
        {
            try
            {
                string query = "select * from cabFactura WHERE id=" + id;
                cmd = opencadenaConexion(query);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    clsfacturacab = new clsFacturaCab();
                    clsfacturacab.ID = reader.GetInt32(0);
                    clsfacturacab.DESCRIPCION = reader.GetString(1);
                    clsfacturacab.ID_CLIENTE = reader.GetInt32(2);
                    clsfacturacab.BASEIVA0 = reader.GetDouble(3);
                    clsfacturacab.BASEIVA12 = reader.GetDouble(4);
                    clsfacturacab.IVA = reader.GetDouble(5);
                    clsfacturacab.TOTAL = reader.GetDouble(6);

                }
                reader.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Exception caught.", ex);
            }
            return clsfacturacab;

        }
        public int consultarCabMAXID()
        {
            try
            {
                string query = "select ISNULL(max(id) + 1,1) as id from cabFactura;";
                cmd = opencadenaConexion(query);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    numero = reader.GetInt32(0);
                }
                reader.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Exception caught.", ex);
            }
            return numero;

        }
        public int guardarCab(clsFacturaCab cls)
        {
            int numero = consultarCabMAXID();            

            try
            {
                string query = "insert into cabFactura (id, descripcion, id_cliente, baseiva0, baseiva12, iva, total) values (" + numero + ",'"
                                                                                                        + cls.DESCRIPCION + "',"
                                                                                                        + cls.ID_CLIENTE + ","
                                                                                                        + cls.BASEIVA0.ToString().Replace(',', '.') + ","
                                                                                                        + cls.BASEIVA12.ToString().Replace(',', '.') + ","
                                                                                                        + cls.IVA.ToString().Replace(',', '.') + ","
                                                                                                        + cls.TOTAL.ToString().Replace(',', '.') + ")";
                cmd = opencadenaConexion(query);
                cmd.ExecuteNonQuery();
                conn.Close();
                respuesta = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Error:" + ex.Message);
            }

            return numero;
        }
        public Boolean actualizarCab(clsFacturaCab cls)
        {
            respuesta = false;

            try
            {
                string query = "update cabFactura set descripcion = '" + cls.DESCRIPCION + "'," +
                                                   "id_cliente = " + cls.ID_CLIENTE + "," +
                                                   "baseiva0 = " + cls.BASEIVA0 + "," +
                                                   "baseiva12 = " + cls.BASEIVA12 + "," +
                                                   "iva = " + cls.IVA + "," +
                                                   "total = " + cls.TOTAL +
                                                   "where id = " + cls.ID;

                cmd = opencadenaConexion(query);
                cmd.ExecuteNonQuery();
                conn.Close();
                respuesta = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Error:" + ex.Message);
            }

            return respuesta;
        }
    }
}
