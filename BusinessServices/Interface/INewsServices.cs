﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities.BusinessModels;

namespace BusinessServices.Interface
{
    public interface INewsServices
    {
        void InsertNews(NewsEntity news);
    }
}
