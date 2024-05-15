﻿using Codefast.Models;
using Codefast.Models.DTOs.ControleMataMata;
using Codefast.Models.DTOs.Equipe;

namespace Codefast.Repository.Interfaces;

public interface IControleMataMataRepository : IBaseRepository
{
    Task<IEnumerable<EquipeDTO>> GetEquipesParaFaseMataMata(int id);
    Task<IEnumerable<ControleMataMataDTO>> GetControleMataMataAsync(int idTorneio);
    Task<ControleMataMata> GetControleMataMataByIdAsync(int id);
    Task<IEnumerable<ControleMataMataDTO>> GetControleMataMataEmValidacaoAsync(int idTorneio);
    Task<SementeRodada> PreparaEtapaMataMata(int equipeId, int sementeRodadaId);
    Task<SementeRodada> DesclassificaEquipeAsync(int id);

}
