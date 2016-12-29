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
        private bool InsertOrUpdateUser(UserInformationDto userInformation)
        {
            var user = _unitOfWork.UserRepository.GetSingle(p => p.Email == userInformation.email);
            if (user != null)
            {
                user.ExternalId = userInformation.id;
                user.Token = userInformation.accessToken;
                _unitOfWork.UserRepository.Update(user);
            }
            else
            {
                user = new User()
                {
                    Id = -1,
                    Email = userInformation.email,
                    ExternalId = userInformation.id,
                    Token = userInformation.accessToken
                };
                _unitOfWork.UserRepository.Insert(user);
            }

            _unitOfWork.Save();

            SimplerNewsSQLDb db = new SimplerNewsSQLDb();
            db.ResetUserPreferences(user.Id);

            return true;
        }

        public bool UpdateUserPreferences(UserInformationDto userInformation)
        {
            try
            {
                InsertOrUpdateUser(userInformation);
                var user = _unitOfWork.UserRepository.GetSingle(p => p.Email == userInformation.email);

                if (userInformation.facebookJSON?.likes != null)
                {
                    SimplerNewsSQLDb db = new SimplerNewsSQLDb();
                    db.ResetUserPreferences(user.Id);

                    foreach (var like in userInformation.facebookJSON.likes)
                    {
                        var facebookLikeCategory =
                            _unitOfWork.FacebookCategoryRepository.GetSingle(p => p.CategoryName == like.category);
                        if (facebookLikeCategory != null)
                        {
                            var pref =
                                _unitOfWork.UserPreferencesRepository.GetSingle(
                                    p => p.YoutubeCategoryId == facebookLikeCategory.VideoCategoryId && p.UserId == user.Id);
                            if (pref != null)
                            {
                                double additionalScore = (1.0 / (DateTime.Now.Year - DateTime.Parse(like.liked_date).Year + 1));
                                // ReSharper disable once PossibleLossOfFraction
                                decimal addition = Convert.ToDecimal(additionalScore);
                                pref.Score += addition;
                                _unitOfWork.UserPreferencesRepository.Update(pref);
                                _unitOfWork.Save();
                            }
                        }
                    }
                }

                return true;
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
