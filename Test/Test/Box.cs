namespace Test
{
    public class Box
    {
        public int Width { get; set; }

        public int Height { get; set; }

        public int Length { get; set; }

        public int TakenSpace { get; set; }

        public Box(int width, int height, int length)
        {
            Width = width;
            Height = height;
            Length = length;
            TakenSpace = 0;
        }
    }
}
