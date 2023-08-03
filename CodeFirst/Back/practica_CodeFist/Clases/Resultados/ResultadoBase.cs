using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases.Resultados
{
    internal class ResultadoBase
    {
        public int StatusCode { get; set; }
        public bool Ok { get; set; }
        public string Error { get; set; }
        public string MensajeInfo { get; set; }
        public object Resultado { get; set; }
    }
}
