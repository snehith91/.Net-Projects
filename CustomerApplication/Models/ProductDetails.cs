using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CustomerApplication.Models
{
    [Table("tblProductDetails")]
    public class ProductDetails
    {
        [Key]
        public int ProductDetailsId { get; set; }
        public int ProductId { get; set; }
        [DataType(DataType.Currency)]
        public int ProductValue { get; set; }
        public string ProductSize { get; set; }
        public byte[] ProductImage { get; set; }
    }
}