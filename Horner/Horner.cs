namespace Horner;

public sealed class Horner
{
    public static int[] Solve(int[] coefficients, out int[] factored)
    {
        factored = new int[coefficients.Length];

        
        int degree = coefficients.Length - 1;
        var possibleSolutions = FindPossibleSolutions(coefficients.LastOrDefault());
        var solutions = new List<int>();

        foreach (var solution in possibleSolutions)
        {
            if (degree == 0) break;
        
            int current = coefficients.FirstOrDefault();
            Array.Copy(coefficients, factored, coefficients.Length);
            
            for (int i = 1; i <= degree; ++i)
            {
                current = solution * current + coefficients[i];
                factored[i] = current;
            }
        
            if (current == 0)
            {
                solutions.Add(solution);
                Array.Copy(factored, coefficients, coefficients.Length);
                degree--;
            }
        }
        
        return solutions.ToArray();
    }

    private static List<int> FindPossibleSolutions(int coefficient)
    {
        var possibleSolutions = new List<int>();
        var abs = Math.Abs(coefficient);
        
        for (int i = 1; i <= abs / 2; ++i)
        {
            if (abs % i == 0)
            {
                possibleSolutions.Add(i);
                possibleSolutions.Add(-1 * i);
            }
        }

        return possibleSolutions;
    }
}