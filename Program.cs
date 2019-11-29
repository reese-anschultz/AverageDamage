using System;

namespace AverageDamage
{
    public class Program
    {
        private const int DamagePerHeads = 30;
        private const int Trials = 10000;
        private const int Samples = 30;
        private static readonly Random Random = new Random(1);
        private static int _maxDepth;
        private static int _totalDepth;
        private static int _maxSum;
        private static int _totalSum;

        public static void Main()
        {
            for (var samples = Samples; samples > 0; --samples)
                DoSample();
            Console.WriteLine($"Max depth/sum={_maxDepth}/{_maxSum}");
            Console.WriteLine($"Average depth/sum={(double)_totalDepth / Samples / Trials}/{(double)_totalSum / Samples / Trials}");
        }

        static void DoSample()
        {
            var sampleSum = 0;
            var sampleDepth = 0;
            for (var trials = Trials; trials > 0; --trials)
            {
                var sum = 0;
                var depth = 0;
                while (Random.Next(2) > 0)
                {
                    sum += DamagePerHeads;
                    depth++;
                }
                if (depth > _maxDepth)
                    _maxDepth = depth;
                sampleDepth += depth;
                if (sum > _maxSum)
                    _maxSum = sum;
                sampleSum += sum;
            }
            _totalDepth += sampleDepth;
            _totalSum += sampleSum;
            Console.WriteLine($"Average depth/sum={(double)sampleDepth / Trials}/{(double)sampleSum / Trials}");
        }
    }
}
