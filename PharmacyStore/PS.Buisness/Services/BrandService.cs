using PS.Buisness.DTOs;
using PS.Data;
using PS.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PS.Buisness.Services
{
    public class BrandService
    {
        public IEnumerable<BrandDto> GetAll(string brandName = null)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                var brands = brandName != null
                    ? unitOfWork.BrandRepository.GetAll(d => d.BrandName == brandName)
                    : unitOfWork.BrandRepository.GetAll();

                return brands.Select(brand => new BrandDto
                {
                    BrandId = brand.BrandId,
                    BrandName  = brand.BrandName,
                    HQ = brand.HQ,
                    Founded = brand.Founded,
                    Revenue = brand.Revenue
                }).ToList();
            }
        }

        public BrandDto GetById(int id)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                var brand = unitOfWork.BrandRepository.GetById(id);

                return brand == null ? null : new BrandDto
                {
                    BrandId = brand.BrandId,
                    BrandName = brand.BrandName,
                    HQ = brand.HQ,
                    Founded = brand.Founded,
                    Revenue = brand.Revenue
                };
            }
        }

        public bool Create(BrandDto brandDto)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                var brand = new Brand()
                {
                    BrandName = brandDto.BrandName,
                    HQ = brandDto.HQ,
                    CreatedOn = DateTime.Now,
                    Founded = brandDto.Founded,
                    Revenue = brandDto.Revenue
                };

                unitOfWork.BrandRepository.Create(brand);

                return unitOfWork.Save();
            }
        }

        public bool Update(BrandDto brandDto)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                var result = unitOfWork.BrandRepository.GetById(brandDto.BrandId);

                if (result == null)
                {
                    return false;
                }

                result.BrandName = brandDto.BrandName;
                result.HQ = brandDto.HQ;
                result.UpdatedOn = DateTime.Now;
                result.Founded = brandDto.Founded;
                result.Revenue = brandDto.Revenue;

                unitOfWork.BrandRepository.Update(result);

                return unitOfWork.Save();
            }
        }

        public bool Delete(int id)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                Brand result = unitOfWork.BrandRepository.GetById(id);

                if (result == null)
                {
                    return false;
                }

                unitOfWork.BrandRepository.Delete(result);

                return unitOfWork.Save();
            }
        }
    }
}
