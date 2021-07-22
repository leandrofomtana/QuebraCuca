using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    public static class Jogo
    {
           private static readonly Dictionary<string, int> regras = new Dictionary<string, int>()
        {
            {"Royal Flush", 10 },
            {"Straight Flush", 9 },
            {"Quadra", 8 },
            {"Full House", 7 },
            {"Flush", 6 },
            {"Straight", 5 },
            {"Trinca", 4 },
            {"Dois pares", 3 },
            {"Um par", 2 },
            {"Carta Alta", 1 }
        };

        
        public static string ObterGanhador(Mao jogadorUm, Mao jogadorDois)
        {
            int pontosJogadorUm = 0;
            int pontosJogadorDois = 0;
            foreach (var item in regras)
            {
                if (jogadorUm.resultado.Contains(item.Key))
                    pontosJogadorUm += item.Value;
                if (jogadorDois.resultado.Contains(item.Key))
                    pontosJogadorDois += item.Value;
            }
            if (pontosJogadorUm == pontosJogadorDois)
            {
                if (jogadorUm.valorQuadra != "" && jogadorDois.valorQuadra != "")
                {
                    int maiorQuadraUm = Convert.ToInt32(jogadorUm.valorQuadra);
                    int maiorQuadraDois = Convert.ToInt32(jogadorDois.valorQuadra);
                    if (maiorQuadraUm > maiorQuadraDois)
                        return "Jogador um venceu";
                    else if (maiorQuadraDois > maiorQuadraUm)
                        return "Jogador dois venceu";
                }
                if (jogadorUm.valorTrinca != "" && jogadorDois.valorTrinca != "")
                {
                    int maiorTrincaUm = Convert.ToInt32(jogadorUm.valorTrinca);
                    int maiorTrincaDois = Convert.ToInt32(jogadorDois.valorTrinca);
                    if (maiorTrincaUm > maiorTrincaDois)
                        return "Jogador um venceu";
                    else if (maiorTrincaDois > maiorTrincaUm)
                        return "Jogador dois venceu";
                }
                if (jogadorUm.valorPar != "" && jogadorDois.valorPar !="")
                {
                    int maiorParUm = Convert.ToInt32(jogadorUm.valorPar);
                    int maiorParDois = Convert.ToInt32(jogadorDois.valorPar);
                    if (maiorParUm > maiorParDois)
                        return "Jogador um venceu";
                    else if (maiorParDois > maiorParUm)
                        return "Jogador dois venceu";
                }
                int maiorCartaUm = Convert.ToInt32(jogadorUm.valorMaiorCarta);
                int maiorCartaDois = Convert.ToInt32(jogadorDois.valorMaiorCarta);
                if (maiorCartaUm > maiorCartaDois)
                    return "Jogador um venceu";
                else if (maiorCartaDois > maiorCartaUm)
                    return "Jogador dois venceu";
                else
                    return "Empate";
            }
            if (pontosJogadorUm > pontosJogadorDois)
                return "Jogador um venceu";
            else 
                return "Jogador dois venceu";
        }
        
    }
}
