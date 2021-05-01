using DrawingEngine.Tokenization.Handlers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DrawingEngine.drawingEngine;

namespace DrawingEngine.Tokenization
{
    class Parser
    {
        private Tokenizer tokenizer;
        private List<Shape> shapes;
        public Parser()
        {
            
            this.shapes = new List<Shape>() { };
        }

        public List<Shape> ParseSourceCode(string sourceCode)
        {
            this.tokenizer = new Tokenizer(new Input(sourceCode), new Tokenizable[]
            {
                //new ShapeHandler(),
                new ColorHandler(),
                new StringTokenizer(),
                new WhiteSpaceHandler(),
                new SpecialCharacterHandler(),
                new NumberHandler()

            });
            Token token = tokenizer.tokenize();
            Shape shape = null;
            List<int> xywh = new List<int>();
            Color color = Color.Black;
            DashStyle penStyle = DashStyle.Solid;
            int lineWidth = 2;
            Debug.WriteLine(" befor loop "  + token.Value);
            while (token != null)
            {
                Debug.WriteLine(token.Value);
                //Debug.WriteLine($"value: {token.Value}        type: {token.Type}");
                if (token != null && token.Type != TokenType.NewLine)
                { 
                    switch (token.Type)
                    {
                        case TokenType.Shape:
                            if (token.Value == "rect")
                            {
                                shape = new RectShape();
                            }
                            else if (token.Value == "cir")
                            {
                                shape = new Circle();
                            }
                            else
                            {
                                shape = new LineShape();
                            }
                            break;
                        case TokenType.Number:
                            if (xywh.Count <= 4)
                            {
                                xywh.Add(int.Parse(token.Value));
                            }
                            else
                            {
                                lineWidth = int.Parse(token.Value);
                            }
                            break;
                        case TokenType.RGBColor:
                            color = getColor(token);
                            break;
                        case TokenType.NamedColor:
                            color = getColor(token);

                            break;
                        case TokenType.PenStyle:
                            penStyle = getPenStyle(token);
                            break;
                        case TokenType.UnexpectedToken:
                            break;
                        case TokenType.Whitespace:
                            break;
                        case TokenType.Comma:
                            break;
                        case TokenType.None:
                            break;
                        default:
                            break;
                    }
                    token = tokenizer.tokenize();
                }
                if (token != null && shape != null && token.Type == TokenType.NewLine)
                {
                    shape.start.X = xywh[0];
                    shape.start.Y = xywh[1];
                    shape.width = xywh[2];
                    shape.height = xywh[3];
                    shape.pen = new Pen(color);
                    shape.pen.Width = lineWidth;
                    shape.pen.DashStyle = penStyle;
                    shapes.Add(shape);
                    shape = null;
                    xywh = new List<int>();
                }
                token = tokenizer.tokenize();
            }
            //Debug.WriteLine("----------------------------------------");
            return this.shapes;
        }

        public Shape ParseLine()
        {
            Token token = tokenizer.tokenize();
            Shape shape = null;
            List<int> xywh = new List<int>();
            Color color = Color.Black;
            DashStyle penStyle = DashStyle.Solid;
            int lineWidth = 2;
            while (token != null)
            {
                //Debug.WriteLine($"value: {token.Value}        type: {token.Type}");
                switch (token.Type)
                {
                    case TokenType.Shape:
                        if (token.Value == "rect")
                        {
                            shape = new RectShape();
                        }
                        else if (token.Value == "cir")
                        {
                            shape = new Circle();
                        }
                        else
                        {
                            shape = new LineShape();
                        }
                        break;
                    case TokenType.Number:
                        if (xywh.Count <= 4)
                        {
                            xywh.Add(int.Parse(token.Value));
                        }
                        else
                        {
                            lineWidth = int.Parse(token.Value);
                        }
                        break;
                    case TokenType.RGBColor:
                        color = getColor(token);
                        break;
                    case TokenType.NamedColor:
                        color = getColor(token);

                        break;
                    case TokenType.PenStyle:
                        penStyle = getPenStyle(token);
                        break;
                    case TokenType.UnexpectedToken:
                        break;
                    case TokenType.Whitespace:
                        break;
                    case TokenType.Comma:
                        break;
                    case TokenType.None:
                        break;
                    default:
                        break;
                }
                token = tokenizer.tokenize();
            }
            if (shape != null)
            {
                shape.start.X = xywh[0];
                shape.start.Y = xywh[1];
                shape.width = xywh[2];
                shape.height = xywh[3];
                shape.pen = new Pen(color);
                shape.pen.Width = lineWidth;
                shape.pen.DashStyle = penStyle;
                return shape;
            }

            //Debug.WriteLine("----------------------------------------");
            return null;
        }

        public static Color getColor(Token token)
        {
            if (token.Type == TokenType.RGBColor)
            {
                int r = Convert.ToInt32(token.Value.Substring(2, 2), 16);
                int g = Convert.ToInt32(token.Value.Substring(4, 2), 16);
                int b = Convert.ToInt32(token.Value.Substring(6, 2), 16);
                Debug.WriteLine($"r: {r}  g: {g}  b: {b}");
                return Color.FromArgb(r, g, b);
            } else
            {
                return Color.FromName(token.Value);
            }
        }

        public static DashStyle getPenStyle(Token token)
        {
            if (token.Value == "dotted")
            {
                return System.Drawing.Drawing2D.DashStyle.Dot;
            }
            else if (token.Value == "dashed")
            {
                return System.Drawing.Drawing2D.DashStyle.Dash;
            } else
            {
                return System.Drawing.Drawing2D.DashStyle.Solid;
            }
        }
    }
}
