using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingEngine.Tokenization.Handlers
{
    public class ShapeHandler : Tokenizable
    {
        private List<string> keywords;

        public ShapeHandler()
        {
            this.keywords = new List<string> { "rect", "cir", "line" };
        }

        public override bool tokenizable(Tokenizer t)
        {
            return isLetter(t.input);
        }

        static bool isLetter(Input input)
        {
            char currentCharacter = input.peek();
            return Char.IsLetter(currentCharacter);
        }

        public override Token tokenize(Tokenizer t)
        {
            string value = t.input.loop(isLetter);
            string type = "shape";
            if (!this.keywords.Contains(value))
                throw new Exception("Unexpected token");
            return new Token(t.input.Position, t.input.LineNumber,
                TokenType.Shape, value);
        }

    }
}
