using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compress_Data
{
    class ShannonFano
    {
        private List<Node> nodes = new List<Node>();
        public Node Root { get; set; }
        public Dictionary<char, int> Frequencies = new Dictionary<char, int>();

        public void Execite(string source)
        {
            for (int i = 0; i < source.Length; i++)
            {
                if (!Frequencies.ContainsKey(source[i]))
                {
                    Frequencies.Add(source[i], 0);
                }

                Frequencies[source[i]]++;
            }

            //foreach (KeyValuePair<char, int> symbol in Frequencies)
            //{
            //    nodes.Add(new Node() { Symbol = symbol.Key, Frequency = symbol.Value });
            //}

            //while (nodes.Count > 1)
            //{
            //    List<Node> orderedNodes = nodes.OrderBy(node => node.Frequency).ToList();

            //    if (orderedNodes.Count >= 2)
            //    {
            //        List<Node> taken = orderedNodes.Take(2).ToList();

            //        Node parent = new Node()
            //        {
            //            Symbol = '*',
            //            Frequency = taken[0].Frequency + taken[1].Frequency,
            //            Left = taken[0],
            //            Right = taken[1]
            //        };

            //        nodes.Remove(taken[0]);
            //        nodes.Remove(taken[1]);
            //        nodes.Add(parent);
            //    }

            //    Root = nodes.FirstOrDefault();
            //}
        }
    }
}
