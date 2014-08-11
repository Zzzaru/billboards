using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using Billboards.ValidationAttrs;

namespace Billboards.Models.EF
{
    public class BillboardE
    {
        /// <summary>
        /// Первичный ключ
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Описание
        /// </summary>
        [Required(ErrorMessage = "обязательное поле")]
        [DisplayName("описание")]
        [StringLength(200, ErrorMessage = "от 10 до 200 символов", MinimumLength = 10)]
        public string Description { get; set; }

        /// <summary>
        /// Время следующего техобслуживания
        /// </summary>
        [Required(ErrorMessage = "обязательное поле")]
        [DisplayName("время следующего техобслуживания")]
        public DateTime MaintenanceTime { get; set; }

        /// <summary>
        /// Место расположения
        /// </summary>
        [Required(ErrorMessage = "укажите адрес на карте")]
        [DisplayName("адрес")]
        public DbGeography Location { get; set; }

        /// <summary>
        /// Тип конструкции: биллборд, ситилайт, видеоэкран
        /// </summary>
        [Required(ErrorMessage = "обязательное поле")]
        [DisplayName("тип конструкции")]
        public BillboardType Type { get; set; }

        /// <summary>
        /// Высота конструкции
        /// </summary>
        [Required(ErrorMessage = "обязательное поле")]
        [Range(1, 32767, ErrorMessage = "число должно быть в диапазоне 0 - 32767")]
        [DisplayName("высота конструкции (в см.)")]
        [Integer(ErrorMessage = "число должно быть целым")]
        public short Heigh { get; set; }

        /// <summary>
        /// Ширина конструкции
        /// </summary>
        [Required(ErrorMessage = "обязательное поле")]
        [Range(1, 32767, ErrorMessage = "число должно быть в диапазоне 0 - 32767")]
        [DisplayName("ширина конструкции (в см.)")]
        [Integer(ErrorMessage = "число должно быть целым")]
        public short Width { get; set; }

        /// <summary>
        /// Цена размещения рекламы в месяц
        /// </summary>
        [Required(ErrorMessage = "обязательное поле")]
        [DisplayName("Цена рекламы")]
        [Column(TypeName="Money")]
        public decimal MonthlyCost { get; set; }
    }
}