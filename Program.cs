class Program
{
    static void Main(string[] args)
    {
        var lines = File.ReadAllLines("dead_pixels_input.txt");
        var N = int.Parse(lines[0]);

        for (int t = 1; t <= N; t++) {
            var result = SolveCase(lines[t]);
            System.Console.WriteLine("Case #" + t + ": " + result);
        }
    }

    static int SolveCase(string testCase) {
        var nums = testCase.Split(" ").Select(s => int.Parse(s)).ToArray();
        int W = nums[0], H = nums[1], P = nums[2], Q = nums[3];
        int N = nums[4];
        int X = nums[5], Y = nums[6];
        int a = nums[7], b = nums[8], c = nums[9], d = nums[10];

        int SizeX = W-P+1, SizeY = H-Q+1;
        bool[,] pixels = new bool[SizeX, SizeY];

        var dead_pixels = new HashSet<(int, int)>();
        int invalid_count = 0;

        while (N-- > 0 && !dead_pixels.Contains((X, Y))) {
            dead_pixels.Add((X, Y));

            int sx = Math.Max(0, X - P + 1), ex = Math.Min(X+1, SizeX);
            int sy = Math.Max(0, Y - Q + 1), ey = Math.Min(Y+1, SizeY);

            for (int y = sy; y < ey; y++) {
                for (int x = sx; x < ex; x++) {
                    if (!pixels[x, y]) {
                        pixels[x, y] = true;
                        invalid_count++;
                    }
                }
            }

            (X, Y) = ((X * a + Y * b + 1) % W, (X * c + Y * d + 1) % H);
        }

        return SizeX * SizeY - invalid_count;
    }
}
