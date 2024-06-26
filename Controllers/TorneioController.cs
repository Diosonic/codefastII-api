﻿using Codefast.Models.DTOs.Equipe;
using Codefast.Models;
using Codefast.Models.DTOs.Torneio;
using Codefast.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Codefast.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TorneioController : ControllerBase
    {
        private readonly ITorneioRepository _repository;

        public TorneioController(ITorneioRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("teste")]
        public async Task<ActionResult<IEnumerable<TorneioDTO>>> GetTorneioTeste()
        {
            var torneios = new List<TorneioDTO>
            {
                new TorneioDTO
                {
                    Id = 1,
                    Titulo = "Torneio de Exemplo",
                    Equipes = new List<EquipeDTO>
                    {
                        new EquipeDTO
                        {
                            Id = 1,
                            TituloTorneio = "Torneio de Exemplo",
                            Nome = "Equipe 1",
                            IsDesclassificado = false,
                            NomeParticipantes = "João, Maria",
                            IsCredenciado = true
                        },
                        new EquipeDTO
                        {
                            Id = 2,
                            TituloTorneio = "Torneio de Exemplo",
                            Nome = "Equipe 2",
                            IsDesclassificado = false,
                            NomeParticipantes = "Pedro, Ana",
                            IsCredenciado = false
                        }
                    }
                }
            };

            return Ok(torneios);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TorneioDTO>>> GetAll()
        {
            IEnumerable<TorneioDTO> torneios = await _repository.GetAllTorneiosAsync();

            return Ok(torneios);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Torneio>> GetById(int id)
        {
            Torneio torneio = await _repository.GetTorneioByIdAsync(id);

            if (torneio == null)
                return NotFound("Torneio não encontrado");

            return Ok(torneio);
        }

        [HttpGet("{id}/equipes")]
        public async Task<ActionResult<IEnumerable<EquipeDTO>>> GetAllEquipesTorneio(int id)
        {
            IEnumerable<EquipeDTO> equipes = await _repository.GetAllEquipesTorneioAsync(id);

            if (equipes == null)
            {
                return NotFound("Nenhuma equipe foi encontrada para esse torneio");
            }

            return Ok(equipes);
        }

        [HttpPost]
        public async Task<ActionResult<Torneio>> Post(AdicionarTorneioDTO request)
        {
            if (request == null)
                return BadRequest("Dados inválidos");

            Torneio torneio = new Torneio
            {
                Titulo = request.Titulo
            };

            await _repository.AddAsync(torneio);

            return Ok(torneio);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Torneio>> Put(int id, AtualizarTorneioDTO request)
        {
            if (request == null)
                return BadRequest("Dados inválidos");

            Torneio torneioExistente = await _repository.GetTorneioByIdAsync(id);

            if (torneioExistente == null)
                return NotFound("Torneio não encontrado");

            if (request.Titulo != null)
            {
                torneioExistente.Titulo = request.Titulo;
            }

            await _repository.UpdateAsync(torneioExistente);

            return Ok(torneioExistente);
        }


        [HttpPut("{id}/altera-status-tempo")]
        public async Task<ActionResult> AlteraStatusTempo(int id)
        {
            Torneio torneioExistente = await _repository.GetTorneioByIdAsync(id);

            if (torneioExistente == null)
                return NotFound("Controle da equipe não encontrado");

            torneioExistente.isTempoCorrendo = !torneioExistente.isTempoCorrendo;
            torneioExistente.isNovaRodada = false;

            await _repository.UpdateAsync(torneioExistente);

            return Ok(torneioExistente);
        }

        [HttpPut("{id}/resetar-status-tempo")]
        public async Task<ActionResult> ResetaStatusTempo(int id)
        {
            Torneio torneioExistente = await _repository.GetTorneioByIdAsync(id);

            if (torneioExistente == null)
                return NotFound("Controle da equipe não encontrado");

            torneioExistente.isTempoCorrendo = false;
            torneioExistente.isNovaRodada = true;
            torneioExistente.Tempo = new TimeSpan(0, 40, 0);

            await _repository.UpdateAsync(torneioExistente);

            return Ok(torneioExistente);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            Torneio torneioExistente = await _repository.GetTorneioByIdAsync(id);

            if (torneioExistente == null)
                return NotFound("Torneio não encontrado");

            await _repository.DeleteAsync(torneioExistente);

            return NoContent();
        }
    }
}
