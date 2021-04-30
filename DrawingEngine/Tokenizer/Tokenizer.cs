﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingEngine.Tokenizer
{
    public delegate bool InputCondition(Input input);
    public class Input
    {
        private readonly string input;
        private readonly int length;
        private int position;
        private int lineNumber;
        public int Length
        {
            get
            {
                return length;
            }
        }
        public int Position
        {
            get
            {
                return position;
            }
        }
        public int NextPosition
        {
            get
            {
                return position + 1;
            }
        }
        public int LineNumber
        {
            get
            {
                return lineNumber;
            }
        }
        public char Character
        {
            get
            {
                if (position > -1) return input[position];
                return '\0';
            }
        }
        public Input(string input)
        {
            this.input = input;
            length = input.Length;
            position = -1;
            lineNumber = 1;
        }
        public bool hasMore(int numOfSteps = 1)
        {
            if (numOfSteps <= 0) throw new Exception("Invalid number of steps");
            return (position + numOfSteps) < length;
        }
        public bool hasLess(int numOfSteps = 1)
        {
            if (numOfSteps <= 0) throw new Exception("Invalid number of steps");
            return (position - numOfSteps) > -1;
        }
        public Input step(int numOfSteps = 1)
        {
            if (hasMore(numOfSteps))
                position += numOfSteps;
            else
            {
                throw new Exception("There is no more step");
            }
            return this;
        }
        public Input back(int numOfSteps = 1)
        {
            if (hasLess(numOfSteps))
                position -= numOfSteps;
            else
            {
                throw new Exception("There is no more step");
            }
            return this;
        }
        public char peek(int numOfSteps = 1)
        {
            if (hasMore(numOfSteps)) return input[Position + numOfSteps];
            return '\0';
        }

        public char peekBack(int numOfSteps = 1)
        {
            if (hasLess(numOfSteps))
            {
                return input[Position + 1 - numOfSteps];
            }

            return '\0';
        }
        public string loop(InputCondition condition)
        {
            string buffer = "";
            while (hasMore() && condition(this))
                buffer += step().Character;
            return buffer;
        }
    }
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
        Color,
        PenStyle,
        PenWidth,
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
