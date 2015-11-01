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
    }

    public class Blind : Algorithm
    {
        public Blind()
        {
            Name = "Blind Search";
            ps = new Dictionary<string, float>();
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
    }

    public class SimulatedAnnealing : Algorithm
    {
        public SimulatedAnnealing()
        {
            Name = "Simulated Annealing";
            ps = new Dictionary<string, float>();
            ps.Add("T0", 1f);
            ps.Add("Tf", 0.05f);
            ps.Add("alfa", 0.95f);
            ps.Add("nT", 10f);
        }

        public override List<Element> Run(List<Element> population, Lib.func f, bool integer)
        {
            Random r = new Random();
            List<Element> result = new List<Element>();
            result.AddRange(population);
            
            float t = ps["T0"];
            while (t >= ps["Tf"]) //while warm enough
            {
                for(int i=0; i<result.Count; i++) // for each element
                {
                    for (int j = 0; j < ps["nT"]; j++) // reps
                    {
                        
                        //generate list of neighbors
                        List<Element>neighbors = new List<Element>();
                        float max = (Functions.Max - Functions.Min)/2;
                        Element parent = result[i];
                        for (int k = 0; k < ps["nT"]; k++) //number of neighbors often same as number of Metropolis repetitions
                        {
                            float x = parent.X + t * (float)(r.NextDouble()*max-max/2);
                            float y = parent.Y + t * (float)(r.NextDouble() * max - max / 2);

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
                        Element chosenone = neighbors[r.Next(neighbors.Count-1)];
                        //better? use it
                        if (chosenone.Z < parent.Z)
                            result[i] = chosenone;
                        else
                        //worse? if lucky enough, use it
                        {
                            float badluck = (float)r.NextDouble();
                            float exp = (float)Math.Pow(Math.E, -(chosenone.Z-parent.Z)/t);
                            if (badluck < exp)
                                result[i] = chosenone;
                        }
                    }
                }
                t *= ps["alfa"];
            }
            return result;
        }
    }

}
