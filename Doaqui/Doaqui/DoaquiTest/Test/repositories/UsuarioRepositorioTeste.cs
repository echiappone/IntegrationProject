﻿using Doaqui.src.data;
using Doaqui.src.repositories.implementations;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Doaqui.src.dtos;
using Doaqui.src.models;
using System.Collections.Generic;
using Doaqui.src.utilidades;

namespace DoaquiTeste.Test.repositories
{
    [TestClass]
    public class UsuarioRepositorioTeste
    {

        private DoaquiContexto _contexto;
        private UsuarioRepositorio _repositorio;

        [TestMethod]
        public void CriarUmUsuarioRetornaUmUsuario()
        {
            var opt = new DbContextOptionsBuilder<DoaquiContexto>()
            .UseInMemoryDatabase(databaseName: "db_doaqui")
            .Options;

            _contexto = new DoaquiContexto(opt);
            _repositorio = new UsuarioRepositorio(_contexto);

            _repositorio.NovoUsuario(
                new NovoUsuarioDTO("TesteUsuario", "testeemail@email.com",
                "senhateste", "pictureLink", TipoUsuario.ONG));

            List<UsuarioModelo> usuarioModelos = _repositorio.PegarTodosUsuarios();
            Assert.AreEqual(1, usuarioModelos.Count);
        }

    }
}
