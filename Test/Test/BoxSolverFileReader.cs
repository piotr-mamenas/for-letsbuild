using System;
using System.Collections.Generic;
using System.IO;

namespace Test
{
    public class BoxSolverFileReader
    {
        /// <summary>
        /// Deserializes the variables for each exercise from the file into a dictionary
        /// containing the dimensions of the Box and the available cubes
        /// </summary>
        /// <param name="fileName">File with exercise</param>
        /// <returns>Dictionary of exercise variables</returns>
        public static Dictionary<Box, List<int>> GetDeserializedProblemsDictionary(string fileName)
        {
            var lines = File.ReadLines(fileName);

            var problemsDictionary = new Dictionary<Box, List<int>>();
            foreach (var line in lines)
            {
                var tokens = line.Split(" ");
                var boxDimensions = new List<int>();

                for (var cnt = 0; cnt < 3; cnt++)
                {
                    HandleIncorrectInput(tokens[cnt], i =>
                    {
                        boxDimensions.Add(i);
                    });
                }

                var availableCubes = new List<int>();
                for (var cnt = 3; cnt < tokens.Length; cnt++)
                {
                    HandleIncorrectInput(tokens[cnt], i =>
                    {
                        availableCubes.Add(i);
                    });
                }

                var currentBox = new Box(boxDimensions[0], boxDimensions[1], boxDimensions[2]);
                problemsDictionary.Add(currentBox, availableCubes);
            }

            return problemsDictionary;
        }

        /// <summary>
        /// Helper method to assist parsing incorrect input that might appear in the input file
        /// </summary>
        /// <param name="input">Tested Token</param>
        /// <param name="actionIfSuccessful">Method to execute if no issue encountered</param>
        private static void HandleIncorrectInput(string input, Action<int> actionIfSuccessful)
        {
            if (int.TryParse(input, out int parsedToken))
            {
                actionIfSuccessful(parsedToken);
            }
            else
            {
                throw new ArgumentOutOfRangeException($"Incorrect token encountered when reading file: ${input}");
            }
        }
    }


}
