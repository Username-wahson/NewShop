//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace NewShop.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class MenuInfo
    {
        public int Id { get; set; }
        public Nullable<int> ParentId { get; set; }
        public Nullable<int> Layers { get; set; }
        public string FullName { get; set; }
        public string UrlAddress { get; set; }
        public Nullable<int> SortCode { get; set; }
        public Nullable<bool> DeleteMark { get; set; }
        public Nullable<bool> EnabledMark { get; set; }
        public string Description { get; set; }
        public Nullable<System.DateTime> CreatorTime { get; set; }
        public string CreatorUserId { get; set; }
        public Nullable<System.DateTime> LastModifyTime { get; set; }
        public string LastModifyUserId { get; set; }
        public Nullable<System.DateTime> DeleteTime { get; set; }
        public string DeleteUserId { get; set; }
    }
}
