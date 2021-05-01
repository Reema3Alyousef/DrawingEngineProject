using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingEngine.Tokenization.Handlers
{
    public class StringTokenizer : Tokenizable
    {
        private List<string> shapesKeywords;
        private List<string> penStyleKeywords;

        public StringTokenizer()
        {
            this.shapesKeywords = new List<string> { "rect", "cir", "line" };
            this.penStyleKeywords = new List<string> { "solid", "dashed", "dotted" };
        }
        
        public override bool tokenizable(Tokenizer t)
        {
            return Char.IsLetter(t.input.peek());
        }

        public bool isEscape(Tokenizer t)
        {
            char ch = t.input.step().Character;
            return (ch == '\"' || ch == '\\' || ch == '\r'
                    || ch == '\n' || ch == '\b' || ch == '\t' || ch == '\f');
        }

        static bool isLetter(Input input)
        {
            char currentCharacter = input.peek();
            return Char.IsLetter(currentCharacter);
        }

        public override Token tokenize(Tokenizer t)
        {
            char c = t.input.peek();
            string value = t.input.loop(isLetter);
            Color x = Color.FromName(value);

            if (this.shapesKeywords.Contains(value.ToLower()))
            {
                return new Token(t.input.Position, t.input.LineNumber,
                TokenType.Shape, value);
            }
            
            else if (!(x.A.Equals(0) && x.R.Equals(0) && x.G.Equals(0) && x.B.Equals(0)))
            { // a predefined color
                return new Token(t.input.Position, t.input.LineNumber,
                TokenType.NamedColor, value);
            }
            else if (this.penStyleKeywords.Contains(value.ToLower()))
            {
                return new Token(t.input.Position, t.input.LineNumber,
                TokenType.PenStyle, value);
            }
            else
            {
                return new Token(t.input.Position, t.input.LineNumber,
                TokenType.UnexpectedToken, value);
            }
                //throw new Exception("Unexpected token");
        }
    }
}
