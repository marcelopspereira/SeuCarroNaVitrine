﻿using DevWeek.SeuCarroNaVitrine.Negocio.NucleoCompartilhado;
using System;
using System.Collections.Generic;

namespace DevWeek.SeuCarroNaVitrine.Negocio.DominioEF.GerenciamentoDeAnuncio
{
    public class Anuncio : Agregado
    {
        private List<Proposta> _propostas = new List<Proposta>();

        public Guid AnuncianteId { get; }
        public DateTime DataDePublicacao { get; }
        public Periodo Vigencia { get; }
        public Veiculo Veiculo { get; }

        public IReadOnlyList<Proposta> Propostas { get { return _propostas; } }

        public Anuncio(Guid  id, Guid anuncianteId, Periodo vigencia,
            Veiculo veiculo) : base(id)
        {
            if (vigencia == null)
                throw new InvalidOperationException("A Vigência é obrigatória");

            if (veiculo == null)
                throw new InvalidOperationException("O Veículo é obrigatório");

            AnuncianteId = anuncianteId;
            DataDePublicacao = DateTime.Now;
            Vigencia = vigencia;
            Veiculo = veiculo;
        }

        public void AdicionarProposta(Proposta proposta)
        {
            if (!_propostas.Contains(proposta))
                _propostas.Add(proposta);
        }
    }
}