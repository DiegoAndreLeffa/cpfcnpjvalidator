namespace CpfCnpjValidator.Domain;

/// <summary>
/// Classe responsável pela validação de CPF.
/// </summary>
public static class CpfValidator
{
    private const int CpfLength = 11;

    /// <summary>
    /// Valida um número de CPF.
    /// </summary>
    /// <param name="cpf">O CPF a ser validado.</param>
    /// <returns>True se o CPF for válido, caso contrário, false.</returns>
    public static bool IsValid(string cpf)
    {
        // Remove caracteres não numéricos.
        var cleanedCpf = new string(cpf.Where(char.IsDigit).ToArray());

        // Verifica o tamanho do CPF.
        if (cleanedCpf.Length != CpfLength)
            return false;

        // Verifica se todos os dígitos são iguais.
        if (AllDigitsAreEqual(cleanedCpf))
            return false;

        // Calcula os dígitos verificadores.
        var firstVerifierDigit = CalculateVerifierDigit(cleanedCpf.Substring(0, 9));
        var secondVerifierDigit = CalculateVerifierDigit(cleanedCpf.Substring(0, 10));

        // Compara os dígitos calculados com os dígitos do CPF.
        return cleanedCpf.EndsWith($"{firstVerifierDigit}{secondVerifierDigit}");
    }

    private static bool AllDigitsAreEqual(string cpf)
    {
        for (int i = 1; i < cpf.Length; i++)
        {
            if (cpf[i] != cpf[0])
                return false;
        }
        return true;
    }

    private static int CalculateVerifierDigit(string partialCpf)
    {
        var sum = 0;
        var multiplier = partialCpf.Length + 1;

        foreach (var digit in partialCpf)
        {
            sum += (digit - '0') * multiplier--;
        }

        var remainder = sum % 11;
        return remainder < 2 ? 0 : 11 - remainder;
    }
}