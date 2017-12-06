using Business;
using Model;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Api.Controllers
{
    public class ClienteController : ApiController
    {
        private ClienteBusiness _business;

        public ClienteController()
        {
            _business = new ClienteBusiness();
        }

        [HttpGet]
        public HttpResponseMessage GetAll()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, _business.GetAll());
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        public HttpResponseMessage GetById([FromUri]int id)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, _business.GetById(id));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public HttpResponseMessage Update([FromBody]ClienteModel cliente)
        {
            try
            {
                if (cliente.ClienteId == 0) throw new Exception("Cliente não existe");

                _business.Save(cliente);

                return Request.CreateResponse(HttpStatusCode.OK, "Atualizado com sucesso");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpPut]
        public HttpResponseMessage Add([FromBody]ClienteModel cliente)
        {
            try
            {
                //pesquisar sobre tratamento de erros com ModelState.IsValid

                if (cliente.ClienteId != 0) throw new Exception("Id não permitido");

                _business.Save(cliente);

                return Request.CreateResponse(HttpStatusCode.OK, "Adicionado com sucesso");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }

        }

        [HttpGet]
        public HttpResponseMessage Delete(int ClienteId)
        {
            try
            {
                if (ClienteId <= 0) throw new Exception("Id inválido");

                _business.Delete(ClienteId);

                return Request.CreateResponse(HttpStatusCode.OK, "Deletado com sucesso");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
