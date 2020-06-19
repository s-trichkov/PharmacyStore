
using PS.Buisness.DTOs;
using PS.Data;
using PS.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PS.Buisness.Services
{
    public class MedicineService
    {
        public IEnumerable<MedicineDto> GetAllByName(string name)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                var medicines = unitOfWork.MedicineRepository.GetAll(m => m.MedicineName.Contains(name));

                var result = medicines.Select(medicine => new MedicineDto
                {
                    MedicineId = medicine.MedicineId,
                    MedicineName = medicine.MedicineName,
                    BrandId = medicine.BrandId,
                    MedicineLot = medicine.MedicineLot,
                    MedicinePrice = medicine.MedicinePrice,
                    CreatedOn = medicine.CreatedOn,
                    ExpiryDate = medicine.ExpiryDate
                }).ToList();

                return result;
            }
        }

        public IEnumerable<MedicineDto> GetAll()
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                var medicines = unitOfWork.MedicineRepository.GetAll();

                var result = medicines.Select(medicine => new MedicineDto
                {
                    MedicineId = medicine.MedicineId,
                    MedicineName = medicine.MedicineName,
                    BrandId = medicine.BrandId,
                    MedicineLot = medicine.MedicineLot,
                    MedicinePrice = medicine.MedicinePrice,
                    CreatedOn = medicine.CreatedOn,
                    ExpiryDate = medicine.ExpiryDate
                }).ToList();

                return result;
            }
        }

        public MedicineDto GetById(int id)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                var medicine = unitOfWork.MedicineRepository.GetById(id);

                return medicine == null ? null : new MedicineDto
                {
                    MedicineId = medicine.MedicineId,
                    MedicineName = medicine.MedicineName,
                    BrandId = medicine.BrandId,
                    MedicineLot = medicine.MedicineLot,
                    MedicinePrice = medicine.MedicinePrice,
                    CreatedOn = medicine.CreatedOn,
                    ExpiryDate = medicine.ExpiryDate
                };
            }
        }

        public bool Create(MedicineDto medicineDto)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                var medicine = new Medicine()
                {
                    MedicineName = medicineDto.MedicineName,
                    BrandId = medicineDto.BrandId,
                    MedicineLot = medicineDto.MedicineLot,
                    MedicinePrice = medicineDto.MedicinePrice,
                    ExpiryDate = medicineDto.ExpiryDate,
                    CreatedOn = medicineDto.CreatedOn
                    
                };

                unitOfWork.MedicineRepository.Create(medicine);

                return unitOfWork.Save();
            }
        }

        public bool Update(MedicineDto medicineDto)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                var result = unitOfWork.MedicineRepository.GetById(medicineDto.MedicineId);

                if (result == null)
                {
                    return false;
                }

                result.BrandId = medicineDto.BrandId;
                result.MedicineName = medicineDto.MedicineName;
                result.MedicinePrice = medicineDto.MedicinePrice;
                result.MedicineLot = medicineDto.MedicineLot;
                result.CreatedOn = medicineDto.CreatedOn;
                result.ExpiryDate = medicineDto.ExpiryDate;
                result.UpdatedOn = DateTime.Now;

                unitOfWork.MedicineRepository.Update(result);

                return unitOfWork.Save();
            }
        }

        public bool Delete(int id)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                Medicine result = unitOfWork.MedicineRepository.GetById(id);

                if (result == null)
                {
                    return false;
                }

                unitOfWork.MedicineRepository.Delete(result);

                return unitOfWork.Save();
            }
        }
    }
}
