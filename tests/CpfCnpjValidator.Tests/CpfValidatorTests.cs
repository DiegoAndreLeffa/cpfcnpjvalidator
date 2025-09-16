using CpfCnpjValidator.Domain;
using Xunit;

namespace CpfCnpjValidator.Tests;

public class CpfValidatorTests
{
    [Theory]
    [InlineData("12345678909", true)] // CPF válido
    [InlineData("11111111111", false)] // CPF com todos os dígitos iguais
    [InlineData("12345678901", false)] // CPF inválido
    [InlineData("123.456.789-09", true)] // CPF válido com formatação
    public void IsValid_ShouldReturnExpectedResult_ForGivenCpf(string cpf, bool expected)
    {
        // Act
        var result = CpfValidator.IsValid(cpf);

        // Assert
        Assert.Equal(expected, result);
    }
}