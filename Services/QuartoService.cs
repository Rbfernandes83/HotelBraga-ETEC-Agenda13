
using HotelBraga.Models;

namespace HotelBraga.Services;

public class QuartoService
{
    public List<Quarto> ListarQuartos()
    {
        return new List<Quarto>
        {
            new Quarto
            {
                Nome = "Individual",
                Descricao = "Conforto e privacidade para uma pessoa.",
                Imagem = "quarto_individual.png",
                ValorDiaria = 180m,
                CapacidadeMaxima = 1
            },

            new Quarto
            {
                Nome = "Casal",
                Descricao = "Ambiente elegante para duas pessoas.",
                Imagem = "quarto_casal.png",
                ValorDiaria = 250m,
                CapacidadeMaxima = 2
            },

            new Quarto
            {
                Nome = "Duplo",
                Descricao = "Duas camas para uma hospedagem confortável.",
                Imagem = "quarto_duplo.png",
                ValorDiaria = 280m,
                CapacidadeMaxima = 2
            },

            new Quarto
            {
                Nome = "Família",
                Descricao = "Espaço amplo para toda a família.",
                Imagem = "quarto_familia.png",
                ValorDiaria = 360m,
                CapacidadeMaxima = 6
            }
        };
    }
}
