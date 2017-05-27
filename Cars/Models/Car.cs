namespace Cars.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Car
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public string Preview { get; set; }
        public string SubPreview { get; set; }
        public Nullable<int> Count { get; set; }
        public Nullable<decimal> Price { get; set; }
    }
}
