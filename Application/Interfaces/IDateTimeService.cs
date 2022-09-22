using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    // Esta interfaz lo que va a permite es agregar el CreateBy y el ModifiedBy
    public interface IDateTimeService
    {
        DateTime NowUtc { get; }
    }
}
