using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGA.DAO.Comunes;
using SIGA.Entities.Seguridad;
using System.Data.SqlClient;
using System.Data;
using SIGA.DAO.Seguridad;

namespace SIGA.Business.Seguridad
{
    public class UsuarioBusiness
    {


        public DataTable ObtenerPerfilesPorUsuario(Int16 Usuario, Int16 Perfil)
        {
            UsuarioDao _GeneralRepository = new UsuarioDao();
            var result = _GeneralRepository.ObtenerPerfilesPorUsuario(Usuario, Perfil);
            return result;

        }
        public List<Usuario> ObtenerUsuarios(SIGA.Entities.Seguridad.Usuario objUsuario)
        {
            UsuarioDao _GeneralRepository = new UsuarioDao();
            return _GeneralRepository.ObtenerUsuarios(objUsuario);
        }

        public int RegistrarUsuario(Usuario objUsuario, List<PerfilUsuario> ListaPerfilUsuario)
        {
            int Codigo = 0;
            UsuarioDao _GeneralRepository = new UsuarioDao();
            Codigo = _GeneralRepository.RegistrarUsuario(objUsuario, ListaPerfilUsuario);
            return Codigo;
        }


        public int ActualizarUsuario(Usuario objUsuario, List<PerfilUsuario> ListaPerfilUsuario)
        {
            int Codigo = 0;
            UsuarioDao _GeneralRepository = new UsuarioDao();
            Codigo = _GeneralRepository.ActualizarUsuario(objUsuario, ListaPerfilUsuario);
            return Codigo;
        }


        public Usuario ObtenerUsuarioPorCodigo(Usuario objUsuario)
        {
            UsuarioDao _GeneralRepository = new UsuarioDao();
            return _GeneralRepository.ObtenerUsuarioPorCodigo(objUsuario);
        }
        public int ValidarUsuario(Usuario objUsuario)
        {
            int Codigo = 0;
            UsuarioDao _GeneralRepository = new UsuarioDao();
            Codigo = _GeneralRepository.ValidarUsuario(objUsuario);
            return Codigo;
        }

        public int ValidarClave(Usuario objUsuario)
        {
            int Codigo = 0;
            UsuarioDao _GeneralRepository = new UsuarioDao();
            Codigo = _GeneralRepository.ValidarClave(objUsuario);
            return Codigo;
        }

        public int ValidarCuentaUsuario(Usuario objUsuario)
        {
            int Codigo = 0;
            UsuarioDao _GeneralRepository = new UsuarioDao();
            Codigo = _GeneralRepository.ValidarCuentaUsuario(objUsuario);
            return Codigo;
        }

        public bool ValidarIngresoUsuario(string Login, string Clave, ref string Mensaje)
        {
            bool Acceso = false;

            UsuarioDao _GeneralRepository = new UsuarioDao();
            SIGA.DAO.Ventas.CajaDao objCaja = new SIGA.DAO.Ventas.CajaDao();

            var resultado = _GeneralRepository.ValidarIngresoUsuario(Login, Clave);

            if (resultado.Rows.Count > 0)
            {

                if (resultado.Rows[0]["EstCodigo"].ToString() == "A")
                {

                    Acceso = true;

                }

                else
                {
                    Mensaje = "La cuenta de Usuario esta inactiva, consultar con el administrador..!";
                    Acceso = false;
                }

            }
            else
            {
                Mensaje = "Usuario o clave incorrecta";
            }

            return Acceso;

        }

        public List<Usuario> ObtenerContactoRepresentante()
        {
            UsuarioDao _GeneralRepository = new UsuarioDao();
            return _GeneralRepository.ObtenerContactoRepresentante();
        }

        public DataTable ObtenerOpcionesPorUsuario(int CodigoUsuario)
        {
            UsuarioDao _GeneralRepository = new UsuarioDao();
            return _GeneralRepository.ObtenerOpcionesPorUsuario(CodigoUsuario);
        }

        public DataTable BuscarUsuarioPorClave(string Clave)
        {
            UsuarioDao _GeneralRepository = new UsuarioDao();
            return _GeneralRepository.BuscarUsuarioPorClave(Clave);
        }
    }
}


