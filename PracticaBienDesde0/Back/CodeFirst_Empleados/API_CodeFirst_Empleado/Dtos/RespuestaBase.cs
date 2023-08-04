using System.Net;

namespace API_CodeFirst_Empleado.Dtos
{
    public class RespuestaBase
    {
        public string Error { get; set; }
        public bool Exito { get; set; }
        public HttpStatusCode Codigo { get; set; }
    }
}
