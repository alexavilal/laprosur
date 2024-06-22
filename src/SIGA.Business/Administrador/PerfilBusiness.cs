using System.Collections.Generic;
using SIGA.DAO.Administrador;
using SIGA.Entities.Administrador;

namespace SIGA.Business.Administrador
{
    public class PerfilBusiness
    {
        public int RegistrarPerfil(Perfil objPerfil, List<OpcionPerfil> ListaOpcionPerfilUsuario)
        {
            int Codigo = 0;
            PerfilDao _GeneralRepository = new PerfilDao();
            Codigo = _GeneralRepository.RegistrarPerfil(objPerfil, ListaOpcionPerfilUsuario);
            return Codigo;
        }

        public int ActualizarPerfil(Perfil objPerfil, List<OpcionPerfil> ListaOpcionPerfil, OpcionPerfil objOpcionPerfil)
        {
            int Codigo = 0;
            PerfilDao _GeneralRepository = new PerfilDao();
            Codigo = _GeneralRepository.ActualizarPerfil(objPerfil, ListaOpcionPerfil, objOpcionPerfil);
            return Codigo;
        }

        public List<Perfil> ObtenerPerfiles(Perfil objPerfil)
        {
            PerfilDao _GeneralRepository = new PerfilDao();
            return _GeneralRepository.ObtenerPerfiles(objPerfil);
        }

        public Perfil ObtenerModuloPorCodigo(Perfil objPerfil)
        {
            PerfilDao _GeneralRepository = new PerfilDao();
            return _GeneralRepository.ObtenerPerfilPorCodigo(objPerfil);
        }

        public List<PerfilUsuario> ObtenerPerfilesUsuarioPorCodigo(PerfilUsuario objPerfil)
        {
            PerfilDao _GeneralRepository = new PerfilDao();
            return _GeneralRepository.ObtenerPerfilesUsuarioPorCodigo(objPerfil);
        }

        public List<OpcionPerfil> ObtenerOpcionesPerfil(OpcionPerfil objOpcionPerfil)
        {
            PerfilDao _GeneralRepository = new PerfilDao();
            return _GeneralRepository.ObtenerOpcionesPerfil(objOpcionPerfil);

        }

        public List<PerfilUsuario> ListarPerfilesUsuario(Usuario objUsuario)
        {
            PerfilDao _GeneralRepository = new PerfilDao();
            return _GeneralRepository.ListarPerfilesUsuario(objUsuario);
        }



    }
}
