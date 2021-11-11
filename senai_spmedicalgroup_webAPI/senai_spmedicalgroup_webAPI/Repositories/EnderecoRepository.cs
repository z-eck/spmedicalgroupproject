using senai_spmedicalgroup_webAPI.Contexts;
using senai_spmedicalgroup_webAPI.Domains;
using senai_spmedicalgroup_webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_spmedicalgroup_webAPI.Repositories
{
    public class EnderecoRepository : IEnderecoRepository
    {
        readonly SPMEDICALGROUPContext context = new();

        public void AtualizarURL(int idEndereco, Endereco enderecoAtualizado)
        {
            Endereco enderecoBuscado = context.Enderecos.Find(idEndereco);

            if (enderecoAtualizado.Endereco1 != null || enderecoAtualizado.Cidade != null || enderecoAtualizado.Cep != null)
            {
                enderecoBuscado.Endereco1 = enderecoAtualizado.Endereco1;
                enderecoBuscado.Cidade = enderecoAtualizado.Cidade;
                enderecoBuscado.Cep = enderecoAtualizado.Cep;

                context.Enderecos.Update(enderecoBuscado);

                context.SaveChanges();
            }
        }

        public Endereco BuscarPorID(int idEndereco)
        {
            return context.Enderecos
                .Select(en => new Endereco
                {
                    IdEndereco = en.IdEndereco,
                    Lugadouro = en.Lugadouro,
                    Endereco1 = en.Endereco1,
                    Bairro = en.Bairro,
                    Cidade = en.Cidade,
                    Uf = en.Uf,
                })
                .FirstOrDefault(en => en.IdEndereco == idEndereco);
        }

        public void Cadastrar(Endereco novoEndereco)
        {
            context.Enderecos.Add(novoEndereco);

            context.SaveChanges();
        }

        public List<Endereco> ListarTodos()
        {
            return context.Enderecos
                .Select(en => new Endereco
                {
                    IdEndereco = en.IdEndereco,
                    Lugadouro = en.Lugadouro,
                    Endereco1 = en.Endereco1,
                    Bairro = en.Bairro,
                    Cidade = en.Cidade,
                    Uf = en.Uf,
                })
                .OrderBy(en => en.IdEndereco)
                .ToList();
        }

        public void Remover(int idEndereco)
        {
            context.Enderecos.Remove(BuscarPorID(idEndereco));

            context.SaveChanges();
        }
    }
}
