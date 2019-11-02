using System;
using System.Collections.Generic;

namespace Test
{
    public class BoxSolver
    {
        /// <summary>
        /// Get the minimum number of cubes to fill a box.
        /// The cubes in the list are nth power of 2 where n is the index of list
        /// </summary>
        /// <param name="box">Box with dimensions and status</param>
        /// <param name="availableCubes">The cubes are powers of 2, v</param>
        /// <returns>Minimum number of cubes</returns>
        public static int GetMinimumCubesToFillBoxCount(Box box, List<int> availableCubes)
        {
            var minimumNumberOfCubes = 0;
            var boxVolumeRemaining = GetVolume(box.Width, box.Length, box.Height);

            if (IsEnoughCubes(box, boxVolumeRemaining, availableCubes) == -1)
            {
                return -1;
            }

            for (var cnt = availableCubes.Count - 1; cnt >= 0; cnt--)
            {
                var singleCubeWidth =  Math.Pow(2, cnt);

                if (!CubeFitInBox(box, singleCubeWidth))
                {
                    continue;
                }

                box.TakenSpace = (int) singleCubeWidth;

                var singleCubeVolume = (int) Math.Pow(singleCubeWidth,3);
                var cubesOfTypeFitting = boxVolumeRemaining / singleCubeVolume;

                if (cubesOfTypeFitting >= availableCubes[cnt])
                {
                    cubesOfTypeFitting = availableCubes[cnt];
                }

                minimumNumberOfCubes += cubesOfTypeFitting;
                boxVolumeRemaining -= cubesOfTypeFitting * singleCubeVolume;
            }
            return minimumNumberOfCubes;
        }

        /// <summary>
        /// Check if there are enough fitting cubes to fill the box
        /// </summary>
        /// <param name="box"></param>
        /// <param name="boxTotalVolume"></param>
        /// <param name="availableCubes"></param>
        /// <returns></returns>
        private static int IsEnoughCubes(Box box, int boxTotalVolume, IReadOnlyList<int> availableCubes)
        {
            var cubesTotalVolumeCapacity = 0;
            for (var cnt = availableCubes.Count - 1; cnt >= 0; cnt--)
            {
                var singleCubeWidth = Math.Pow(2, cnt);

                if (!CubeFitInBox(box, singleCubeWidth))
                {
                    continue;
                }

                if (cubesTotalVolumeCapacity > boxTotalVolume)
                {
                    break;
                }

                cubesTotalVolumeCapacity += (int)Math.Pow(singleCubeWidth, 3) * availableCubes[cnt];
            }

            if (cubesTotalVolumeCapacity < boxTotalVolume)
            {
                return -1;
            }

            return 0;
        }

        /// <summary>
        /// Check if a cube can be fitted inside of a box
        /// </summary>
        /// <param name="box"></param>
        /// <param name="cubeWidth"></param>
        /// <returns></returns>
        private static bool CubeFitInBox(Box box, double cubeWidth)
        {
            return box.Width - box.TakenSpace >= cubeWidth && box.Height >= cubeWidth
                || box.Height - box.TakenSpace >= cubeWidth && box.Length >= cubeWidth
                || box.Length - box.TakenSpace >= cubeWidth && box.Width >= cubeWidth;
        }

        private static int GetVolume(int width, int length, int height)
        {
            return width * length * height;
        }
    }
}
