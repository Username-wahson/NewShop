using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewShop.Entity;

namespace NewShop.Model.ViewModel
{
    public class MenuViewModel
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
        public bool HasChild { get; set; }
        public MenuViewModel()
        {

        }
        public MenuViewModel(MenuInfo m)
            : this()
        {
            this.CreatorTime = m.CreatorTime;
            this.CreatorUserId = m.CreatorUserId;
            this.DeleteMark = m.DeleteMark;
            this.FullName = m.FullName;
            this.Id = m.Id;
            this.ParentId = m.ParentId;
            this.Layers = m.Layers;
            this.UrlAddress = m.UrlAddress;
            this.SortCode = m.SortCode;
        }
    }
}
