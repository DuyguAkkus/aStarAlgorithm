using System.ComponentModel.DataAnnotations;

namespace aStarAlgorithm.Models;

public class PuzzleInputViewModel
{
    [Required(ErrorMessage = "Başlangıç durumu zorunludur.")]
    [ValidPuzzleString]
    public string Start { get; set; }

    [Required(ErrorMessage = "Hedef durumu zorunludur.")]
    [ValidPuzzleString]
    public string Goal { get; set; }
}