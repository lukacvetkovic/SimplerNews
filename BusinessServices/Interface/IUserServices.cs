﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities.BusinessModels;

namespace BusinessServices.Interface
{
    public interface IUserServices
    {
        //bool InsertOrUpdateUser(UserInformationDto userInformation);

        bool UpdateUserPreferences(UserInformationDto userInformation);
    }
}
