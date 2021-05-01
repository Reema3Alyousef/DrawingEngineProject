using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingEngine.Tokenization.Handlers
{
    class SpecialCharacterHandler : Tokenizable
    {
        public override bool tokenizable(Tokenizer t)
        {
            return t.input.peek() == ',';
        }

        public override Token tokenize(Tokenizer t)
        {
            char value = t.input.step().Character;
            if (value == ',')
            {


                return new Token(t.input.Position, t.input.LineNumber,
                    TokenType.Comma, value + "");
            }
            throw new Exception($"Unexpected Token");
        }
    }
}
