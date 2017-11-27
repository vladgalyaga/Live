using Dal.Core.Interfaces;
using Live.DAL.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Live.BLL
{
    public class CityManager
    {
        IUnitOfWork _unitOfWork;
        IRepository<City, int> _cityRepository;
        public CityManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _cityRepository = unitOfWork.GetRepository<City, int>();
        }
        public City GetOrCreateCity(string name)
        {
            City city = _cityRepository.GetFirstOrDefault(c => c.Name == name);
            if (city == null)
            {
                city = new City()
                {
                    Name = name
                };
            }
            return city;
        }
        public HappeningType GetOrCreateHappeningType(string name)
        {
            HappeningType happeningType = _unitOfWork.GetRepository<HappeningType, int>().GetFirstOrDefault(c => c.Name == name);
            if (happeningType == null)
            {
                happeningType = new HappeningType()
                {
                    Name = name,
                };
            }
            return happeningType;
        }
        
    }
}
