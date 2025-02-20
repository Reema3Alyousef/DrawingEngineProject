﻿using System;
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
            return Char.IsWhiteSpace(t.input.peek());
        }

        static bool IsSpace(Input input)
        {
            return Char.IsWhiteSpace(input.peek());
        }

        public override Token tokenize(Tokenizer t)
        {
            string value = t.input.loop(IsSpace);
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
