//------------------------------------------------------------------------------
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
    
    public partial class GetHotVideos_Result
    {
        public int Id { get; set; }
        public string Etag { get; set; }
        public string Kind { get; set; }
        public string YoutubeId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int YoutubeChannelId { get; set; }
        public System.DateTime PublishedAt { get; set; }
        public string YoutubeLink { get; set; }
        public Nullable<int> NumberOfViews { get; set; }
        public Nullable<int> NumberOfLikes { get; set; }
        public Nullable<int> NumberOfDislikes { get; set; }
        public Nullable<int> NumberOfComments { get; set; }
        public Nullable<int> VideoCategoryId { get; set; }
    }
}
