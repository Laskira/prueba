using market.Data;
using market.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace market.Controllers
{
    [Route("usuarios")]
    [ApiController]
    public class UsuarioController : Controller
    {

       
       

        [HttpPost]
        public async Task CrearUsuario([FromBody] Usuario parametros)
        {
            var funtion = new Datos();
            await funtion.InsertarUsuario(parametros);
        }

        [HttpGet]
        public dynamic ListarUsuariosActivos()
        {
            DataTable tUsuarios = Datos.Listar("ShowData");
            string jsonUsuarios = JsonConvert.SerializeObject(tUsuarios);
            return JsonConvert.DeserializeObject<List<Usuario>>(jsonUsuarios);
        }



        [HttpPut("{id}")]
        public async Task<object> EditarUsuario(string correo, [FromBody] Usuario parametros)
        {
            var funtion = new Datos();
            parametros.Correo = correo;
            await funtion.UpdateUsuario(parametros);

            return new
            {
                message = "Tu información de usaurio ha sido actualizada"
            };
        }


        [HttpDelete]
        public dynamic EliminarUsuario([FromQuery] string correo )
        {

            List<Parametro> parametro = new List<Parametro>
            {
                new Parametro("@correo", correo)
            };

            bool exito = Datos.Ejecutar("DeleteData", parametro);

            return new
            {
                success = exito,
                message = exito ? "Usuario eliminado exitosamente" : "Error, no se ha podido eliminar este usuario o este id no existe"
            };

        }


    }
}
