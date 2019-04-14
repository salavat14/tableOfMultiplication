using System;
using System.Drawing;
using System.Windows.Forms;

namespace tableOfMultiplication
{
    public partial class Form1 : Form
    {
        Bitmap bitmap;
        int qualOfCell = 10; //количество клеток на битмапе

        public Form1()
        {
            InitializeComponent();
            bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            DrawGrid();
        }

        public void DrawGrid()
        {
            Graphics gr = Graphics.FromImage(bitmap);
            int widthOfCell = (pictureBox1.Width / qualOfCell);
            int heightOfCell = (pictureBox1.Height / qualOfCell);

            DrawLines(gr, heightOfCell, widthOfCell);
            WriteDigits(gr, widthOfCell, heightOfCell);

            pictureBox1.Image = bitmap;
        }

        public void DrawLines(Graphics gr, int stepX, int stepY)
        {
            Pen pen = new Pen(Color.Black, 1);
            Pen boldPen = new Pen(Color.Black, 3);
            for (int i = 2; i < qualOfCell; i++)
            {
                gr.DrawLine(pen, stepX * i, 0, stepX * i, pictureBox1.Height);
                gr.DrawLine(pen, 0, stepY * i, pictureBox1.Width, stepY * i);
            }
            gr.DrawLine(boldPen, stepX, 0, stepX, pictureBox1.Height);
            gr.DrawLine(boldPen, 0, stepY, pictureBox1.Width, stepY);
        }

        public void WriteDigits(Graphics gr, int stepX, int stepY)
        {
            for (int i = 1; i < qualOfCell; i++)
            {
                gr.DrawString(i.ToString(), new Font("Arial", 20), Brushes.Black, stepX * i + 10, stepY / 8); //(самая верхняя строчка) 10 и 8- рандомное число, чтобы цифра нахлдилась по центру
                gr.DrawString(i.ToString(), new Font("Arial", 20), Brushes.Black, stepX / 7, stepY * i + 5); //(самый левый столбец) 5 и 7 - рандомные числа, чтобы цифра находилась по центру
                for(int j = 1; j < qualOfCell; j++)
                {
                    gr.DrawString((i*j).ToString(), new Font("Arial", 18), Brushes.Black, stepX * i + 5, stepY * j + 8);
                }
            }

        }
    }
}
