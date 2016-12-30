﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataModel.SQLDatabase
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class SimplerNewsSQLDb : DbContext
    {
        public SimplerNewsSQLDb()
            : base("name=SimplerNewsSQLDb")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<FacebookCategory> FacebookCategory { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserPreferences> UserPreferences { get; set; }
        public virtual DbSet<UserVideoWatched> UserVideoWatched { get; set; }
        public virtual DbSet<Video> Video { get; set; }
        public virtual DbSet<VideoCategory> VideoCategory { get; set; }
        public virtual DbSet<VideoTag> VideoTag { get; set; }
        public virtual DbSet<YoutubeChannel> YoutubeChannel { get; set; }
    
        public virtual ObjectResult<GetHotVideos_Result> GetHotVideos(Nullable<int> userId, Nullable<System.DateTime> dateFrom, Nullable<int> numberOfVideos)
        {
            var userIdParameter = userId.HasValue ?
                new ObjectParameter("UserId", userId) :
                new ObjectParameter("UserId", typeof(int));
    
            var dateFromParameter = dateFrom.HasValue ?
                new ObjectParameter("DateFrom", dateFrom) :
                new ObjectParameter("DateFrom", typeof(System.DateTime));
    
            var numberOfVideosParameter = numberOfVideos.HasValue ?
                new ObjectParameter("NumberOfVideos", numberOfVideos) :
                new ObjectParameter("NumberOfVideos", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetHotVideos_Result>("GetHotVideos", userIdParameter, dateFromParameter, numberOfVideosParameter);
        }
    
        public virtual int ResetUserPreferences(Nullable<int> userId)
        {
            var userIdParameter = userId.HasValue ?
                new ObjectParameter("UserId", userId) :
                new ObjectParameter("UserId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ResetUserPreferences", userIdParameter);
        }
    
        public virtual int GetVideoIdForParameters(Nullable<int> userId, Nullable<int> categoryId)
        {
            var userIdParameter = userId.HasValue ?
                new ObjectParameter("UserId", userId) :
                new ObjectParameter("UserId", typeof(int));
    
            var categoryIdParameter = categoryId.HasValue ?
                new ObjectParameter("CategoryId", categoryId) :
                new ObjectParameter("CategoryId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("GetVideoIdForParameters", userIdParameter, categoryIdParameter);
        }
    }
}
