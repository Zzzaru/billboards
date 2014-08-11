using System.ComponentModel.DataAnnotations;

namespace Billboards.Models.EF
{
    public enum BillboardType : byte
    {
        [Display(Name = "биллборд")]
        Billboard,
        [Display(Name = "ситилайт")]
        Citylight,
        [Display(Name = "видеоэкран")]
        VideoScreen
    }
}