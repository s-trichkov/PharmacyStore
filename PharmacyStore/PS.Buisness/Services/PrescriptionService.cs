using PS.Buisness.DTOs;
using PS.Data;
using PS.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PS.Buisness.Services
{
    public class PrescriptionService
    {
        public IEnumerable<PrescriptionDto> GetAll(int prescriptionId = 0)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                var prescriptions = prescriptionId != 0
                    ? unitOfWork.PrescriptionRepository.GetAll(p => p.PrescriptionId == prescriptionId)
                    : unitOfWork.PrescriptionRepository.GetAll();

                return prescriptions.Select(prescription => new PrescriptionDto
                {
                    ClientId = prescription.ClientId,
                    MedicineId = prescription.MedicineId,
                    CreatedOn = prescription.CreatedOn
                }).ToList();
            }
        }

        public PrescriptionDto GetById(int id)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                var prescription = unitOfWork.PrescriptionRepository.GetById(id);

                return prescription == null ? null : new PrescriptionDto
                {
                    ClientId = prescription.ClientId,
                    MedicineId = prescription.MedicineId,
                    CreatedOn = prescription.CreatedOn
                };
            }
        }

        public bool Create(PrescriptionDto prescriptionDto)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                var prescription = new Prescription()
                {
                    ClientId = prescriptionDto.ClientId,
                    MedicineId = prescriptionDto.MedicineId,
                    CreatedOn = prescriptionDto.CreatedOn
                };

                unitOfWork.PrescriptionRepository.Create(prescription);

                return unitOfWork.Save();
            }
        }

        public bool Update(PrescriptionDto prescriptionDto)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                var result = unitOfWork.PrescriptionRepository.GetById(prescriptionDto.PrescriptionId);

                if (result == null)
                {
                    return false;
                }

                result.ClientId = prescriptionDto.ClientId;
                result.MedicineId = prescriptionDto.MedicineId;
                result.UpdatedOn = DateTime.Now;

                unitOfWork.PrescriptionRepository.Update(result);

                return unitOfWork.Save();
            }
        }

        public bool Delete(int id)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                Prescription result = unitOfWork.PrescriptionRepository.GetById(id);

                if (result == null)
                {
                    return false;
                }

                unitOfWork.PrescriptionRepository.Delete(result);

                return unitOfWork.Save();
            }
        }
    }
}
