using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MaestroMunicipos.Model
{
    public class Departamento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DepartamentoId { get; set; }
        public string Nombre { get; set; }
        public string Codigo { get; set; }
        public ICollection<Municipio> Municipios { get; set; }
    }
}
