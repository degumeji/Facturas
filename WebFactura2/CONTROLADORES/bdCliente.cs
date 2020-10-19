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
    public class bdCliente
    {
        private clsCliente clscliente;
        private List<clsCliente> listcliente;

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

        public List<clsCliente> consultarClientes()
        {
            listcliente = new List<clsCliente>();
            try
            {
                string query = "SELECT * FROM cliente";
                cmd = opencadenaConexion(query);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    clscliente = new clsCliente();
                    clscliente.ID = reader.GetInt32(0);
                    clscliente.CEDULA = reader.GetString(1);
                    clscliente.NOMBRE = reader.GetString(2);
                    clscliente.APELLIDO = reader.GetString(3);
                    clscliente.DIRECCION = reader.GetString(4);
                    clscliente.CIUDAD = reader.GetString(5);
                    clscliente.TELEFONO = reader.GetString(6);
                    clscliente.CORREO = reader.GetString(7);

                    listcliente.Add(clscliente);
                }
                reader.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Exception caught.", ex);
            }
            return listcliente;

        }
        public clsCliente consultarClientexID(int id)
        {
            try
            {
                string query = "SELECT * FROM cliente WHERE id=" + id;
                cmd = opencadenaConexion(query);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    clscliente = new clsCliente();
                    clscliente.ID = reader.GetInt32(0);
                    clscliente.CEDULA = reader.GetString(1);
                    clscliente.NOMBRE = reader.GetString(2);
                    clscliente.APELLIDO = reader.GetString(3);
                    clscliente.DIRECCION = reader.GetString(4);
                    clscliente.CIUDAD = reader.GetString(5);
                    clscliente.TELEFONO = reader.GetString(6);
                    clscliente.CORREO = reader.GetString(7);

                }
                reader.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Exception caught.", ex);
            }
            return clscliente;

        }
        public int consultarClienteMAXID()
        {
            try
            {
                string query = "select ISNULL(max(id) + 1,1) as id from cliente;";
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
        public int guardarCliente(clsCliente cls)
        {
            int numero = consultarClienteMAXID();

            try
            {
                string query = "insert into cliente (id, cedula, nombre, apellido, direccion, ciudad, telefono, correo) values (" + numero + ",'"
                                                                                                                                    + cls.CEDULA + "','"
                                                                                                                                    + cls.NOMBRE + "','"
                                                                                                                                    + cls.APELLIDO + "','"
                                                                                                                                    + cls.DIRECCION + "','"
                                                                                                                                    + cls.CIUDAD + "','"
                                                                                                                                    + cls.TELEFONO + "','"
                                                                                                                                    + cls.CORREO + "')";
                cmd = opencadenaConexion(query);
                cmd.ExecuteNonQuery();
                conn.Close();                
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Error:" + ex.Message);
            }

            return numero;
        }
        public Boolean actualizarCliente(clsCliente cls)
        {
            respuesta = false;

            try
            {
                string query = "update cliente set cedula = '" + cls.CEDULA + "'," +
                                                   "nombre = '" + cls.NOMBRE + "'," +
                                                   "apellido = '"+ cls.APELLIDO + "'," +
                                                   "direccion = '"+ cls.DIRECCION + "'," +
                                                   "ciudad = '"+ cls.CIUDAD + "'," +
                                                   "telefono = '"+ cls.TELEFONO + "'," +
                                                   "correo = '"+ cls.CORREO + "'" +
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
