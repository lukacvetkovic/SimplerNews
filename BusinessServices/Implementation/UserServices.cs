using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities.BusinessModels;
using BusinessServices.Interface;
using DataModel.SQLDatabase;
using DataModel.UnitOfWork;

namespace BusinessServices.Implementation
{
    public class UserServices : IUserServices
    {

        private readonly UnitOfWork _unitOfWork;

        public UserServices()
        {
            _unitOfWork = new UnitOfWork();
        }
        public bool InsertOrUpdateUser(UserDto userDto)
        {
            var user = _unitOfWork.UserRepository.GetSingle(p => p.Email == userDto.Email);
            if (user != null)
            {
                user.Gender = userDto.Gender;
                user.Token = userDto.Token;
                _unitOfWork.UserRepository.Update(user);
            }
            else
            {
                _unitOfWork.UserRepository.Insert(new User() {Id = -1,Email = userDto.Email,Gender = userDto.Gender,Token = userDto.Token});
            }

            _unitOfWork.Save();

            return true;
        }

        public bool UpdateUserPreferences(UserInformationDto userInformation)
        {
            throw new NotImplementedException();
        }
    }
}
