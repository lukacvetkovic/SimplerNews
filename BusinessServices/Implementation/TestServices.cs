using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BusinessEntities.BusinessModels;
using BusinessServices.Interface;
using DataModel.SQLDatabase;
using DataModel.UnitOfWork;

namespace BusinessServices.Implementation
{
    public class TestServices : ITestServices
    {
        private readonly UnitOfWork _unitOfWork;

        /// <summary>
        /// Public constructor.
        /// </summary>
        public TestServices()
        {
            _unitOfWork = new UnitOfWork();
        }

        public List<TestEntity> GetaAllTestEntities()
        {
            var tests = _unitOfWork.TestRepository.GetAll();

            Mapper.Initialize(cfg => cfg.CreateMap<Test, TestEntity>());

            var config = new MapperConfiguration(cfg => cfg.CreateMap<Test, TestEntity>());

            var mapper = config.CreateMapper();

            return mapper.Map<List<TestEntity>>(tests);


        }

        public void TestService()
        {
            _unitOfWork.TestRepository.Insert(new Test() { Nam = new Guid().ToString() });
            _unitOfWork.Save();
        }
    }
}
