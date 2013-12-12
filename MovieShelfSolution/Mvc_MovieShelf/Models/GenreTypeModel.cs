using System;
using System.ComponentModel.DataAnnotations;


namespace Mvc_MovieShelf.Models
{
    public class GenreTypeModel
    {

        //IDisplayImage DisplayImage { get; set; }
        [Required]
        [Display(Name = "Genre Type Name")]
        public string Name { get; set; }

        
        //bool IsNew { get; }
        //bool IsRemoved { get; set; }
        //bool HasChanged { get; set; }
        [Required]
        [Display(Name = "Genre Type ID")]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Last Madified By")]
        public string LastModifiedBy { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Last Modified Date")]
        public DateTime LastModifiedDate { get; set; }
        //[Required]
        //[DataType(DataType.Text)]
        //[Display(Name = "Genre Type Name")]
        //public DateTime Timestamp { get; set; }

       // bool IsValid { get; }
        //bool Validate();
        //void Reset();

        //IDomainStatus DomainStatus { get; }

        
    }
}