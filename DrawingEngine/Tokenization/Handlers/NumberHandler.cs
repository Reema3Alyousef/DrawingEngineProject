using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingEngine.Tokenization.Handlers
{
    public class NumberHandler : Tokenizable
    {
        public override bool tokenizable(Tokenizer t)
        {
            char currentCharacter = t.input.peek();
            char nextCharacter = t.input.peek(2);
            return Char.IsDigit(currentCharacter) ||
                   (currentCharacter == '-' && Char.IsDigit(nextCharacter));
        }

        public override Token tokenize(Tokenizer t)
        {
            InputCondition[] inputConditions = { IsDigit, IsNegative };
            Token token = new Token(t.input.Position, t.input.LineNumber, TokenType.Number, "");
            int i = 0;
            while (i < t.input.Length)
            {
                foreach (var condition in inputConditions)
                {
                    token.Value += t.input.loop(condition);
                }
                i++;
            }

            return token;
        }

        static bool IsOneNineDigit(char character)
        {
            return (character >= '1' && character <= '9');
        }

        static bool IsDigit(Input input)
        {
            return Char.IsDigit(input.peek());
        }

        static bool IsNegative(Input input)
        {
            return input.peek() == '-' && Char.IsDigit(input.peek(2));
        }
    }
}
