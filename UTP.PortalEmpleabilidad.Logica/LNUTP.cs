﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using UTP.PortalEmpleabilidad.Datos;
using UTP.PortalEmpleabilidad.Modelo;
using UTP.PortalEmpleabilidad.Modelo.Vistas.Ofertas;
using UTP.PortalEmpleabilidad.Modelo.Vistas.Alumno;

namespace UTP.PortalEmpleabilidad.Logica
{
    public class LNUTP
    {
        ADUTP adUtp = new ADUTP();

        public DataTable OfertasObtenerPendientes()
        {
            
            return adUtp.OfertasObtenerPendientes();
        }
        public DataTable EmpresaObtenerPendientes()
        {

            return adUtp.EmpresaObtenerPendientes();
        }

        //public DataTable Empresa_ObtenerPorNombre(string nombre)
        //{

        //    return adUtp.Empresa_ObtenerPorNombre(nombre);
        //}

        //public DataTable Empresa_ObtenerPorNombre(string nombre)
        //{

        //    return adUtp.Empresa_ObtenerPorNombre(nombre);
        //}

        public List<EmpresaListaEmpresa> Empresa_ObtenerPorNombre(string nombre)
        {
            List<EmpresaListaEmpresa> listaEjemplo = new List<EmpresaListaEmpresa>();


            DataTable dtResultado = adUtp.Empresa_ObtenerPorNombre(nombre);

            for (int i = 0; i <= dtResultado.Rows.Count - 1; i++)
            {
                EmpresaListaEmpresa vista = new EmpresaListaEmpresa();

                vista.IdEmpresa = Convert.ToInt32(dtResultado.Rows[i]["IdEmpresa"]);
                vista.NombreComercial = dtResultado.Rows[i]["Nombre"].ToString();
                vista.RazonSocial = dtResultado.Rows[i]["Razon"].ToString();
                vista.RUC = dtResultado.Rows[i]["RUC"].ToString();
                vista.Estado = dtResultado.Rows[i]["Estado"].ToString();
                vista.SectorEmpresarial = dtResultado.Rows[i]["SectorEmpresarial"].ToString();
                vista.Clasificacion = dtResultado.Rows[i]["Clasificación"].ToString();
                vista.Ofertas = dtResultado.Rows[i]["Ofertas"].ToString();
                listaEjemplo.Add(vista);
            }

            return listaEjemplo;
        }

        public List<EmpresaListaEmpresa> EmpresaBusquedaAvanzada(VistaEmpresListarOfertas entidad)
        {
            List<EmpresaListaEmpresa> listaEjemplo = new List<EmpresaListaEmpresa>();


            DataTable dtResultado = adUtp.Empresa_BusquedaAvanzada(entidad);

            for (int i = 0; i <= dtResultado.Rows.Count - 1; i++)
            {
                EmpresaListaEmpresa vista = new EmpresaListaEmpresa();

                vista.IdEmpresa = Convert.ToInt32(dtResultado.Rows[i]["IdEmpresa"]);
                vista.NombreComercial = dtResultado.Rows[i]["Nombre"].ToString();
                vista.RazonSocial = dtResultado.Rows[i]["Razon"].ToString();
                vista.RUC = dtResultado.Rows[i]["RUC"].ToString();
                vista.Estado = dtResultado.Rows[i]["Estado"].ToString();
                vista.SectorEmpresarial = dtResultado.Rows[i]["SectorEmpresarial"].ToString();
                vista.Clasificacion = dtResultado.Rows[i]["Clasificación"].ToString();
                vista.Ofertas = dtResultado.Rows[i]["Ofertas"].ToString();
                vista.IdEstadoEmpresa = dtResultado.Rows[i]["Idestado"].ToString();
                vista.IdSector = dtResultado.Rows[i]["Idsector"].ToString();
           
                listaEjemplo.Add(vista);
            }

            return listaEjemplo;
        }

        public List<VistaUTPListaAlumno> ObternerUTPListaAlumno()
        {
            List<VistaUTPListaAlumno> listaAlumno = new List<VistaUTPListaAlumno>();

            DataTable dtResultado = adUtp.UTP_ListarUltimosAlumnos();

            for (int i = 0; i <= dtResultado.Rows.Count - 1; i++)
            {
                VistaUTPListaAlumno vista = new VistaUTPListaAlumno();


                vista.FechaRegistro = dtResultado.Rows[i]["FechaRegistro"].ToString();
                vista.Nombre = dtResultado.Rows[i]["Nombres"].ToString();
                vista.Apellidos = dtResultado.Rows[i]["Apellidos"].ToString();
                vista.Carrera = dtResultado.Rows[i]["Carrera"].ToString();
                vista.Ciclo = dtResultado.Rows[i]["CicloEquivalente"].ToString();
                vista.idAlumno = Convert.ToInt32(dtResultado.Rows[i]["IdAlumno"]);

                listaAlumno.Add(vista);
            }
            return listaAlumno;
        }


        public DataTable UTP_ObtenerUltimosAlumnos(string Dato)
        {

            return adUtp.UTP_ObtenerUltimosAlumnos(Dato);
        }

        //public List<VistaUTPListaAlumno> UTP_ObtenerUltimosAlumnospaginacion()
        //{

        //    List<VistaUTPListaAlumno> listaEjemplo = new List<VistaUTPListaAlumno>();
        //    DataTable dtResultado = adUtp.UTP_ListarUltimosAlumnos();

        //    for (int i = 0; i <= dtResultado.Rows.Count - 1; i++)
        //    {
        //        VistaUTPListaAlumno vista = new VistaUTPListaAlumno();

        //        vista.FechaRegistro = dtResultado.Rows[i]["FechaRegistro"].ToString();
        //        vista.Nombre = dtResultado.Rows[i]["Nombres"].ToString();
        //        vista.Apellidos = dtResultado.Rows[i]["Apellidos"].ToString();
        //        vista.Carrera = dtResultado.Rows[i]["Carrera"].ToString();
        //        vista.Ciclo = dtResultado.Rows[i]["CicloEquivalente"].ToString();

        //        listaEjemplo.Add(vista);
        //    }


        //    return listaEjemplo;
        //}


        public void ActualizarEstadoYUsuarioEC(Empresa empresa)
        {
            if (empresa.UsuarioEC == null) empresa.UsuarioEC = "";

            adUtp.ActualizarEstadoYUsuarioEC(empresa);
        }

        #region Mantenimiento de Usuarios UTP

        public List<UTPUsuario> ObtenerUsuariosUTP()
        {
            List<UTPUsuario> lista = new List<UTPUsuario>();

            DataTable dtResultado = adUtp.ObtenerUsuariosUTP();

            foreach (DataRow fila in dtResultado.Rows)
            {
                UTPUsuario nuevo = new UTPUsuario();
                nuevo.IdUTPUsuario = Convert.ToInt32(fila["IdUTPUsuario"]);
                nuevo.NombreUsuario = Convert.ToString(fila["Usuario"]);
                nuevo.Nombres = Convert.ToString(fila["Nombres"]);
                nuevo.Apellidos = Convert.ToString(fila["Apellidos"]);
                nuevo.SexoDescripcion = Convert.ToString(fila["SexoDescripcion"]);
                nuevo.Correo = Convert.ToString(fila["CorreoElectronico"]);
                nuevo.TelefonoFijo = Convert.ToString(fila["TelefonoFijo"]);
                nuevo.TelefonoCelular = Convert.ToString(fila["TelefonoCelular"]);
                nuevo.EstadoUsuarioDescripcion = Convert.ToString(fila["EstadoUsuarioDescripcion"]);
                
                lista.Add(nuevo);
            }

            return lista;
        }

        public UTPUsuario ObtenerUsuarioUTPPorId(int idUTPUsuario)
        {
            UTPUsuario utpUsuario = new UTPUsuario();
            DataTable dtResultado = adUtp.ObtenerUsuarioUTPPorId(idUTPUsuario);

            if (dtResultado.Rows.Count > 0)
            {
                utpUsuario.IdUTPUsuario = Convert.ToInt32(dtResultado.Rows[0]["IdUTPUsuario"]);
                utpUsuario.NombreUsuario = Convert.ToString(dtResultado.Rows[0]["Usuario"]);
                utpUsuario.Nombres = Convert.ToString(dtResultado.Rows[0]["Nombres"]);
                utpUsuario.Apellidos = Convert.ToString(dtResultado.Rows[0]["Apellidos"]);
                utpUsuario.SexoIdListaValor = Convert.ToString(dtResultado.Rows[0]["SexoIdListaValor"]);                
                utpUsuario.Correo = Convert.ToString(dtResultado.Rows[0]["CorreoElectronico"]);
                utpUsuario.TelefonoFijo = Convert.ToString(dtResultado.Rows[0]["TelefonoFijo"]);
                utpUsuario.TelefonoCelular = Convert.ToString(dtResultado.Rows[0]["TelefonoCelular"]);
                utpUsuario.EstadoUsuarioIdListaValor = Convert.ToString(dtResultado.Rows[0]["EstadoUsuarioIdListaValor"]);                
                utpUsuario.RolIdListaValor = Convert.ToString(dtResultado.Rows[0]["RolIdListaValor"]);
            }

            return utpUsuario;
        }

        public void Insertar(UTPUsuario utpUsuario)
        {
            adUtp.Insertar(utpUsuario);
        }

        public void Actualizar(UTPUsuario utpUsuario)
        {
            adUtp.Actualizar(utpUsuario);
        }

        #endregion
    }
}
