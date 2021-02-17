using Laboratorio.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Laboratorio.Data.Interfaces
{

    public interface IMateriaRepository : IRepository<Materia>
    {
        void DeleteHabilitada();
    }
}
