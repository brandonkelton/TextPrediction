using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextPrediction
{
    public class Node
    {
        public string Text { get; private set; }
        public bool IsWord { get; private set; }
        public List<Node> Nodes { get; private set; } = new List<Node>();

        public Node()
        {
            this.Text = null;
            this.IsWord = false;
        }

        public Node(string text, bool isWord = false)
        {
            this.Text = text;
            this.IsWord = isWord;
        }

        public bool IsRoot => this.Text == null;

        public void Add(string text, int length = 0)
        {
            if (text.Equals(this.Text, StringComparison.OrdinalIgnoreCase))
            {
                this.IsWord = true;
                return;
            }

            foreach (var node in Nodes)
            {
                if (text.StartsWith(node.Text, StringComparison.OrdinalIgnoreCase))
                {
                    node.Add(text, ++length);
                    return;
                }
            }

            var newNode = new Node(new string(text.Take(++length).ToArray()));
            this.Nodes.Add(newNode);

            if (text.Length > length)
            {
                newNode.Add(text, length);
            }
        }
    }
}
