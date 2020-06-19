using PS.Buisness.DTOs;
using PS.Data;
using PS.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PS.Buisness.Services
{
    public class ClientService
    {
        public IEnumerable<ClientDto> GetAll(string firstName = null)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                var clients = firstName != null
                    ? unitOfWork.ClientRepository.GetAll(d => d.FirstName == firstName)
                    : unitOfWork.ClientRepository.GetAll();

                return clients.Select(client => new ClientDto
                {
                    ClientId = client.ClientId,
                    FirstName = client.FirstName,
                    LastName = client.LastName,
                    Email = client.Email,
                    CreatedOn = client.CreatedOn
                }).ToList();
            }
        }

        public ClientDto GetById(int id)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                var client = unitOfWork.ClientRepository.GetById(id);

                return client == null ? null : new ClientDto
                {
                    ClientId = client.ClientId,
                    FirstName = client.FirstName,
                    LastName = client.LastName,
                    Email = client.Email,
                    CreatedOn = client.CreatedOn
                };
            }
        }

        public bool Create(ClientDto clientDto)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                var client = new Client()
                {
                    ClientId = clientDto.ClientId,
                    FirstName = clientDto.FirstName,
                    LastName = clientDto.LastName,
                    Email = clientDto.Email,
                    CreatedOn = DateTime.Now
                };

                unitOfWork.ClientRepository.Create(client);

                return unitOfWork.Save();
            }
        }

        public bool Update(ClientDto clientDto)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                var result = unitOfWork.ClientRepository.GetById(clientDto.ClientId);

                if (result == null)
                {
                    return false;
                }

                result.FirstName = clientDto.FirstName;
                result.LastName = clientDto.LastName;
                result.Email = clientDto.Email;
                result.UpdatedOn = DateTime.Now;

                unitOfWork.ClientRepository.Update(result);

                return unitOfWork.Save();
            }
        }

        public bool Delete(int id)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                Client result = unitOfWork.ClientRepository.GetById(id);

                if (result == null)
                {
                    return false;
                }

                unitOfWork.ClientRepository.Delete(result);

                return unitOfWork.Save();
            }
        }
    }
}
