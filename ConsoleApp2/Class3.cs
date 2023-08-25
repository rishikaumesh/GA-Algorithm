using System;

namespace GeneticAlgorithm
{
    public class DNA
    {
        public char[] genes = new char[18];
        private string target;
        public float Fitness { get; set; }

        private static Random rnd = new Random();
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789 ";

        public DNA(string target)
        {
            this.target = target;

            for (int i = 0; i < this.genes.Length; i++)
            {
                genes[i] = chars[rnd.Next(chars.Length)];
            }
        }

        public void EvaluateFitness()
        {
            int score = 0;

            for (int i = 0; i < this.genes.Length; i++)
            {
                if (genes[i] == target[i])
                {
                    score++;
                }
            }

            Fitness = (float)score / target.Length;
        }

        public void Mutate(float mutationRate)
        {
            for (int i = 0; i < genes.Length; i++)
            {
                if (rnd.NextDouble() < mutationRate)
                {
                    genes[i] = (char)rnd.Next(32, 128);
                }
            }
        }

        public override string ToString()
        {
            return new string(genes);
        }
    }
}