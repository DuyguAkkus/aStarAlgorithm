using System.ComponentModel.DataAnnotations;

public class ValidPuzzleStringAttribute : ValidationAttribute
{
    public override bool IsValid(object value)
    {
        var input = value as string;

        if (string.IsNullOrEmpty(input) || input.Length != 9)
            return false;

        // Sadece rakamlardan oluşuyor mu?
        if (!input.All(char.IsDigit))
            return false;

        // 0–8 arasında her rakam yalnızca 1 kez geçmeli
        var digits = input.ToCharArray();
        var unique = digits.Distinct();

        return unique.Count() == 9 && digits.All(d => d >= '0' && d <= '8');
    }

    public override string FormatErrorMessage(string name)
    {
        return $"{name} alanı 0–8 arası her rakamı yalnızca 1 kez içermelidir (toplam 9 rakam).";
    }
}