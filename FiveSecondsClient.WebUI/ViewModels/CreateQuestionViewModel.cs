using System.ComponentModel.DataAnnotations;

namespace FiveSecondsClient.WebUI.ViewModels
{
    public class CreateQuestionViewModel
    {
        [Required(ErrorMessage = "Podaj pytanie")]
        [StringLength(255, ErrorMessage = "Maksymalnie 255 znaków")]
        public string Question { get; set; }
    }
}
