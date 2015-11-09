using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks
{
    public abstract class Algorithm
    {
        public string Name { get; set; }
        public abstract List<Element> Run(List<Element> population, Lib.func f, bool integer);
        public Dictionary<String, float> ps;
        public override string ToString()
        {
            return Name;
        }
        public string GetParameters()
        {
            StringBuilder sb = new StringBuilder();
            foreach (String s in ps.Keys)
                sb.AppendFormat("{0}={1}\r\n", s, ps[s]);
            return sb.ToString();
        }

        public void UpdateParameters(string p)
        {
            String[] lines = p.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (String s in lines)
            {
                try
                {
                    string[] kvp = s.Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
                    if (ps.Keys.Contains(kvp[0]))
                        ps[kvp[0]] = (float)Convert.ToDouble(kvp[1]);
                }
                catch
                {
                    continue;
                }
            }
        }

        public abstract void ResetParameters();
    }

    public class Blind : Algorithm
    {
        public Blind()
        {
            Name = "Blind Search";
            ResetParameters();
        }

        public override List<Element> Run(List<Element> population, Lib.func f, bool integer)
        {
            Element best = null;
            foreach (Element e in population)
            {
                if (best == null || e.Fitness > best.Fitness)
                    best = e;
            }
            List<Element> result = new List<Element>();
            result.Add(best);
            result.AddPopulation(population.Count - 1, f, integer);
            return result;
        }

        public override void ResetParameters()
        {
            ps = new Dictionary<string, float>();
        }
    }

    public class SimulatedAnnealing : Algorithm
    {
        public SimulatedAnnealing()
        {
            Name = "Simulated Annealing";
            ResetParameters();
        }

        public override List<Element> Run(List<Element> population, Lib.func f, bool integer)
        {
            Random r = new Random();
            List<Element> result = new List<Element>();
            result.AddRange(population);

            //float t = ps["T0"];
            // while (t >= ps["Tf"]) //while warm enough
            if (ps["T"] >= ps["Tf"])
            {
                for (int i = 0; i < result.Count; i++) // for each element
                {
                    for (int j = 0; j < ps["nT"]; j++) // reps
                    {

                        //generate list of neighbors
                        List<Element> neighbors = new List<Element>();
                        float max = (Functions.Max - Functions.Min) / 2;
                        Element parent = result[i];
                        for (int k = 0; k < ps["nT"]; k++) //number of neighbors often same as number of Metropolis repetitions
                        {
                            float x = parent.X + ps["T"] * (float)(r.NextDouble() * max - max / 2);
                            float y = parent.Y + ps["T"] * (float)(r.NextDouble() * max - max / 2);

                            if (x < Functions.Min)
                                x = Functions.Min;
                            else if (x > Functions.Max)
                                x = Functions.Max;

                            if (y < Functions.Min)
                                y = Functions.Min;
                            else if (y > Functions.Max)
                                y = Functions.Max;
                            neighbors.Add(new Element(x, y, f));
                        }

                        //choose randomly
                        Element chosenone = neighbors[r.Next(neighbors.Count - 1)];
                        //better? use it
                        if (chosenone.Z < parent.Z)
                            result[i] = chosenone;
                        else
                        //worse? if lucky enough, use it
                        {
                            float badluck = (float)r.NextDouble();
                            float exp = (float)Math.Pow(Math.E, -(chosenone.Z - parent.Z) / ps["T"]);
                            if (badluck < exp)
                                result[i] = chosenone;
                        }
                    }
                }
                ps["T"] *= ps["alfa"];
            }
            return result;
        }

        public override void ResetParameters()
        {
            ps = new Dictionary<string, float>();
            ps.Add("T0", 1f);
            ps.Add("Tf", 0.05f);
            ps.Add("alfa", 0.95f);
            ps.Add("nT", 10f);
            ps.Add("T", 1f);
        }
    }

    //dif evol - skripta 101
    //cr=0.6 - prah krizeni (kdy k mutaci dojde)
    //f=0.7 - mutacni konstanta - velikost mutace
    //populace min 4

    public class DifferentialEvolution : Algorithm
    {
        public DifferentialEvolution()
        {
            Name = "Differential Evolution";
            ResetParameters();
        }

        public override List<Element> Run(List<Element> population, Lib.func f, bool integer)
        {
            if (population.Count < 4) // too small
                return population;
            Random r = new Random();
            List<Element> result = new List<Element>();
            for (int i = 0; i < population.Count; i++) //for each element
            {
                //get 3 different elements
                int[] rands = new int[3];
                do { rands[0] = r.Next(population.Count); } while (rands[0] == i);
                do { rands[1] = r.Next(population.Count); } while (rands[1] == i || rands[1]==rands[0]);
                do { rands[2] = r.Next(population.Count); } while (rands[2] == i || rands[2] == rands[0] || rands[2]==rands[1]);
                Element[] parents = new Element[4];
                parents[0] = population[i];
                parents[1] = population[rands[0]];
                parents[2] = population[rands[1]];
                parents[3] = population[rands[2]];

                //get noisy vector (mutation)
                Element diff = new Element(parents[1].X-parents[2].X, parents[1].Y-parents[2].Y, f);
                Element noisy = new Element(parents[3].X+ps["F"]*diff.X, parents[3].Y+ps["F"]*diff.Y, f);

                //get trial vector (intersection)
                Element trial = new Element((r.Next(1) < ps["CR"] ? noisy.X : parents[0].X), 
                    (r.Next(1) < ps["CR"] ? noisy.Y : parents[0].Y), f);

                //use parent or trial, whichever is better
                if (trial.IsInInterval() && trial.Z < parents[0].Z)
                    result.Add(trial);
                else
                    result.Add(parents[0]);
            }
            return result;
        }

        public override void ResetParameters()
        {
            ps = new Dictionary<string, float>();
            ps.Add("CR", 0.6f);
            ps.Add("F", 0.7f);
        }
    }


    public static class Algorithms
    {
        public static void ResetParameters(this List<Algorithm> algos)
        {
            foreach (Algorithm a in algos)
                a.ResetParameters();
        }
    }
}
