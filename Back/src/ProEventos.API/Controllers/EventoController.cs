using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProEventos.API.Models;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventoController : ControllerBase
    {
        public EventoController() {}

        public IEnumerable<Evento> _evento = new Evento[] {            
            new Evento() {
                EventoId = 1,
                Tema = "Primeiro teste Angular e .Net",
                Local = "Ulbra",
                Lote = "1 Lote",
                QtdPessoas = 50,
                DataEvento = DateTime.Now.AddDays(2).ToString("dd/MM/yyyy"),
                ImageURL = "AAAAA.png"
            },
            new Evento() {
                EventoId = 2,
                Tema = "Parou tudo no Angular e .Net",
                Local = "Rua 92 Esquina da Quadra",
                Lote = "5 Lote",
                QtdPessoas = 20,
                DataEvento = DateTime.Now.AddDays(6).ToString("dd/MM/yyyy"),
                ImageURL = "kkkkk.png"
            },
        };

        [HttpGet]
        public IEnumerable<Evento> Get()
        {
            return _evento;
        }

        [HttpGet("{id}")]
        public IEnumerable<Evento> Get(int id)
        {
            return _evento.Where(evento => evento.EventoId == id);
        }

        [HttpPost]
        public string Post()
        {
            return "Exemplo de Post";
        }

        [HttpPut("{id}")]
        public string Put(int id)
        {
            return $"Exemplo de Put com id = {id}";
        }
        
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return $"Exemplo de Delete do id = {id}";
        }
    }
}
