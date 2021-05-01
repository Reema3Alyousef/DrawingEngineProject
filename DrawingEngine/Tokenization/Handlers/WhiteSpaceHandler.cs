using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingEngine.Tokenization.Handlers
{
    public class WhiteSpaceHandler : Tokenizable
    {
        public override bool tokenizable(Tokenizer t)
        {
            char currentCharacter = t.input.peek();
            return Char.IsWhiteSpace(currentCharacter);
        }

        // rect 10,10,100,100

        static bool IsSpace(Input input)
        {
            char currentCharacter = input.peek();
            return Char.IsWhiteSpace(currentCharacter);
        }

        public override Token tokenize(Tokenizer t)
        {
            string value = t.input.loop(IsSpace);
            Debug.WriteLine(Environment.NewLine);
            //value.Equals(Environment.NewLine)
            if (value.Equals("\n"))
            {
                return new Token(t.input.Position, t.input.LineNumber,
                TokenType.NewLine, value);
            } else
            {
                return new Token(t.input.Position, t.input.LineNumber,
                TokenType.Whitespace, value);
            }
        }
    }
}
