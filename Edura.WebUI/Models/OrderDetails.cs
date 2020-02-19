using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Edura.WebUI.Models
{
    public class OrderDetails
    {
        [Required(ErrorMessage ="Lütfen bir adres tanıtımı giriniz.")]
        public string AdresTanimi { get; set; }

        [Required(ErrorMessage = "Lütfen bir adres giriniz.")]
        public string Adres { get; set; }

        [Required(ErrorMessage = "Lütfen bir Sehir giriniz.")]
        public string Sehir{ get; set; }

        [Required(ErrorMessage = "Lütfen bir Semt giriniz.")]
        public string Semt{ get; set; }

        [Required(ErrorMessage = "Lütfen bir Telefon giriniz.")]
        public string Telefon { get; set; }
    }
}
