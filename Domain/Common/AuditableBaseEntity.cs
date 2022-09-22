using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common
{
    // SE ESTA CREANDO ESTA ENTIDAD BASE PARA QUE TODAS LAS DEMAS QUE VAYAMOS
    // CREANDO HEREDEN DE ELLA
    public abstract class AuditableBaseEntity
    {
        public virtual int Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime Created { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime LastModified { get; set; }
    }
}
