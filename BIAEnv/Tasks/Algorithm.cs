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
        public override string ToString()
        {
            return Name;
        }
    }

    public class Blind : Algorithm 
    {
        public Blind()
        {
            Name = "Blind Search";
        }

        public override List<Element> Run(List<Element> population, Lib.func f, bool integer) 
        {
            Element best = null;
            foreach (Element e in population) 
            {
                if (best==null || e.Fitness > best.Fitness)
                    best = e;
            }
            List<Element> result = new List<Element>();
            result.Add(best);
            result.AddPopulation(population.Count-1, f, integer);
            return result;
        }
    }
}
