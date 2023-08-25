using System;
using System.Collections.Generic;

namespace GeneticAlgorithm
{
    public class Population
    {
        private int totalPopulation;
        private float mutationRate;
        private string target;

        private DNA[] population;
        private List<DNA> matingPool;

        private Random rnd = new Random();

        public Population() : this(150) { }

        public Population(int totalPopulation) : this(150, 0.01f) { }

        public Population(int totalPopulation, float mutationRate) : this(150, 0.01f, "to be or not to be") { }

        public Population(int totalPopulation, float mutationRate, string target)
        {
            this.totalPopulation = totalPopulation;
            this.mutationRate = mutationRate;
            this.target = target;

            population = new DNA[this.totalPopulation];
            for (int i = 0; i < this.population.Length; i++)
            {
                population[i] = new DNA(this.target);
            }
        }

        public void GenerateSolution()
        {
            int random = rnd.Next(population.Length);
            int generationCount = 0; // Initialize the generation count

            while (population[random].ToString() != target)
            {
                Console.Write("Current Random String: ");
                Console.WriteLine(population[random].ToString());
                EvaluateElementsFitness();
                CreateMatingPool();
                Reproduce();
                generationCount++; // Increment the generation count in each iteration
            }

            Console.WriteLine("\nPhrase: {0}", population[random].ToString());
            Console.WriteLine($"Solution found in {generationCount} generations.");
        }


        private void EvaluateElementsFitness()
        {
            for (int i = 0; i < this.population.Length; i++)
            {
                population[i].EvaluateFitness();
            }
        }

        private void CreateMatingPool()
        {
            matingPool = new List<DNA>();

            for (int i = 0; i < this.population.Length; i++)
            {
                int n = (int)(population[i].Fitness * 100);

                for (int j = 0; j < n; j++)
                {
                    matingPool.Add(population[i]);
                }
            }
        }

        private void Reproduce()
        {
            for (int i = 0; i < this.population.Length; i++)
            {
                int a = rnd.Next(0, matingPool.Count);
                int b = rnd.Next(0, matingPool.Count);
                DNA parentA = matingPool[a];
                DNA parentB = matingPool[b];
                DNA child = Crossover(parentA, parentB);
                child.Mutate(this.mutationRate);

                population[i] = child;
            }

        }

        private DNA Crossover(DNA parentA, DNA parentB)
        {
            DNA child = new DNA(this.target);

            int midpoint = (int)rnd.Next(child.genes.Length);

            for (int i = 0; i < child.genes.Length; i++)
            {
                if (i > midpoint)
                {
                    child.genes[i] = parentA.genes[i];
                }
                else
                {
                    child.genes[i] = parentB.genes[i];
                }
            }
            return child;
        }
    }
}