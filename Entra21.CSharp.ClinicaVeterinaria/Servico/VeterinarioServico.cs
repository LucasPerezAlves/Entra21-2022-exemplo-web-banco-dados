using Entra21.CSharp.ClinicaVeterinaria.Repositorio.Entidades;
using Entra21.CSharp.ClinicaVeterinaria.Repositorio.Repositorios;
using Entra21.CSharp.ClinicaVeterinaria.Servico.ViewModels.Veterinarios;

namespace Entra21.CSharp.ClinicaVeterinaria.Servico
{
    public class VeterinarioServico : IVeterinarioServico
    {
        private readonly IVeterinarioRepositorio _veterinarioRepositorio;
public VeterinarioServico(IVeterinarioRepositorio veterinarioRepositorio)
        {
            _veterinarioRepositorio = veterinarioRepositorio;
        }

        public Veterinario Cadastrar(VeterinarioCadastrarViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        public IList<Veterinario> ObterTodos(string pesquisa)
        {
            throw new NotImplementedException();
        }
    }
}
