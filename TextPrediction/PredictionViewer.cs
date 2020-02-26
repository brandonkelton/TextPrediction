using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextPrediction
{
    public class PredictionViewer
    {
        public Node RootNode { get; private set; }

        private List<char> characters = new List<char>();
        private int cursorLeft;
        private int cursorTop;

        public PredictionViewer(Node rootNode)
        {
            this.RootNode = rootNode;
        }

        public void Start()
        {
            Console.Write("> ");

            this.cursorLeft = Console.CursorLeft;
            this.cursorTop = Console.CursorTop;

            while (true)
            {
                var readKey = Console.ReadKey();

                ClearDisplayArea();

                if (readKey.Key == ConsoleKey.Enter && string.Join("", characters).ToLower() == "quit")
                {
                    break;
                }
                else if (readKey.Key == ConsoleKey.Backspace || readKey.Key == ConsoleKey.Delete)
                {
                    if (characters.Count > 0)
                    {
                        RemoveLastCharacter();
                        if (characters.Count > 0)
                        {
                            EvaluateAndFindResults();
                            Console.SetCursorPosition(cursorLeft, cursorTop);
                        }
                    }
                    else Console.SetCursorPosition(cursorLeft, cursorTop);
                }
                else
                {
                    characters.Add(readKey.KeyChar);
                    EvaluateAndFindResults();
                    cursorLeft = cursorLeft + 1;
                    Console.SetCursorPosition(cursorLeft, cursorTop);
                }
            }
        }

        private void EvaluateAndFindResults()
        {
            var results = this.RootNode.FindWords(string.Join("", characters)).Take(10).ToArray();

            for (int i = 0; i < results.Length; i++)
            {
                Console.SetCursorPosition(0, cursorTop + i + 5);
                Console.Write(results[i].Text);
            }
        }

        private void RemoveLastCharacter()
        {
            characters.RemoveAt(characters.Count - 1);
            cursorLeft = cursorLeft - 1;
            Console.SetCursorPosition(cursorLeft, cursorTop);
            Console.Write(" ");
            Console.SetCursorPosition(cursorLeft, cursorTop);
        }

        private void ClearDisplayArea()
        {
            var spaces = string.Join("", Enumerable.Repeat(" ", Console.BufferWidth));
            for (int i = 0; i < 11; i++)
            {
                Console.SetCursorPosition(0, cursorTop + i + 5);
                Console.Write(spaces);
            }
        }
    }
}
