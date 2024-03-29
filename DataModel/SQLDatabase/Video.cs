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
    using System.Collections.Generic;
    
    public partial class Video
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Video()
        {
            this.UserVideoWatched = new HashSet<UserVideoWatched>();
            this.VideoTag = new HashSet<VideoTag>();
        }
    
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
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserVideoWatched> UserVideoWatched { get; set; }
        public virtual VideoCategory VideoCategory { get; set; }
        public virtual YoutubeChannel YoutubeChannel { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VideoTag> VideoTag { get; set; }
    }
}
