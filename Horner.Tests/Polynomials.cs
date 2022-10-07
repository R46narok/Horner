using FluentAssertions;
using Xunit;

namespace Horner.Tests;

public class Polynomials
{
    [Theory]
    [InlineData(1, -2, -5, 6)]
    public void Degree3_ShouldFindSolutions(int x3, int x2, int x1, int x0)
    {
        var coefficients = new [] {x3, x2, x1, x0};
        var solutions = Horner.Solve(coefficients, out var factored);

        solutions[0].Should().Be(1);
        solutions[1].Should().Be(-2);
        solutions[2].Should().Be(3);
        solutions.Should().HaveCount(3);
    }
}