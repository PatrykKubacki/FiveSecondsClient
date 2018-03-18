using System.ComponentModel.DataAnnotations;

namespace FiveSecondsClient.WebUI.ViewModels
{
    public class PlayerCountViewModel
    {
        [Required(ErrorMessage = "Podaj liczbę graczy")]
        [Range(1, 6, ErrorMessage = "Liczba graczy miedzy 1 i 6")]
        public int PlayerCount { get; set; }
    }  
}
