using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamadaDeDados
{
    public interface IRepositorio
    {
        void Inclusao();
        void Alteracao();
        void Exclusao();
        void Pesquisa();
    }
}
