using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProEventos.Domain;

namespace ProEventos.Persistence.Contratos
{
    public interface IEventoPersistence
    {
        // Eventos
        Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false);
        Task<Evento[]> GetAllEventosByAsync(bool includePalestrantes = false);
        Task<Evento> GetAllEventosByIdAsync(int EventoId, bool includePalestrantes = false);

    }
}