﻿namespace MercadoConsole_POO.Models
{
    public class Produto : ProdutoBase
    {
        public override string Descricao()
        {
            return $"Produto comum: {Nome}";
        }
    }
}
