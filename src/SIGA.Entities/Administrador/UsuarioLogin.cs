using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace SIGA.Entities.Administrador
{

    public class UsuarioLogin
    {

        [Required]
        [Display(Name = "Dirección de correo electrónico / Id.", Prompt = "Dirección de correo electrónico / Id.")]
        [StringLength(80, ErrorMessage = "Ingrese direccion de correo electrónico o Id.")]
        public string IdentificadorOrMail { get; set; }

        [Required(ErrorMessage="Ingrese Password")]
        [Display(Name = "Passowrd", Prompt = "Passowrd")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Recordar", Prompt = "Recordar mi cuenta")]
        public bool Recordar { get; set; }

        public UsuarioLogin()
        {
            this.Recordar = false;

        }

    }

    public class UsuarioResponse : Usuario
    {
        [Required]
        public bool SeleccionaIngreso { get; set; }

        [Required]
        public Nullable<short> CodigoSponsor { get; set; }

        [Required]
        public Nullable<short> CodigoAplicativo { get; set; }
    }

    public class PreguntaSponsorRequest 
    {
        [Required]
        public IEnumerable<PreguntaSponsorResponse> PreguntaSponsor { get; set; }

        [Required]
        public Usuario CurrentUser { get; set; }
    }

    public class PreguntaSponsorResponse
    {
	    public short CodigoPregunta {get; set;}
	    public short CodigoSponsor {get; set;}
	    public string DescripcionPregunta {get; set;}
	    public string CodigoTipoPregunta {get; set;}
	    public string DescripcionSponsor {get; set;}
	    public string DescripcionTipoPregunta {get; set;}

        [Required]
        [Display(Name = "Indique su respuesta")]
        [StringLength(100, ErrorMessage = "Su respuesta no debe exeder los 100 caracteres")]
        public string TextoRespuesta { get; set; }
    }

    public class RespuestasRandonUsuariosRequest
    {
        public short Identificador { get; set; }

        public string IdentificadorUsuario { get; set; }

        public short CodigoPregunta { get; set; }

        [Display(Name = "Pregunta")]
        public string Pregunta { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Indique una respuesta", MinimumLength = 6)]
        [Display(Name = "Respuesta")]
        public string Respuesta { get; set; }

        [Required]
        [Display(Name = "Confirmar Respuesta")]
    
        public string ConfirmaRespuesta { get; set; }
    }

    public class PreguntaSponsorNuevoRequest
    {
        [Required]
        public short CodigoPregunta { get; set; }

        [Required]
        public int CodigoUsuario { get; set; }
        
        [Required]
        [Display(Name = "Indique su respuesta")]
        [StringLength(100, ErrorMessage = "Su respuesta no debe exeder los 100 caracteres")]
        public string TextoRespuesta { get; set; }
    }

    public class CambiarClaveRequest
    {
        public string Usuario { get; set; }

        public string IdentificadorUsuario { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Passowrd actual")]
        public string ActualClave { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Indique un passowrd", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Nuevo password")]
        public string NuevaClave { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirmar password")]
     
        public string ConfirmaClave { get; set; }
    }

    public class SeleccionarIngresoRequest
    {
        public string Usuario { get; set; }
        public string IdentificadorUsuario { get; set; }
        //[Required]
        //[Display(Description="Seleccione Sponsor")]
        //public System.Web.Mvc.SelectList Sponsors { get; set; }
        //[Required]
        //[Display(Description="Seleccione Aplicativo")]
        //public System.Web.Mvc.SelectList Aplicativos { get; set; }
    }

    public class SeleccionIngreoRequest
    {
        public short codAplicativo {get; set;}
        public short codSponsor { get; set; }
    }

}
