using market.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace market.Data
{
    public class Datos
    {

        public static DataTable Listar(string nombreProcedimiento, List<Parametro> parametros = null)
        {
            Conexion conexion = new Conexion();

            try
            {
                conexion.connection.Open();
                SqlCommand cmd = new SqlCommand(nombreProcedimiento, conexion.connection);
                cmd.CommandType = CommandType.StoredProcedure;

                if (parametros != null)
                {
                    foreach (var parametro in parametros)
                    {
                        cmd.Parameters.AddWithValue(parametro.Nombre, parametro.Valor);
                    }
                }
                DataTable tabla = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(tabla);


                return tabla;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                conexion.connection.Close();
            }
        }

        public static bool Ejecutar(string nombreProcedimiento, List<Parametro> parametros = null)
        {
            Conexion conexion = new Conexion();

            try
            {
                conexion.connection.Open();
                SqlCommand cmd = new SqlCommand(nombreProcedimiento, conexion.connection);
                cmd.CommandType = CommandType.StoredProcedure;

                if (parametros != null)
                {
                    foreach (var parametro in parametros)
                    {
                        cmd.Parameters.AddWithValue(parametro.Nombre, parametro.Valor);
                    }
                }

                int i = cmd.ExecuteNonQuery();

                return (i > 0) ? true : false;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                conexion.connection.Close();
            }
        }
        public async Task InsertarUsuario(Usuario usuario)
        {

            Conexion conexion = new Conexion();

            SqlCommand cmd = new SqlCommand("SaveData", conexion.connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@correo", usuario.Correo);
            cmd.Parameters.AddWithValue("@nombre", usuario.Nombres);
            cmd.Parameters.AddWithValue("@apellido", usuario.Apellidos);
            cmd.Parameters.AddWithValue("@genero", usuario.Genero);

            await conexion.connection.OpenAsync();
            await cmd.ExecuteNonQueryAsync();
        }


        public async Task UpdateUsuario(Usuario usuario)
        {
            if (usuario != null)
            {

                Conexion conexion = new Conexion();

                SqlCommand cmd = new SqlCommand("UpdateUsuario", conexion.connection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@correo", usuario.Correo);
                cmd.Parameters.AddWithValue("@nombre", usuario.Nombres);
                cmd.Parameters.AddWithValue("@apellido", usuario.Apellidos);
                cmd.Parameters.AddWithValue("@genero", usuario.Genero);

                await conexion.connection.OpenAsync();
                await cmd.ExecuteNonQueryAsync();
            }
        }

    }
}
