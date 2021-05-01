using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingEngine.Tokenization.Handlers
{
    class ColorHandler : Tokenizable
    {

        public override bool tokenizable(Tokenizer t)
        { // ff004040 valid
            char currentCharacter = t.input.peek();
            char nextCharacter = t.input.peek(2);
            return (currentCharacter == 'f' && nextCharacter == 'f'
                || currentCharacter == 'F' && nextCharacter == 'F');
        }

        static bool IsValidHex(Input input)
        {
            string hex = "1234567890abcdefABCDEF";
            return hex.Contains(input.peek());
        }

        public override Token tokenize(Tokenizer t)
        {
            string value = t.input.loop(IsValidHex);

            if (value.Length != 8)
            {
                return new Token(t.input.Position, t.input.LineNumber,
                    TokenType.UnexpectedToken, value);
            }

                return new Token(t.input.Position, t.input.LineNumber,
                        TokenType.RGBColor, value);

            //throw new Exception("Unexpected token");
        }
    }
}
