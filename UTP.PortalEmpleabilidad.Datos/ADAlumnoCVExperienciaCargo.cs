﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTP.PortalEmpleabilidad.Datos
{
    public class ADAlumnoCVExperienciaCargo
    {
        ADConexion cnn = new ADConexion();
        

        public DataTable ObtenerAlumnoCVExperienciaCargoPorIdCVYIdExperiencia(int IdCV, int IdExperienciaCargo)
        {
            DataTable dtResultado = new DataTable();

            using (SqlConnection conexion = new SqlConnection(cnn.Conexion()))
            {
                SqlCommand cmd = new SqlCommand();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "AlumnoCVExperienciaCargo_ObtenerPorIdCVYIdExperienciaCargo";
                cmd.Connection = conexion;
                conexion.Open();
                cmd.Parameters.Add(new SqlParameter("@IdExperienciaCargo", SqlDbType.Int)).Value = IdExperienciaCargo;
                cmd.Parameters.Add(new SqlParameter("@IdCV", SqlDbType.Int)).Value = IdCV;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                dtResultado = new DataTable();
                da.Fill(dtResultado);
                conexion.Close();
            }

            return dtResultado;
        }

        public void DesactivarPorCV(int IdCV)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "AlumnoCVExperienciaCargo_DesactivarPorCV";
            cmd.Connection = cnn.cn;
            cnn.Conectar();
            cmd.Parameters.Add(new SqlParameter("@IdCV", SqlDbType.Int)).Value = IdCV;
            cmd.ExecuteNonQuery();
            cnn.Desconectar();
        }

        public void AgregarOrModificar(int IdCV, int IdExperienciaCargo, string Usuario)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "AlumnoCVExperienciaCargo_AgregarPorCV";
            cmd.Connection = cnn.cn;
            cnn.Conectar();
            cmd.Parameters.Add(new SqlParameter("@IdCV", SqlDbType.Int)).Value = IdCV;
            cmd.Parameters.Add(new SqlParameter("@IdExperienciaCargo", SqlDbType.Int)).Value = IdExperienciaCargo;
            cmd.Parameters.Add(new SqlParameter("@Usuario", SqlDbType.VarChar,50)).Value = Usuario;
            cmd.ExecuteNonQuery();
            cnn.Desconectar();
        }
    }
}
