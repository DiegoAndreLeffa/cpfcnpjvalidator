using CpfCnpjValidator.Domain;
using Xunit;

namespace CpfCnpjValidator.Tests;

public class CnpjValidatorTests
{
    [Theory]
    [InlineData("11222333000181", true)] // CNPJ válido
    [InlineData("11111111111111", false)] // CNPJ com todos os dígitos iguais
    [InlineData("11222333000182", false)] // CNPJ inválido
    [InlineData("11.222.333/0001-81", true)] // CNPJ válido com formatação
    public void IsValid_ShouldReturnExpectedResult_ForGivenCnpj(string cnpj, bool expected)
    {
        // Act
        var result = CnpjValidator.IsValid(cnpj);

        // Assert
        Assert.Equal(expected, result);
    }
}