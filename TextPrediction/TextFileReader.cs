using System;
using System.Collections.Generic;
using System.Text;

namespace TextPrediction
{
    public class TextFileReader
    {
        public string FileName { get; private set; }
        public string[] Text { get; private set; }

        public TextFileReader(string fileName)
        {
            this.FileName = fileName;
        }

        public void Read()
        {
            this.Text = System.IO.File.ReadAllLines(this.FileName);
        }
    }
}
