﻿using System;
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
                //get 3 different elements in interval
                int[] rands = new int[3];
                Element[] parents = new Element[4];
                Element diff = new Element(0, 0, 0); //unassigned value, will (should!) be different
                Element noisy = new Element(0, 0, 0);//unassigned value, will (should!) be different
                Element trial = new Element(0, 0, 0);//unassigned value, will (should!) be different
                while (true) //until child in interval is found
                {
                    do { rands[0] = r.Next(population.Count); } while (rands[0] == i);
                    do { rands[1] = r.Next(population.Count); } while (rands[1] == i || rands[1] == rands[0]);
                    do { rands[2] = r.Next(population.Count); } while (rands[2] == i || rands[2] == rands[0] || rands[2] == rands[1]);

                    parents[0] = population[i];
                    parents[1] = population[rands[0]];
                    parents[2] = population[rands[1]];
                    parents[3] = population[rands[2]];

                    //get noisy vector (mutation)
                    diff = new Element(parents[1].X - parents[2].X, parents[1].Y - parents[2].Y, 0);


                    noisy = new Element(parents[3].X + ps["F"] * diff.X, parents[3].Y + ps["F"] * diff.Y, 0);

                    //get trial element (intersection)
                    trial = new Element((r.Next(1) < ps["CR"] ? noisy.X : parents[0].X),
                        (r.Next(1) < ps["CR"] ? noisy.Y : parents[0].Y), f);

                    if (trial.IsInInterval())
                        break;
                }
                //use parent or trial, whichever is better
                if (trial.Z < parents[0].Z)
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


    public class SOMA : Algorithm
    {

        public SOMA()
        {
            Name = "Self-Organizing Migrating Algorithm";
            ResetParameters();
        }
        private List<int> GetPRTVector(int size, Random r)
        {
            List<int> result = new List<int>();
            for (int i = 0; i < size; i++)
                result.Add((r.NextDouble() < ps["PRT"]) ? 1 : 0);
            return result;
        }
        public override List<Element> Run(List<Element> population, Lib.func f, bool integer)
        {

            if (ps["Migration"] <= 0)
                return population;
            //krizeni smeruje potomky
            //t = krok = 0 (while t<pathlen)
            //
            Element leader = population[0];
            Element worst = population[0];

            foreach (Element e in population)
            {
                if (e.Z < leader.Z)
                    leader = e;
                if (e.Z > worst.Z)
                    worst = e;
            }
            if (worst.Z - leader.Z < ps["MinDiv"])
                return population;

            Random r = new Random();
            List<Element> result = new List<Element>();
            for (int k = 0; k < population.Count; k++)
            {
                Element e = population[k];
                if (e == leader)
                {
                    result.Add(e);
                    continue;
                }
                List<Element> jumps = new List<Element>();
                for (int i = 0; i < ps["PathLength"] / ps["Step"]; i++)
                {
                    List<int> prtv = GetPRTVector(2, r);
                    Element leaderdiff = new Element(leader.X - e.X, leader.Y - e.Y, 0);
                    Element onejump = new Element(e.X + leaderdiff.X * i * ps["Step"] * prtv[0], e.Y + leaderdiff.Y * i * ps["Step"] * prtv[1], f);
                    if (onejump.IsInInterval())
                        jumps.Add(onejump);
                }
                int bestindex = -1;
                for (int j = 0; j < jumps.Count; j++)
                {
                    if (jumps[j].Z < e.Z)
                        bestindex = j;
                }
                result.Add((bestindex == -1) ? population[k] : jumps[bestindex]);
            }
            ps["Migration"]--;
            return result;
        }

        public override void ResetParameters()
        {
            ps = new Dictionary<string, float>();
            ps.Add("PathLength", 1.4f);
            ps.Add("Step", 0.11f);
            ps.Add("PRT", 0.8f);
            ps.Add("Migrations", 10); //number of generations, per Step
            ps.Add("MinDiv", -1); //minimal difference between best and worst, <0 => ignored
            ps.Add("Migration", 10);
        }
    }

    public class EvolutionalStrategy : Algorithm
    {
        public EvolutionalStrategy()
        {
            Name = "Evolutional Strategy";
            ResetParameters();
        }

        /*
        private Element GetDeviation(float mi, float delta, Lib.func f)
        {
            float a = (Functions.Max - Functions.Min) / 2;
            Random r = new Random();
            float x = (float)(r.NextDouble() * (Functions.Max - Functions.Min) + Functions.Min)/50;
            float y = (float)(r.NextDouble() * (Functions.Max - Functions.Min) + Functions.Min)/50;
            delta = delta * ps["Range"];
            float xgauss = (float)(1 / (Math.Sqrt(2 * Math.PI)) * a * Math.Pow(Math.E, -Math.Pow(x - mi, 2) / (2 * delta * delta)));
            float ygauss = (float)(1 / (Math.Sqrt(2 * Math.PI)) * a * Math.Pow(Math.E, -Math.Pow(y - mi, 2) / (2 * delta * delta)));
            return new Element(xgauss, ygauss, f);
        }*/

        public override List<Element> Run(List<Element> population, Lib.func f, bool integer)
        {
            if (ps["Iteration"] >= ps["Iterations"])
                return population;
            Random r = new Random();
            List<Element> result = new List<Element>();
            Element best = population[0];
            foreach (Element e in population)
                if (e.Fitness > best.Fitness)
                    best = e;
            if (best.Fitness > ps["FV"])
                return population;
            List<Element> children = new List<Element>();


            foreach (Element e in population)
            {
                for (int i = 0; i < ps["Children"]; i++)
                {
                    Element newelement = null;
                    while (newelement == null || !newelement.IsInInterval())
                    {
                        /*double r = Math.Pow(Math.Pow(best.X - e.X, 2) + Math.Pow(best.Y - e.Y, 2) + Math.Pow(best.Z - e.Z, 2), 0.5);

                        float delta = (r == 0) ? 0.1f : (float)(1.224 * r / population.Count);
                        if (inficounter >= 10)
                            delta /= inficounter;
                        Element deviation = GetDeviation(0, delta, f);*/
                        float newx = e.X + (float)(r.NextDouble() * (Functions.Max - Functions.Min) + Functions.Min) * ps["Range"];
                        float newy = e.Y + (float)(r.NextDouble() * (Functions.Max - Functions.Min) + Functions.Min) * ps["Range"];
                        newelement = new Element(newx, newy, f);
                    }
                    children.Add(newelement);
                }
            }

            result.AddRange(children);
            if (ps["Elitism"] == 1)
                result.AddRange(population);

            result.Sort(new ElementComparer());
            while (result.Count > population.Count)
                result.RemoveAt(population.Count);

            ps["Iteration"]++;

            //(fmax-fmin)*range;
            return result;
        }

        public override void ResetParameters()
        {
            ps = new Dictionary<string, float>();
            //+ - best from parents and children (elitism)
            //, - best from children (no elitism)
            ps.Add("Elitism", 1f);
            //ps.Add("Range", 0.03f);
            ps.Add("Range", 0.1f);
            ps.Add("FV", 0.9999f); //desired fitness
            ps.Add("Children", 4f);
            ps.Add("Iterations", 30);
            ps.Add("Iteration", 0);
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
