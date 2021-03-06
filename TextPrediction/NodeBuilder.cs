﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextPrediction
{
    public class NodeBuilder
    {
        public string[] TextItems { get; private set; }
        public Node RootNode { get; private set; } = new Node();

        public NodeBuilder(string[] textItems)
        {
            this.TextItems = textItems;
        }

        public void Build()
        {
            var alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
            alphabet.ToList().ForEach(c => this.RootNode.Add(c.ToString()));

            foreach (var item in this.TextItems)
            {
                RootNode.Add(item);
            }
        }
    }
}
