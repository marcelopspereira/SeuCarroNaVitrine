﻿using DevWeek.SeuCarroNaVitrine.Negocio.DominioEF;
using DevWeek.SeuCarroNaVitrine.Negocio.DominioEF.GerenciamentoDeAnuncio;
using DevWeek.SeuCarroNaVitrine.Negocio.NucleoCompartilhado.Enums;
using DevWeek.SeuCarroNaVitrine.Negocio.Repositorios.RepositorioEF;
using System;
using Xunit;

namespace SeuCarroNaVitrine.Tests
{
    public class AnuncioTestsEF
    {
        private readonly AnuncioRepositorio _repositorio;
        public AnuncioTestsEF()
        {
            _repositorio = new AnuncioRepositorio();
        }

        [Fact]
        public void SalvarUmNovoAnuncioTest()
        {
            var identidadeDoAnuncio = Guid.NewGuid();
            var idAnunciante = Guid.Parse("B2490150-D8A8-4F5F-89AB-A4EB28622BA4");
            var periodo = Periodo.Novo(DateTime.Now, DateTime.Now.AddDays(10));

            var detalheDeFabricacao = DetalheDeFabricacao.Novo("Honda", "Civic", 2010, 2010);
            var opcionais = ItensOpcicionais.Novo("trava, vidro,alarme, airbag,kit multimidia,ABS");


            var detalheDoVeiculo = DetalheDoVeiculo.Novo
                (
                    "ABC1234",
                    50000,
                    TipoDoCambio.Automatico,
                    TipoDaCarroceria.Sedan,
                    Cor.Branco,
                    TipoDeCombustivel.Flex,
                    4,
                    30.500m);


            var veiculo = new Veiculo(identidadeDoAnuncio, detalheDeFabricacao, opcionais, detalheDoVeiculo);

            var novoAnuncio = new Anuncio(identidadeDoAnuncio, idAnunciante, periodo, veiculo);

            var iqual = novoAnuncio == veiculo;

            _repositorio.Salvar(novoAnuncio);
        }
    }
}
