namespace CpfCnpjValidator.Domain;

/// <summary>
/// Classe responsável pela validação de CNPJ.
/// </summary>
public static class CnpjValidator
{
    private const int CnpjLength = 14;

    /// <summary>
    /// Valida um número de CNPJ.
    /// </summary>
    /// <param name="cnpj">O CNPJ a ser validado.</param>
    /// <returns>True se o CNPJ for válido, caso contrário, false.</returns>
    public static bool IsValid(string cnpj)
    {
        // Remove caracteres não numéricos.
        var cleanedCnpj = new string(cnpj.Where(char.IsDigit).ToArray());

        // Verifica o tamanho do CNPJ.
        if (cleanedCnpj.Length != CnpjLength)
            return false;

        // Verifica se todos os dígitos são iguais.
        if (AllDigitsAreEqual(cleanedCnpj))
            return false;

        // Calcula os dígitos verificadores.
        var firstVerifierDigit = CalculateVerifierDigit(cleanedCnpj.Substring(0, 12));
        var secondVerifierDigit = CalculateVerifierDigit(cleanedCnpj.Substring(0, 13));

        // Compara os dígitos calculados com os dígitos do CNPJ.
        return cleanedCnpj.EndsWith($"{firstVerifierDigit}{secondVerifierDigit}");
    }

    private static bool AllDigitsAreEqual(string cnpj)
    {
        for (int i = 1; i < cnpj.Length; i++)
        {
            if (cnpj[i] != cnpj[0])
                return false;
        }
        return true;
    }

    private static int CalculateVerifierDigit(string partialCnpj)
    {
        var multipliers1 = new int[] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
        var multipliers2 = new int[] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

        var multipliers = partialCnpj.Length == 12 ? multipliers1 : multipliers2;
        var sum = 0;

        for (int i = 0; i < partialCnpj.Length; i++)
        {
            sum += (partialCnpj[i] - '0') * multipliers[i];
        }

        var remainder = sum % 11;
        return remainder < 2 ? 0 : 11 - remainder;
    }
}