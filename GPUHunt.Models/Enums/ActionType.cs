using System.ComponentModel.DataAnnotations;

namespace GPUHunt.Models.Enums
{
    public enum ActionType
    {
        [Display(Name = "Crawling for first use")]
        Init = 0,
        [Display(Name = "Updating database")]
        Update = 1
    }
}
