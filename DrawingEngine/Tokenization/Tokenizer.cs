using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingEngine.Tokenization
{
    
    public class Token
    {
        public int Position { set; get; }
        public int LineNumber { set; get; }
        public TokenType Type { set; get; }
        public string Value { set; get; }
        public Token(int position, int lineNumber, TokenType type, string value)
        {
            Position = position;
            LineNumber = lineNumber;
            Type = type;
            Value = value;
        }
    }

    public enum TokenType
    {
        Shape,
        Number,
        RGBColor,
        NamedColor,
        PenStyle,
        PenWidth,
        NewLine,
        UnexpectedToken,
        Whitespace,
        Comma,
        None
    }

    public abstract class Tokenizable
    {
        public abstract bool tokenizable(Tokenizer tokenizer);
        public abstract Token tokenize(Tokenizer tokenizer);
    }
    public class Tokenizer
    {
        public Input input;
        public Tokenizable[] handlers;
        public Tokenizer(string source, Tokenizable[] handlers)
        {
            input = new Input(source);
            this.handlers = handlers;
        }
        public Tokenizer(Input source, Tokenizable[] handlers)
        {
            input = source;
            this.handlers = handlers;
        }
        public Token tokenize()
        {

            foreach (var handler in handlers)
                if (handler.tokenizable(this)) return handler.tokenize(this);
            return null;
        }
    }
}
