using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using DrawingEngine.Tokenization;
using DrawingEngine.Tokenization.Handlers;
using System.Drawing.Drawing2D;

namespace DrawingEngine
{
    enum ShapeType
    {
        Line,
        Circle,
        Rectangle
    }
    public partial class drawingEngine : Form
    {
        /// <summary>
        /// Program fields
        /// </summary>

        private string shapeName = "line";
        private bool solidStyle = true;
        private bool drawMood = true;
        private int fontSize = 7;
        private bool isDrawing = false;
        private Shape currentShape = null;
        private int currentShapeIndex = -1;
        private int selectedShapeIndex = -1;
        private bool resizeLeft = false;
        private bool resizeRight = false;
        private bool resizeTop = false;
        private bool resizeBottom = false;
        private Point delta;
        private bool isClicked = false;
        private List<Shape> shapes = new List<Shape> { };
        Pen pen;
        OpenFileDialog fileDialog = new OpenFileDialog();
        string line = "";
        StringBuilder sb = new StringBuilder();
        Parser parser;
        /// <summary>
        /// Shape Class and it's childredn
        /// </summary>
        public abstract class Shape
        {
            public Point start;
            public Point end;
            public Pen pen;
            public string type;
            public int width;
            public int height;
            public Rectangle center, top, left, right, bottom;

            public abstract void draw(PaintEventArgs e);
            public abstract void drawBoundaries(PaintEventArgs e);

            public abstract bool checkSelectedShape(MouseEventArgs e);

            public bool checkSelectedSBoundry(MouseEventArgs e, Rectangle boundry)
            {
                Rectangle area = new Rectangle(e.Location.X, e.Location.Y, 10, 10);
                return boundry.IntersectsWith(area);
            }



        }

        public class Circle : Shape
        {
            public Circle()
            {
                this.type = "circle";
            }
            public override void draw(PaintEventArgs e)
            {

                e.Graphics.DrawEllipse(this.pen, new Rectangle(this.start.X, this.start.Y, this.width, this.height));
                this.center = new Rectangle(this.start.X + (this.width - 20) / 2, this.start.Y + (this.height - 20) / 2, 20, 20);
                this.top = new Rectangle(this.start.X + (this.width - 20) / 2, this.start.Y - 10, 20, 20);
                this.left = new Rectangle(this.start.X - 10, this.start.Y + (this.height - 20) / 2, 20, 20);
                this.bottom = new Rectangle(((this.start.X - 10) + this.width / 2), (this.start.Y + this.height) - 10, 20, 20);
                this.right = new Rectangle((this.start.X + this.width - 10), (this.start.Y - 10) + this.height / 2, 20, 20);
            }
            public override void drawBoundaries(PaintEventArgs e)
            {
                e.Graphics.FillEllipse(new SolidBrush(Color.Red), this.center);
                e.Graphics.FillEllipse(new SolidBrush(Color.Red), this.top);
                e.Graphics.FillEllipse(new SolidBrush(Color.Red), this.left);
                e.Graphics.FillEllipse(new SolidBrush(Color.Red), this.right);
                e.Graphics.FillEllipse(new SolidBrush(Color.Red), this.bottom);
            }
            public override bool checkSelectedShape(MouseEventArgs e)
            {
                Rectangle rec = new Rectangle(this.start.X, this.start.Y, this.width, this.height);
                Rectangle area = new Rectangle(e.Location.X, e.Location.Y, 10, 10);
                return rec.IntersectsWith(area);
            }



        }

        public class LineShape : Shape
        {
            public LineShape()
            {
                this.type = "line";
            }
            public override void draw(PaintEventArgs e)
            {

                e.Graphics.DrawLine(this.pen, this.start, this.end);
                this.center = new Rectangle(((this.start.X + this.end.X) / 2) - 10, ((this.start.Y + this.end.Y) / 2) - 10, 20, 20);
                this.right = new Rectangle(this.end.X - 10, this.end.Y - 10, 20, 20);
                this.left = new Rectangle(this.start.X - 10, this.start.Y - 10, 20, 20);
            }
            public override void drawBoundaries(PaintEventArgs e)
            {
                e.Graphics.FillEllipse(new SolidBrush(Color.Red), this.center);
                e.Graphics.FillEllipse(new SolidBrush(Color.Red), this.left);
                e.Graphics.FillEllipse(new SolidBrush(Color.Red), this.right);

            }

            public override bool checkSelectedShape(MouseEventArgs e)
            {

                GraphicsPath linePath = new GraphicsPath();
                linePath.AddLine(this.start, this.end);
                return linePath.GetBounds().Contains(e.Location.X, e.Location.Y);

            }


        }

        public class RectShape : Shape
        {
            public RectShape()
            {
                this.type = "rectangle";
            }
            public override void draw(PaintEventArgs e)
            {

                e.Graphics.DrawRectangle(this.pen, new Rectangle(this.start.X, this.start.Y, this.width, this.height));
                this.center = new Rectangle(this.start.X + (this.width - 20) / 2, this.start.Y + (this.height - 20) / 2, 20, 20);
                this.top = new Rectangle(this.start.X + (this.width - 20) / 2, this.start.Y - 10, 20, 20);
                this.left = new Rectangle(this.start.X - 10, this.start.Y + (this.height - 20) / 2, 20, 20);
                this.bottom = new Rectangle(((this.start.X - 10) + this.width / 2), (this.start.Y + this.height) - 10, 20, 20);
                this.right = new Rectangle((this.start.X + this.width - 10), (this.start.Y - 10) + this.height / 2, 20, 20);
            }

            public override void drawBoundaries(PaintEventArgs e)
            {
                e.Graphics.FillEllipse(new SolidBrush(Color.Red), this.center);
                e.Graphics.FillEllipse(new SolidBrush(Color.Red), this.top);
                e.Graphics.FillEllipse(new SolidBrush(Color.Red), this.left);
                e.Graphics.FillEllipse(new SolidBrush(Color.Red), this.right);
                e.Graphics.FillEllipse(new SolidBrush(Color.Red), this.bottom);
            }

            public override bool checkSelectedShape(MouseEventArgs e)
            {
                Rectangle rec = new Rectangle(this.start.X, this.start.Y, this.width, this.height);
                Rectangle area = new Rectangle(e.Location.X, e.Location.Y, 10, 10);
                return rec.IntersectsWith(area);
            }


        }


        public drawingEngine()
        {
            InitializeComponent();
            this.pen = new Pen(Color.Black, this.fontSize);
            tabs.SelectTab("designTab");
        }

     

    


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void openButton_Click(object sender, EventArgs e)
        {
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = new StreamReader(fileDialog.FileName);
                while (line != null)
                {
                    line = sr.ReadLine();
                    if (line != null)
                    {
                        sourceTextbox.AppendText("\r\n" + line);
                        sourceTextbox.ScrollToCaret();
                    }

                }
                sr.Close();
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            fileDialog.Filter = "Text Files (.txt) | *.txt";
        }

        private void colorButton_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = colorDialog1.ShowDialog();
            Color pickedColor = colorDialog1.Color;
            if (dialogResult == DialogResult.OK)
            {
                this.pen.Color = colorDialog1.Color;
                if (this.selectedShapeIndex != -1)
                {
                    this.shapes[this.selectedShapeIndex].pen = (Pen)this.pen.Clone();
                    this.Refresh();
                }
            }
        }

        private void CircleButton_Click(object sender, EventArgs e)
        {
            this.shapeName = "circle";
        }

        private void lineButton_Click(object sender, EventArgs e)
        {
            this.shapeName = "line";
        }

        private void RectangleButton_Click(object sender, EventArgs e)
        {
            this.shapeName = "rectangle";
        }

        private void handButton_Click(object sender, EventArgs e)
        {
            if (this.drawMood) //select mood
            {
                this.drawMood = false;
                this.selectedShapeIndex = -1;

            } 
        }

        private void drawButton_Click(object sender, EventArgs e)
        {
            if (!this.drawMood) this.drawMood = true; //draw mood
        }

        private void dashedButton_Click(object sender, EventArgs e)
        {
            if (this.solidStyle)
            {
                this.pen.DashStyle = DashStyle.Dash;
                this.solidStyle = !this.solidStyle; //dashed
                if (this.selectedShapeIndex != -1)
                {
                    this.shapes[this.selectedShapeIndex].pen = (Pen)this.pen.Clone();
                    this.Refresh();
                }
            }
        }

        private void notDashedButton_Click(object sender, EventArgs e)
        {
            if (!this.solidStyle)
            {
                this.pen.DashStyle = DashStyle.Solid;
                this.solidStyle = !this.solidStyle; //solid
                if (this.selectedShapeIndex != -1)
                {
                    this.shapes[this.selectedShapeIndex].pen = (Pen)this.pen.Clone();
                    this.Refresh();
                }
            }
        }

        private void sizePicker_ValueChanged(object sender, EventArgs e)
        {
            this.fontSize = Convert.ToInt32(Math.Round(sizePicker.Value, 0)); //get the size
            this.pen.Width = this.fontSize;
            if (this.selectedShapeIndex != -1)
            {
                this.shapes[this.selectedShapeIndex].pen = (Pen)this.pen.Clone();
                this.Refresh();
            }
        }

        private void designPanel_MouseClick(object sender, MouseEventArgs e)
        {
            if (!this.drawMood)
            {
                foreach (var shape in shapes)
                {


                    if (shape.checkSelectedShape(e))
                    {
                        this.selectedShapeIndex = this.shapes.IndexOf(shape);
                        break;
                    }
                    else
                    {
                        this.selectedShapeIndex = -1;

                    }


                }
                this.Refresh();
            }


        }

        private void designPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.drawMood)
            {
                this.isDrawing = !this.isDrawing; //true


                switch (this.shapeName)
                {
                    case "line":
                        this.currentShape = new LineShape();
                        this.currentShape.type = this.shapeName;
                        break;
                    case "rectangle":
                        this.currentShape = new RectShape();
                        this.currentShape.type = this.shapeName;
                        break;
                    case "circle":
                        this.currentShape = new Circle();
                        this.currentShape.type = this.shapeName;
                        break;
                }
                this.currentShape.start = e.Location;
                this.currentShape.end = e.Location;
                this.currentShape.pen = (Pen)this.pen.Clone();

            }
            else
            {
                if (this.selectedShapeIndex != -1)
                {
                    if (this.shapes[selectedShapeIndex].checkSelectedShape(e))
                    {
                        Debug.WriteLine(selectedShapeIndex);
                        Debug.WriteLine(this.shapes.Count);
                        if (!this.shapes[selectedShapeIndex].type.Equals("line"))
                        {
                            if (this.shapes[selectedShapeIndex].checkSelectedSBoundry(e, this.shapes[selectedShapeIndex].left))
                            {
                                this.resizeLeft = true;
                            }
                            else if (this.shapes[selectedShapeIndex].checkSelectedSBoundry(e, this.shapes[selectedShapeIndex].top))
                            {
                                this.resizeTop = true;
                            }
                            else if (this.shapes[selectedShapeIndex].checkSelectedSBoundry(e, this.shapes[selectedShapeIndex].right))
                            {
                                this.resizeRight = true;
                            }
                            else if (this.shapes[selectedShapeIndex].checkSelectedSBoundry(e, this.shapes[selectedShapeIndex].bottom))
                            {
                                this.resizeBottom = true;
                            }

                        }
                        else
                        {
                            if (this.shapes[selectedShapeIndex].checkSelectedSBoundry(e, this.shapes[selectedShapeIndex].left))
                            {
                                this.resizeLeft = true;
                            }
                            else if (this.shapes[selectedShapeIndex].checkSelectedSBoundry(e, this.shapes[selectedShapeIndex].right))
                            {
                                this.resizeRight = true;
                            }

                        }


                        this.delta = e.Location;
                        this.delta.X = e.X - this.shapes[selectedShapeIndex].start.X;
                        this.delta.Y = e.Y - this.shapes[selectedShapeIndex].start.Y;
                        this.isClicked = true;

                    }
                    else
                    {
                        this.selectedShapeIndex = -1;
                    }

                    this.Refresh();
                }


            }



        }

        private void designPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.isDrawing && this.drawMood)
            {

                if (this.currentShapeIndex == -1)
                { // throws null exception
                    this.currentShape.end = e.Location;  //get the current location 
                    if (!this.currentShape.type.Equals("line"))
                    {
                        this.currentShape.width = this.currentShape.end.X - this.currentShape.start.X;
                        this.currentShape.height = this.currentShape.end.Y - this.currentShape.start.Y;
                    }
                    // add shape to src code then update shapes list with  list from src code
                    this.shapes.Add(this.currentShape);
                    this.currentShapeIndex = this.shapes.IndexOf(this.currentShape);

                    Debug.WriteLine(this.currentShapeIndex);
                }
                else
                {
                    this.shapes[currentShapeIndex].end = e.Location;
                    if (!this.shapes[currentShapeIndex].type.Equals("line"))
                    {
                        this.shapes[currentShapeIndex].width = this.shapes[currentShapeIndex].end.X - this.shapes[currentShapeIndex].start.X;
                        this.shapes[currentShapeIndex].height = this.shapes[currentShapeIndex].end.Y - this.shapes[currentShapeIndex].start.Y;
                    }
                }
                Refresh(); // refresh the form
            }
            else if (!this.drawMood)
            {
                if (this.selectedShapeIndex != -1 && this.isClicked)
                {
                    if (this.resizeRight)
                    {
                        if (!this.shapes[selectedShapeIndex].type.Equals("line"))
                        {
                            this.shapes[selectedShapeIndex].width = e.Location.X - this.shapes[selectedShapeIndex].start.X;
                        }

                        else
                        {
                            this.shapes[selectedShapeIndex].end.X = e.Location.X;
                            this.shapes[selectedShapeIndex].end.Y = e.Location.Y;
                        }

                    }
                    else if (this.resizeLeft)
                    {
                        if (!this.shapes[selectedShapeIndex].type.Equals("line"))
                        {
                            this.shapes[selectedShapeIndex].width -= e.Location.X - this.shapes[selectedShapeIndex].start.X;
                            this.shapes[selectedShapeIndex].start.X = e.Location.X;
                        }
                        else
                        {
                            this.shapes[selectedShapeIndex].start.X = e.Location.X;
                            this.shapes[selectedShapeIndex].start.Y = e.Location.Y;
                            this.delta = e.Location;
                            this.delta.X = e.X - this.shapes[selectedShapeIndex].start.X;
                            this.delta.Y = e.Y - this.shapes[selectedShapeIndex].start.Y;

                        }

                    }
                    else if (this.resizeTop)
                    {
                        this.shapes[selectedShapeIndex].height -= e.Location.Y - this.shapes[selectedShapeIndex].start.Y;
                        this.shapes[selectedShapeIndex].start.Y = e.Location.Y;

                    }
                    else if (this.resizeBottom)
                    {
                        this.shapes[selectedShapeIndex].height = e.Location.Y - this.shapes[selectedShapeIndex].start.Y;

                    }
                    else
                    {
                        this.shapes[selectedShapeIndex].start.X = e.Location.X - this.delta.X;
                        this.shapes[selectedShapeIndex].start.Y = e.Location.Y - this.delta.Y;
                        if (this.shapes[selectedShapeIndex].type.Equals("line"))
                        {
                            this.shapes[selectedShapeIndex].end.X = e.Location.X + this.delta.X;
                            this.shapes[selectedShapeIndex].end.Y = e.Location.Y + this.delta.Y;
                        }

                    }
                    Refresh(); // refresh the form
                }
            }
           


        }

        private void designPanel_MouseUp(object sender, MouseEventArgs e)
        {
            if (this.isDrawing && this.drawMood)
            {
                if (this.currentShapeIndex != -1)
                {
                    this.isDrawing = !this.isDrawing; //make it false and wait for new point entry
                    this.shapes[currentShapeIndex].end = e.Location; // get the ending location of x and y 
                    if (!this.shapes[currentShapeIndex].type.Equals("line"))
                    {
                        this.shapes[currentShapeIndex].width = this.shapes[currentShapeIndex].end.X - this.shapes[currentShapeIndex].start.X;
                        this.shapes[currentShapeIndex].height = this.shapes[currentShapeIndex].end.Y - this.shapes[currentShapeIndex].start.Y;
                    }
                    this.shapes[currentShapeIndex].pen = (Pen)this.pen.Clone();
                    this.currentShapeIndex = -1;
                    this.currentShape = null;
                    // remove current shape from list
                    // get new list 
                    Refresh();

                }


            }
            else
            {
                if (this.isClicked)
                {
                    this.selectedShapeIndex = -1;
                    this.resizeRight = false;
                    this.resizeLeft = false;
                    this.resizeBottom = false;
                    this.resizeTop = false;
                    this.isClicked = false;
                    Refresh();
                }
            }
            


        }

        private void designPanel_Paint(object sender, PaintEventArgs e)
        {
            foreach (var shape in shapes)
            {
                shape.draw(e);
            }
            if (this.selectedShapeIndex != -1)
            {
                this.shapes[this.selectedShapeIndex].drawBoundaries(e);
            }
        }


        private void sourceTextbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                sb.Clear();
                sb.Append(sourceTextbox.Text);



                //tokenize sb
                parser = new Parser();
                this.shapes = parser.ParseSourceCode(sb.ToString());
                foreach (var shape in shapes)
                {
                    Debug.WriteLine($"shape: {shape.type} x: {shape.start.X} y: {shape.start.Y} w: {shape.width} h: {shape.height} color: {shape.pen.Color.Name}");
                }
            //    Tokenizer t = new Tokenizer(new Input(sb.ToString()), new Tokenizable[]
            //{
            //            //new ShapeHandler(),
            //            new ColorHandler(),
            //            new StringTokenizer(),
            //            new WhiteSpaceHandler(),
            //            new SpecialCharacterHandler(),
            //            new NumberHandler()


            //    });

            //    Token token = t.tokenize();
            //    while (token != null)
            //    {
            //        Debug.WriteLine($"value: {token.Value}        type: {token.Type}");
            //        token = t.tokenize();
            //    }
                //    Tokenizer t = new Tokenizer(new Input(sb.ToString()), new Tokenizable[]
                //{
                //    //new ShapeHandler(),
                //    new ColorHandler(),
                //    new StringTokenizer(),
                //    new WhiteSpaceHandler(),
                //    new SpecialCharacterHandler(),
                //    new NumberHandler()

                //});
                ////parser = new Parser(t);
                //Shape s = parser.ParseLine();
                //Debug.WriteLine(s.start.X);
                //Debug.WriteLine(s.start.Y);
                //Debug.WriteLine(s.height);
                //Debug.WriteLine(s.width);
                //Debug.WriteLine(s.pen.Color.Name);
                Debug.WriteLine("----------------------------------------");
            }
        }

        private void sourceTextbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void clear_Button_Click(object sender, EventArgs e)
        {
            shapes = new List<Shape> { };
            this.currentShapeIndex = -1;
            this.currentShape = null;
            this.selectedShapeIndex = -1;
            this.resizeRight = false;
            this.resizeLeft = false;
            this.resizeBottom = false;
            this.resizeTop = false;
            this.isClicked = false;
            this.Refresh();
                
                
            }
        }

}
