using DrawingEngine.Tokenization.Handlers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
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
                new ColorHandler(),
                new StringTokenizer(),
                new WhiteSpaceHandler(),
                new SpecialCharacterHandler(),
                new NumberHandler()
            });
            Token token = tokenizer.tokenize();
            Shape shape = null;
            List<int> coordinates = new List<int>();
            Color color = Color.Black;
            DashStyle penStyle = DashStyle.Solid;
            int lineWidth = 2;
            while (token != null)
            {
                if (token.Type == TokenType.Shape)
                {
                    if (token.Value == "rect")
                    {
                        shape = new RectShape();
                    }
                    else if (token.Value == "cir")
                    {
                        shape = new Circle();
                    }
                    else if (token.Value == "line")
                    {
                        shape = new LineShape();
                    }
                }
                if (shape != null && token.Type == TokenType.Number)
                {
                    if (coordinates.Count < 4)
                    {
                        coordinates.Add(int.Parse(token.Value));
                    }
                    else
                    {
                        lineWidth = int.Parse(token.Value);
                    }
                }
                if (token.Type == TokenType.RGBColor || token.Type == TokenType.NamedColor)
                {
                    color = getColor(token);
                }
                if (token.Type == TokenType.UnexpectedToken)
                {
                    System.Windows.Forms.MessageBox.Show($"Unexpected Token at position {token.Position} line {token.LineNumber}");
                }

                if (shape != null && token.Type == TokenType.NewLine)
                {
                    shape.start.X = coordinates[0];
                    shape.start.Y = coordinates[1];
                    if (shape.type == "line")
                    {
                        shape.end.X = coordinates[2];
                        shape.start.Y = coordinates[3];
                    }
                    else
                    {
                        shape.width = coordinates[2];
                        shape.height = coordinates[3];
                    }

                    shape.pen = new Pen(color);
                    shape.pen.Width = lineWidth;
                    shape.pen.DashStyle = penStyle;
                    //Debug.WriteLine($"shape: {shape.type} x: {shape.start.X} y: {shape.start.Y} w: {shape.width} h: {shape.height} color: {shape.pen.Color.Name}");

                    shapes.Add(shape);
                    shape = null;
                    coordinates = new List<int>();
                }

                token = tokenizer.tokenize();

            }
            return this.shapes;
        }
        public StringBuilder getSourceCode(List<Shape> shapesList)
        {

            StringBuilder sb = new StringBuilder();

            foreach (var shape in shapesList)
            {
                if (shape.type == "line")
                    sb.AppendLine($"{shape.type} {shape.start.X}, {shape.start.Y}, {shape.end.X}, {shape.end.Y} {shape.pen.Color.Name} {shape.pen.DashStyle.ToString().ToLower()}");
                else
                    sb.AppendLine($"{shape.type} {shape.start.X}, {shape.start.Y}, {shape.width}, {shape.height} {shape.pen.Color.Name} {shape.pen.DashStyle.ToString().ToLower()}");
            }
            return sb;
        }

        public static Color getColor(Token token)
        {
            if (token.Type == TokenType.RGBColor)
            {
                int r = Convert.ToInt32(token.Value.Substring(2, 2), 16);
                int g = Convert.ToInt32(token.Value.Substring(4, 2), 16);
                int b = Convert.ToInt32(token.Value.Substring(6, 2), 16);
                return Color.FromArgb(r, g, b);
            }
            else
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
            }
            else
            {
                return System.Drawing.Drawing2D.DashStyle.Solid;
            }
        }

    }
}
