using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace SonataStore.Domain.Entities
{
    public class Product
    {
        [HiddenInput(DisplayValue =false)]
        public int ProductId { get; set; }

        [Display(Name="Название")]

        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name="Описание")]
        public string Description { get; set; }

        [Display(Name="Категория")]
        public string Category { get; set; }

        [Display(Name="Цена")]
        public decimal Price { get; set; }
    }
}
