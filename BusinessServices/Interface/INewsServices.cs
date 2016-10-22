using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities.BusinessModels;

namespace BusinessServices.Interface
{
    public interface INewsServices
    {
        Task<bool> InsertNews(NewsEntity news);
        Task<bool> InsertNewsList(NewsEntity[] newsList);

        Task<List<NewsEntity>> GetAllNews();
    }
}
