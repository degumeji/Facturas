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
    public class bdFacturaDet
    {
        private clsFacturaDet clsfacturacdet;
        private List<clsFacturaDet> listfacturadet;

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

        public List<clsFacturaDet> consultarDet()
        {
            listfacturadet = new List<clsFacturaDet>();
            try
            {
                string query = "select * from detFactura;";
                cmd = opencadenaConexion(query);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    clsfacturacdet = new clsFacturaDet();
                    clsfacturacdet.ID = reader.GetInt32(0);
                    clsfacturacdet.ID_CABECERA = reader.GetInt32(1);
                    clsfacturacdet.DESCRIPCION = reader.GetString(2);
                    clsfacturacdet.BASES = reader.GetString(3);
                    clsfacturacdet.CANTIDAD = reader.GetInt32(4);
                    clsfacturacdet.VALOR = reader.GetDouble(5);

                    listfacturadet.Add(clsfacturacdet);
                }
                reader.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Exception caught.", ex);
            }
            return listfacturadet;

        }
        public clsFacturaDet consultarDetxID(int id)
        {
            try
            {
                string query = "select * from detFactura WHERE id=" + id;
                cmd = opencadenaConexion(query);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    clsfacturacdet = new clsFacturaDet();
                    clsfacturacdet.ID = reader.GetInt32(0);
                    clsfacturacdet.ID_CABECERA = reader.GetInt32(1);
                    clsfacturacdet.DESCRIPCION = reader.GetString(2);
                    clsfacturacdet.BASES = reader.GetString(3);
                    clsfacturacdet.CANTIDAD = reader.GetInt32(4);
                    clsfacturacdet.VALOR = reader.GetDouble(5);

                }
                reader.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Exception caught.", ex);
            }
            return clsfacturacdet;

        }
        public int consultarDetMAXID()
        {
            try
            {
                string query = "select ISNULL(max(id) + 1,1) as id from detFactura;";
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
        public Boolean guardarDet(List<clsFacturaDet> listcls)
        {
            respuesta = false;            
            int id = 1;

            try
            {
                foreach (var cls in listcls)
                {
                    string bases = "";
                    if (cls.BASES == "Si")
                    {
                        bases = "S";
                    }
                    else {
                        bases = "N";
                    }
                    string query = "insert into detFactura (id, id_cabecera, descripcion, base, cantidad, valor) values (" + id + ","
                                                                                                        + cls.ID_CABECERA + ",'"
                                                                                                        + cls.DESCRIPCION + "','"
                                                                                                        + bases + "',"
                                                                                                        + cls.CANTIDAD.ToString().Replace(',', '.') + ","
                                                                                                        + cls.VALOR.ToString().Replace(',', '.') + ")";
                    cmd = opencadenaConexion(query);
                    cmd.ExecuteNonQuery();
                    id++;
                }
                conn.Close();
                respuesta = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Error:" + ex.Message);
            }

            return respuesta;
        }
        public Boolean actualizarDet(clsFacturaDet cls)
        {
            respuesta = false;

            try
            {
                string query = "update detFactura set id_cabecera = " + cls.ID_CABECERA + "," +
                                                   "descripcion = '" + cls.DESCRIPCION + "'," +
                                                   "base = '" + cls.BASES + "'," +
                                                   "cantidad = " + cls.CANTIDAD + "," +
                                                   "valor = " + cls.VALOR +
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
