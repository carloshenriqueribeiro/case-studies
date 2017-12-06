using Model;
using Repository;
using System;
using System.Collections.Generic;

namespace Business
{
    public class ClienteBusiness
    {
        private ClienteRepository _repository;

        public ClienteBusiness()
        {
            _repository = new ClienteRepository();
        }

        public List<ClienteModel> GetAll()
        {
            return _repository.GetAll();
        }

        public void Save(ClienteModel Cliente)
        {

            _repository.Save(Cliente);
        }

        public ClienteModel GetById(int id)
        {
            return _repository.GetById(id);
        }

        public bool Delete(int id)
        {
            return _repository.Delete(id);
        }
    }
}
