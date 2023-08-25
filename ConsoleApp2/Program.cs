using System;

namespace GeneticAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            Population problem1 = new Population(150, 0.01f, "to be or not to be");
            problem1.GenerateSolution();
            Console.ReadLine();

        }
    }
}