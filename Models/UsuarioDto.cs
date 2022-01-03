using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiUsuarioAdministrador.Models
{
    public class UsuarioDto_
    {
        [Newtonsoft.Json.JsonProperty("idUsuario", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? IdUsuario { get; set; }

        [Newtonsoft.Json.JsonProperty("nombreUsuario", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string NombreUsuario { get; set; }

        [Newtonsoft.Json.JsonProperty("correo", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Correo { get; set; }

        [Newtonsoft.Json.JsonProperty("contrasena", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Contrasena { get; set; }

        [Newtonsoft.Json.JsonProperty("telefono", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Telefono { get; set; }

        [Newtonsoft.Json.JsonProperty("direccion", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Direccion { get; set; }

        [Newtonsoft.Json.JsonProperty("idTipoUsuario", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? IdTipoUsuario { get; set; }

        [Newtonsoft.Json.JsonProperty("razonSocial", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string RazonSocial { get; set; }

        [Newtonsoft.Json.JsonProperty("datosFiscales", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string DatosFiscales { get; set; }

        [Newtonsoft.Json.JsonProperty("paginaWeb", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PaginaWeb { get; set; }

        [Newtonsoft.Json.JsonProperty("descripcion", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Descripcion { get; set; }

        [Newtonsoft.Json.JsonProperty("fechaIngreso", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string FechaIngreso { get; set; }

        [Newtonsoft.Json.JsonProperty("imagen", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Imagen { get; set; }

        [Newtonsoft.Json.JsonProperty("borradoLogico", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? BorradoLogico { get; set; }


    }


}


