namespace Cars.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Order
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public Nullable<int> CarId { get; set; }
        public string UserTel { get; set; }
        public string Status { get; set; }
    }
}
