using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProEventos.Application.Contratos;
using ProEventos.Domain;
using ProEventos.Persistence.Contratos;

namespace ProEventos.Application
{
    public class EventoService : IEventoService
    {
        private readonly IGeralPersistence _geralPersist;
        private readonly IEventoPersistence _eventoPersist;

        public EventoService(IGeralPersistence geralPersist, IEventoPersistence eventoPersist)
        {
            _geralPersist = geralPersist;

            _eventoPersist = eventoPersist;
        }

        public async Task<Evento> AddEventos(Evento model)
        {
            try {
                _geralPersist.Add<Evento>(model);

                if (await _geralPersist.SaveChangesAsync()) {
                    return await _eventoPersist.GetAllEventosByIdAsync(model.Id, false);
                }

                return null;

            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteEventos(int eventoId)
        {
            try
            {
                var evento = await _eventoPersist.GetAllEventosByIdAsync(eventoId, false);

                if (evento == null) throw new Exception("EventoID não encontrado em -DeleteEventos-");

                _geralPersist.Delete(evento);

                return await _geralPersist.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento[]> GetAllEventosByAsync(bool includePalestrantes = false)
        {
            try
            {
                var eventos = await _eventoPersist.GetAllEventosByAsync(includePalestrantes);

                if (eventos == null) return null;

                return eventos;
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento> GetAllEventosByIdAsync(int EventoId, bool includePalestrantes = false)
        {
            try
            {
                var eventos = await _eventoPersist.GetAllEventosByIdAsync(EventoId, includePalestrantes);

                if (eventos == null) return null;

                return eventos;
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false)
        {
            try
            {
                var eventos = await _eventoPersist.GetAllEventosByTemaAsync(tema, includePalestrantes);

                if (eventos == null) return null;

                return eventos;
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento> UpdateEvento(int eventoId, Evento model)
        {
            try
            {
                var evento = await _eventoPersist.GetAllEventosByIdAsync(eventoId, false);

                model.Id = evento.Id;

                if (evento == null) return null;

                _geralPersist.Update(model);

                if (await _geralPersist.SaveChangesAsync()) {
                    return await _eventoPersist.GetAllEventosByIdAsync(model.Id, false);
                }

                return null;
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }
    }
}