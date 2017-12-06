using DataAccess;
using Model;

namespace Repository.Factories
{
    public static class ClientesFactory
    {
        public static ClienteModel ToModel(Clientes tabela)
        {
            return new ClienteModel
            {
                ClienteId = tabela.ClienteId,
                Nome = tabela.Nome,
                CPF = tabela.CPF,
                Endereco = tabela.Endereco,
                Email = tabela.Email

            };
        }

        public static Clientes ToEntity(ClienteModel model)
        {
            return new Clientes
            {
                ClienteId = model.ClienteId,
                Nome =  model.Nome,
                CPF = model.CPF,
                Endereco = model.Endereco,
                Email = model.Email
            };
        }

        public static void ToEntity(ClienteModel model, Clientes registro)
        {
            registro.ClienteId = model.ClienteId;
            registro.Nome = model.Nome;
            registro.CPF = model.CPF;
            registro.Endereco = model.Endereco;
            registro.Email = model.Email;
        }
    }
}
