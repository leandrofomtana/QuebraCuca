using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poker;
using FluentAssertions;
namespace TestPoker
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TesteUmPar()
        {
            Mao jogadorUm = new Mao("5H 5C 6S 7S KD");
            Mao jogadorDois = new Mao("2C 3S 8S 8D TD");
            string ganhador = Jogo.ObterGanhador(jogadorUm, jogadorDois);
            ganhador.Should().Be("Jogador dois venceu");


        }
        [TestMethod]
        public void TesteRoyalFlush()
        {
            Mao jogadorUm = new Mao("TH JH QH KH AH");
            Mao jogadorDois = new Mao("2C 3S 8S 8D TD");
            string ganhador = Jogo.ObterGanhador(jogadorUm, jogadorDois);
            ganhador.Should().Be("Jogador um venceu");
        }

        [TestMethod]
        public void TesteCartaMaisAlta()
        {
            Mao jogadorUm = new Mao("5D 8C 9S JS AC");
            Mao jogadorDois = new Mao("2C 5C 7D 8S QH");
            string ganhador = Jogo.ObterGanhador(jogadorUm, jogadorDois);
            ganhador.Should().Be("Jogador um venceu");


        }

        [TestMethod]
        public void TesteTrincaeFlush()
        {
            Mao jogadorUm = new Mao("2D 9C AS AH AC");
            Mao jogadorDois = new Mao("3D 6D 7D TD QD");
            string ganhador = Jogo.ObterGanhador(jogadorUm, jogadorDois);
            ganhador.Should().Be("Jogador dois venceu");


        }

        [TestMethod]
        public void TesteCartaMaisAltaParDamas()
        {
            Mao jogadorUm = new Mao("4D 6S 9H QH QC");
            Mao jogadorDois = new Mao("3D 6D 7H QD QS");
            string ganhador =  Jogo.ObterGanhador(jogadorUm, jogadorDois);

            ganhador.Should().Be("Jogador um venceu");


        }

        [TestMethod]
        public void TesteCartaMaisAltaFullHouse()
        {
            Mao jogadorUm = new Mao("2H 2D 4C 4D 4S");
            Mao jogadorDois = new Mao("3C 3D 3S 9S 9D" );
            string ganhador = Jogo.ObterGanhador(jogadorUm, jogadorDois);

            ganhador.Should().Be("Jogador um venceu");
            


        }
    }
}
