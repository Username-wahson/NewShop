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
    
    public partial class ManagerInfo
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PasswordSalt { get; set; }
        public Nullable<System.DateTime> LoginDate { get; set; }
        public Nullable<System.DateTime> CreatorTime { get; set; }
        public Nullable<int> CreatorUserId { get; set; }
        public Nullable<System.DateTime> LastModifyTime { get; set; }
        public Nullable<int> LastModifyUserId { get; set; }
        public Nullable<System.DateTime> DeleteTime { get; set; }
        public Nullable<int> DeleteUserId { get; set; }
        public Nullable<bool> DeleteMark { get; set; }
        public Nullable<int> RoleId { get; set; }
    }
}