using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CamadaDeDados;

namespace atCSharp
{
    public class Teste
    {
        private IRepositorio _repositorio;

        public Teste(IRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public void Incluindo() => _repositorio.Inclusao();

        public void Alterando() => _repositorio.Alteracao(); 

        public void Excluindo() => _repositorio.Exclusao(); 

        public void Pesquisando() => _repositorio.Pesquisa(); 
    }
}
