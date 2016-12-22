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
    
    public partial class VideoCategory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VideoCategory()
        {
            this.FacebookYoutubeMapping = new HashSet<FacebookYoutubeMapping>();
            this.UserPreferences = new HashSet<UserPreferences>();
            this.Video = new HashSet<Video>();
        }
    
        public int Id { get; set; }
        public string VideoCategoryName { get; set; }
        public string YoutbeVideoCategoryId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FacebookYoutubeMapping> FacebookYoutubeMapping { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserPreferences> UserPreferences { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Video> Video { get; set; }
    }
}
