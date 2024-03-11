using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bor_Trie
{
    public class Trie
    {
        public class Node
        {
            public bool Terminal { get; set; }
            public Dictionary<char, Node> Children { get; set; }
            public int Number { get; set; }
            public Node()
            {
                Terminal = false;
                Children = new Dictionary<char, Node>();
                Number = 0;
            }
        }

        public Node root;
        public int Size { get; set; }
        public Trie()
        {
            Size = 0;
            root = new Node();
        }
        public bool Add(string s)
        {
            Node Chek_Node = root;
            for (int i = 0; i < s.Length; ++i)
            {
                if (Chek_Node.Children.ContainsKey(s[i]))
                {
                    Chek_Node = Chek_Node.Children[s[i]];
                }
                else
                {
                    Chek_Node.Children.Add(s[i], new Node());
                    Size++;
                    Chek_Node = Chek_Node.Children[s[i]];
                }
                Chek_Node.Number++;
            }
            if (Chek_Node.Terminal == false) { Chek_Node.Terminal = true; return true; }
            return false;
        }
        public bool Contains(string s)
        {
            Node Chek_Node = root;
            for (int i = 0; i < s.Length; ++i)
            {
                if (Chek_Node.Children.ContainsKey(s[i]))
                {
                    Chek_Node = Chek_Node.Children[s[i]];
                }
                else { return false; }
            }
            return Chek_Node.Terminal;
        }

        public bool Remove(string s)
        {
            Node Chek_Node = root;
            if (Contains(s))
            {
                for (int i = 0; i < s.Length; ++i)
                {
                    if (Chek_Node.Children[s[i]].Number > 1)
                    {
                        Chek_Node = Chek_Node.Children[s[i]];
                        Chek_Node.Number--;
                    }
                    else { Chek_Node.Children.Remove(s[i]); Size -= (s.Length - i); return true; }
                }
                return true;
            }
            return false;
        }

        public int HowManyStartsWithPrefix(string prefix)
        {
            Node Chek_Node = root;
            for (int i = 0; i < prefix.Length; ++i)
            {
                if (Chek_Node.Children.ContainsKey(prefix[i]))
                {
                    Chek_Node = Chek_Node.Children[prefix[i]];
                }
                else { return 0; }
            }
            return Chek_Node.Number;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            string s = Console.ReadLine(); // вводим строки через пробел
            string[] mas = s.Split(' ');
            Trie Trie = new Trie();
            foreach (string element in mas)
            {
                Console.WriteLine($"HowManyStartsWithPrefix:{Trie.HowManyStartsWithPrefix(element)},  Contains:{Trie.Contains(element)},  Remove:{Trie.Remove(element)}, Add:{Trie.Add(element)}");
                Console.WriteLine("");
            }
            Console.WriteLine("");

        }
    }
}