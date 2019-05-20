using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationJwt.models
{
    public class Facultad
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
    }
}
