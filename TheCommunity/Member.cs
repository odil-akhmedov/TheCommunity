//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TheCommunity
{
    using System;
    using System.Collections.Generic;
    
    public partial class Member
    {
        public Member()
        {
            this.SingleTasks = new HashSet<SingleTask>();
        }
    
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Phone { get; set; }
        public string AboutMe { get; set; }
        public int CommunityId { get; set; }
    
        public virtual Community Community { get; set; }
        public virtual ICollection<SingleTask> SingleTasks { get; set; }
    }
}
