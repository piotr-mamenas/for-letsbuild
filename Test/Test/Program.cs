using System;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                throw new ArgumentException("No filename specified");
            }

            var problemDictionary = BoxSolverFileReader.GetDeserializedProblemsDictionary(args[0]);
            foreach (var problem in problemDictionary)
            {
                var problemSolution = BoxSolver.GetMinimumCubesToFillBoxCount(problem.Key, problem.Value);
                Console.WriteLine(problemSolution);
            }
        }
    }
}
