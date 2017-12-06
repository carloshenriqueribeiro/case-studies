using Model;
using System.Collections.Generic;
using DataAccess;
using System.Linq;
using Repository.Factories;

namespace Repository
{
    public class ClienteRepository
    {

        public List<ClienteModel> GetAll()
        {
            using (var db = new INOVECREntities())
            {
                return db.Clientes.ToList().ConvertAll(ClientesFactory.ToModel);
            }
        }

        public void Save(ClienteModel Clientes)
        {
            using (var db = new INOVECREntities())
            {
                if (Clientes.ClienteId == 0)
                {
                    db.Clientes.Add(ClientesFactory.ToEntity(Clientes));
                }
                else
                {
                    var registro = db.Clientes.Single(x => x.ClienteId == Clientes.ClienteId);

                    ClientesFactory.ToEntity(Clientes, registro);
                }

                db.SaveChanges();
            }
        }

        public ClienteModel GetById(int id)
        {
            using (var db = new INOVECREntities())
            {
                var registro = db.Clientes.Single(x => x.ClienteId == id);

                return ClientesFactory.ToModel(registro);
            }
        }

        public bool Delete(int id)
        {
            using (var db = new INOVECREntities())
            {
                var registro = db.Clientes.Single(x => x.ClienteId == id);

                db.Clientes.Remove(registro);

                var qtde = db.SaveChanges();

                return qtde > 0;
            }
        }
    }
}
