using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    // ESTE TIENE IMPLEMENTADO TODOS LOS METODOS DE ADD, DELETE, UPDATE DESDE UN REPOSITORIO GENERICO
    public interface IRepositoryAsync<T> : IRepositoryBase<T> where T : class
    {
    }

    // ESTE TIENE IMPLEMENTADO TODOS LOS METODOS PARA GET, LIST, COUNT DESDE UN REPOSITORIO GENERICO
    public interface IReadRepositoryAsync<T> : IReadRepositoryBase<T> where T : class
    {
    }
}
