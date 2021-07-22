using System;
using System.Collections.Generic;
using System.Text;

namespace Poker
{
    public class Mao
    {

        private List<string> valoresCartas = new List<string>();
        private List<string> naipesCartas = new List<string>();
        public string maoJogador;
        private bool trincaEPar = false;
        private bool trinca = false;
        private bool quadra = false;
        public string valorTrinca = "";
        public string valorQuadra = "";
        public string valorPar = "";
        public string valorMaiorCarta = "";
        private int pares = 0;
        private bool sequencia = false;
        private bool naipeIgual = false;
        private bool sequenciaRoyalFlush = false;
        public string resultado = "";

        Dictionary<string, int> dicionarioValores = new Dictionary<string, int>()
        {
            {"2", 0 },
            {"3", 0 },
            {"4", 0 },
            {"5", 0 },
            {"6", 0 },
            {"7", 0 },
            {"8", 0 },
            {"9", 0 },
            {"T", 0 },
            {"J", 0 },
            {"Q", 0 },
            {"K", 0 },
            {"A", 0 }
        };


        Dictionary<string, int> dicionarioNaipe = new Dictionary<string, int>()
        {
            {"D", 0}, //Ouro
            {"H", 0}, //copa
            {"S", 0}, //espadas
            {"C", 0}  //paus
        };


        public Mao(string mao)
        {
            string[] substringMao = mao.Split(" ");
            foreach (var item in substringMao)
            {
                valoresCartas.Add(item[0].ToString());
                naipesCartas.Add(item[1].ToString());
            }
            this.maoJogador = mao;

            CalcularMao();

        }

        public void CalcularMao()
        {
            ChecarValores();
            ChecarNaipes();
            Quadra();
            TrincaEPar();
            CartaMaior();
            resultado = ObterValorMao().ToString();
        }
        private StringBuilder ObterValorMao()
        {
            StringBuilder sb = new StringBuilder();
            if (sequenciaRoyalFlush && naipeIgual)
                return sb.Append("Royal Flush");
            else if (sequencia && naipeIgual)
                return sb.Append("Straight Flush");
            else if (quadra)
                sb.Append($"Quadra de {valorQuadra}");
            else if (trinca && pares == 1)
                sb.Append("Full House");
            else if (naipeIgual)
                sb.Append("Flush");
            else if (sequencia)
                sb.Append("Straight");
            else if (trinca)
                sb.Append($"Trinca de {valorTrinca}");
            else if (pares == 2)
                sb.Append($"Dois pares , maior par {valorPar}");
            else if (pares == 1)
                sb.Append($"Um par de {valorPar}");
            sb.Append($" - Carta Alta: {valorMaiorCarta}");
            return sb;
        }
        private void ChecarValores()
        {
            foreach (var item in valoresCartas)
                dicionarioValores[item]++;

            int contagemSequencia = 0;
            bool continuaSequencia = false;
            sequenciaRoyalFlush = false;
            foreach (var item in dicionarioValores)
            {
                if (item.Value == 1 && contagemSequencia == 0)
                {
                    continuaSequencia = true;
                    contagemSequencia++;
                    if (item.Key == "T")
                        sequenciaRoyalFlush = true;
                }
                else if (item.Value == 1 && contagemSequencia > 0 && continuaSequencia == true)
                    contagemSequencia++;
                else
                {
                    if (sequenciaRoyalFlush)
                        sequenciaRoyalFlush = false;
                    break;
                }
            }
            if (contagemSequencia == 5)
                sequencia = true;
        }

        private void ChecarNaipes()
        {
            foreach (var item in naipesCartas)
                dicionarioNaipe[item]++;

            foreach (var item in dicionarioNaipe)
                if (item.Value == 5)
                    naipeIgual = true;
        }




        public void Quadra()
        {
            foreach (var item in dicionarioValores)
                if (item.Value == 4)
                {
                    valorQuadra = TraduzirLetraPraNumero(item.Key);
                    quadra = true;
                }

        }

        public void TrincaEPar()
        {
            foreach (var item in dicionarioValores)
            {
                if (item.Value == 3)
                {
                    trinca = true;
                    valorTrinca = TraduzirLetraPraNumero(item.Key);
                    
                }
                if (item.Value == 2)
                {
                    pares++;
                    valorPar = TraduzirLetraPraNumero(item.Key);
                }
            }

        }

        public void CartaMaior()
        {
            foreach (var item in dicionarioValores)
                if (item.Value > 0 && item.Key != TraduzirNumeroPraLetra(valorPar) 
                    && item.Key != TraduzirNumeroPraLetra(valorTrinca)
                    && item.Key != TraduzirNumeroPraLetra(valorQuadra))
                {
                    valorMaiorCarta = item.Key;
                    if (item.Key == "T")
                        valorMaiorCarta = "10";
                    if (item.Key == "J")
                        valorMaiorCarta = "11";
                    if (item.Key == "Q")
                        valorMaiorCarta = "12";
                    if (item.Key == "K")
                        valorMaiorCarta = "13";
                    if (item.Key == "A")
                        valorMaiorCarta = "14";
                }
        }
        public string TraduzirLetraPraNumero(string valor)
        {
            if (valor == "T")
                valor = "10";
            if (valor == "J")
                valor = "11";
            if (valor == "Q")
                valor = "12";
            if (valor == "K")
                valor = "13";
            if (valor == "A")
                valor = "14";
            return valor;
        }
        public string TraduzirNumeroPraLetra(string valor)
        {
            if (valor == "10")
                valor = "T";
            if (valor == "11")
                valor = "J";
            if (valor == "12")
                valor = "Q";
            if (valor == "13")
                valor = "K";
            if (valor == "14")
                valor = "A";
            return valor;
        }
    }


}

