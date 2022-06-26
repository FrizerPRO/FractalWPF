using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Fractal
{
    /// <summary>
    /// Родительский класс для фракталов.
    /// </summary>
    public class Fractal
    {
        /// <summary>
        /// Список цветов для градиента.
        /// </summary>
        protected List<Color> colorList = new List<Color>();
        /// <summary>
        /// ПО ссылке устанавливает плоскость для рисования.
        /// </summary>
        /// <param name="canvas">Плоскость для рисования.</param>
        public Fractal(Canvas canvas)
        {
            FractalCanvas = canvas;
        }
        /// <summary>
        /// Конструктор для градиента.
        /// </summary>
        /// <param name="canvas">Плоскость для рисования.</param>
        /// <param name="depth">Глубина прорисовки.</param>
        /// <param name="beginGrad">Начальный цвет градиента.</param>
        /// <param name="endGrad">Конечный цвет градиента.</param>
        internal Fractal(Canvas canvas, int depth, Color beginGrad, Color endGrad)
        {
            byte redMax = endGrad.R;
            byte redMin = beginGrad.R;
            byte greenMax = endGrad.G;
            byte greenMin = beginGrad.G;
            byte blueMax = endGrad.B;
            byte blueMin = beginGrad.B;
            maxDepth = 100;
            FractalCanvas = canvas;
            UserDepth = depth;
            for (int i = 0; i < UserDepth; i++)
            {
                byte rAverage = (byte)(redMin + (redMax - redMin) * i / depth);
                byte gAverage = (byte)(greenMin + (greenMax - greenMin) * i / depth);
                byte bAverage = (byte)(blueMin + (blueMax - blueMin) * i / depth);
                colorList.Add(Color.FromArgb(255, rAverage, gAverage, bAverage));
            }
        }

        /// <summary>
        /// Поле для поля для рисования.
        /// </summary>
        private Canvas fractalCanvas = new Canvas();

        /// <summary>
        /// Свойство поля для рисования.
        /// </summary>
        public Canvas FractalCanvas
        {
            get => fractalCanvas;
            set => fractalCanvas = value;
        }
        /// <summary>
        /// Виртуальный метод для построения фракталов.
        /// </summary>
        public virtual void BuildFrac()
        {

        }
        /// <summary>
        /// Максимальная глубина.
        /// </summary>
        private readonly int maxDepth = 15;
        /// <summary>
        /// Поле для пользовательской глубины фрактала.
        /// </summary>
        private int userDepth;
        /// <summary>
        /// Свойство для задания глубины фрактала.
        /// </summary>
        public int UserDepth
        {
            get => userDepth;
            protected set
            {
                userDepth = value;
            }
        }
    }
    /// <summary>
    /// Фрактальное дерево.
    /// </summary>
    public class TreeFrac : Fractal
    {
        /// <summary>
        /// Размер фрактала относительно размеров экрана.
        /// </summary>
        private readonly double size;
        /// <summary>
        /// Конструктор для всех параметров.
        /// </summary>
        /// <param name="canvas">Ссылка на плоскость для рисования.</param>
        /// <param name="depth">Глубина фрактала</param>
        /// <param name="angleFirst">Правый угол наклона.</param>
        /// <param name="angleSecond">Левый угол наклона.</param>
        /// <param name="nextSmaller">Во сколько раз следующий отрезок меньше предыдущего.</param>
        /// <param name="size">Относительный размер фрактала.</param>
        /// <param name="beginGrad">Цвет начала градиента.</param>
        /// <param name="endGrad">Цвет конца градиента.</param>
        public TreeFrac(Canvas canvas, int depth, double angleFirst, double angleSecond, double nextSmaller, double size, Color beginGrad, Color endGrad) : base(canvas, depth, beginGrad, endGrad)
        {
            AngleFirst = angleFirst;
            AngleSecond = angleSecond;
            NextSmaller = nextSmaller;
            this.size = size;
        }

        /// <summary>
        /// Поле во сколько раз следующий отрезок меньше предыдущего.
        /// </summary>
        private double nextSmaller;
        /// <summary>
        /// Свойство во сколько раз следующий отрезок меньше предыдущего.
        /// </summary>
        public double NextSmaller
        {
            get => nextSmaller;
            set
            {
                if (value > 8 || value < 1)
                {
                    nextSmaller = 1;
                    //throw new ArgumentException("Неправильное число\n(Нужно 1<=x<=8)");
                }
                nextSmaller = value;
            }
        }
        /// <summary>
        /// Поле Правый угол наклона.
        /// </summary>
        private double angleFirst;
        /// <summary>
        /// Свойство Правый угол наклона.
        /// </summary>
        public double AngleFirst
        {
            get => angleFirst;
            set
            {
                angleFirst = value;
            }
        }
        /// <summary>
        /// Поле Левый угол наклона.
        /// </summary>
        private double angleSecond;
        /// <summary>
        /// Свойство левый угол наклона.
        /// </summary>
        public double AngleSecond
        {
            get => angleSecond;
            set
            {
                angleSecond = value;
            }
        }
        /// <summary>
        /// Функция для рекурсии.
        /// </summary>
        /// <param name="x">Координата X.</param>
        /// <param name="y">Координата Y.</param>
        /// <param name="currentDepth">Текщая глубина.</param>
        /// <param name="angle1">Угол наклона.</param>
        private void Recurs(double x, double y, int currentDepth, double angle1)
        {
            Line myLineRight = new Line
            {
                X1 = x,
                Y1 = FractalCanvas.RenderSize.Height - y
            };
            Canvas.SetLeft(myLineRight, FractalCanvas.RenderSize.Width / 2);
            Canvas.SetTop(myLineRight, -30);
            double X2 = (x + size * Math.Sin(angle1 * Math.PI / 180) / Math.Pow(nextSmaller, currentDepth - 1));
            double Y2 = (y + size * Math.Cos(angle1 * Math.PI / 180) / Math.Pow(nextSmaller, currentDepth - 1));
            myLineRight.X2 = X2;
            myLineRight.Y2 = FractalCanvas.RenderSize.Height - Y2;
            myLineRight.StrokeThickness = 2;
            myLineRight.Stroke = new SolidColorBrush(colorList[currentDepth - 1]);
            FractalCanvas.Children.Add(myLineRight);
            if (currentDepth < UserDepth)
            {
                Recurs(X2, Y2, currentDepth + 1, angle1 + angleFirst);
                Recurs(X2, Y2, currentDepth + 1, angle1 - angleSecond);
            }
        }

        /// <summary>
        /// Построение фрактала.
        /// </summary>
        public override void BuildFrac()
        {
            Recurs(0.18 * FractalCanvas.ActualWidth, 0.015 * FractalCanvas.ActualWidth, 1, 0);
        }
    }
    public class KochLine : Fractal
    {
        private readonly double size = 100.0;
        /// <summary>
        /// Конструктор для всех параметров.
        /// </summary>
        /// <param name="canvas">Ссылка на плоскость для рисования.</param>
        /// <param name="depth">Глубина фрактала</param>
        /// <param name="size">Относительный размер фрактала.</param>
        /// <param name="beginGrad">Цвет начала градиента.</param>
        /// <param name="endGrad">Цвет конца градиента.</param>
        public KochLine(Canvas canvas, int depth, double size, Color beginGrad, Color endGrad) : base(canvas, depth, beginGrad, endGrad)
        {
            this.size = size / Math.Pow(3, UserDepth - 1);
        }
        /// <summary>
        /// Построение фрактала.
        /// </summary>
        public override void BuildFrac()
        {
            Recurs(0, 0, 1, 0, Math.Sqrt(FractalCanvas.ActualHeight * FractalCanvas.ActualWidth) / 8);
        }
        /// <summary>
        /// Функция для рекурсии.
        /// </summary>
        /// <param name="x">Координата X.</param>
        /// <param name="y">Координата Y.</param>
        /// <param name="currentAngle">Текущий угол.</param>
        /// <param name="size1">Конечный размер единицы фрактала.</param>
        /// <param name="currentDepth">Текщая глубина.</param>
        private void Recurs(double x, double y, int currentDepth, int currentAngle, double size1)
        {
            //Заход в рекурсию через условие.
            if (currentDepth < UserDepth)
            {
                Recurs(x, y, currentDepth + 1, currentAngle, size1 / 3);
                Recurs(x + 2 * size * Math.Pow(3, UserDepth - currentDepth)
                    * Math.Cos((currentAngle) * Math.PI / 180), y + 2 * size
                    * Math.Pow(3, UserDepth - currentDepth) * Math.Sin((currentAngle)
                    * Math.PI / 180), currentDepth + 1, currentAngle, size1 / 3);
                Recurs(x + 1 * size * Math.Pow(3, UserDepth - currentDepth)
                    * Math.Cos((currentAngle) * Math.PI / 180), y + 1 * size
                    * Math.Pow(3, UserDepth - currentDepth) * Math.Sin((currentAngle)
                    * Math.PI / 180), currentDepth + 1, currentAngle + 60, size1 / 3);
                Recurs(x + 1 * size * Math.Pow(3, UserDepth - currentDepth)
                    * (Math.Cos((currentAngle) * Math.PI / 180) + Math.Cos((currentAngle + 60)
                    * Math.PI / 180)), y + 1 * size * Math.Pow(3, UserDepth - currentDepth)
                    * (Math.Sin((currentAngle) * Math.PI / 180) + Math.Sin((currentAngle + 60)
                    * Math.PI / 180)), currentDepth + 1, currentAngle - 60, size1 / 3);
            }
            //Рисование первой горизонтальной линии.
            Line myLine1 = new Line
            {
                X1 = x,
                Y1 = FractalCanvas.RenderSize.Height - y,
                X2 = x + size * Math.Cos((currentAngle) * Math.PI / 180),
                Y2 = FractalCanvas.RenderSize.Height - (y + size * Math.Sin((currentAngle) * Math.PI / 180))
            };
            Canvas.SetLeft(myLine1, FractalCanvas.RenderSize.Width / 2);
            Canvas.SetTop(myLine1, -30);
            myLine1.StrokeThickness = 2;
            myLine1.Stroke = new SolidColorBrush(colorList[currentDepth - 1]);
            FractalCanvas.Children.Add(myLine1);
            //Рисование левого ребра.
            Line myLine2 = new Line
            {
                X1 = myLine1.X2,
                Y1 = myLine1.Y2,
                X2 = myLine1.X2 + size * Math.Cos((currentAngle + 60) * Math.PI / 180)
            };
            myLine2.Y2 = (myLine2.Y1 - size * Math.Sin((currentAngle + 60) * Math.PI / 180));
            Canvas.SetLeft(myLine2, FractalCanvas.RenderSize.Width / 2);
            Canvas.SetTop(myLine2, -30);
            myLine2.StrokeThickness = 2;
            myLine2.Stroke = new SolidColorBrush(colorList[currentDepth - 1]);
            FractalCanvas.Children.Add(myLine2);
            //Рисование правого ребра триугольника.
            Line myLine3 = new Line
            {
                X1 = myLine2.X2,
                Y1 = myLine2.Y2,
                X2 = myLine2.X2 + size * Math.Cos((-currentAngle + 60) * Math.PI / 180),
                Y2 = myLine2.Y2 + size * Math.Sin((-currentAngle + 60) * Math.PI / 180)
            };
            Canvas.SetLeft(myLine3, FractalCanvas.RenderSize.Width / 2);
            Canvas.SetTop(myLine3, -30);
            myLine3.StrokeThickness = 2;
            myLine3.Stroke = new SolidColorBrush(colorList[currentDepth - 1]);
            FractalCanvas.Children.Add(myLine3);
            //Рисование последней линии.
            Line myLine4 = new Line
            {
                X1 = myLine3.X2,
                Y1 = myLine3.Y2,
                X2 = myLine3.X2 + size * Math.Cos((currentAngle) * Math.PI / 180)
            };
            myLine4.Y2 = myLine4.Y1 - size * Math.Sin((currentAngle) * Math.PI / 180);
            Canvas.SetLeft(myLine4, FractalCanvas.RenderSize.Width / 2);
            Canvas.SetTop(myLine4, -30);
            myLine4.StrokeThickness = 2;
            myLine4.Stroke = new SolidColorBrush(colorList[currentDepth - 1]);
            FractalCanvas.Children.Add(myLine4);
            x = myLine4.X2;
            y = myLine4.Y2;
        }
    }
    /// <summary>
    /// Фрактал Ковер Серпинского.
    /// </summary>
    public class Carpet : Fractal
    {
        /// <summary>
        /// Конструктор для всех параметров.
        /// </summary>
        /// <param name="canvas">Ссылка на плоскость для рисования.</param>
        /// <param name="depth">Глубина фрактала</param>
        /// <param name="beginGrad">Цвет начала градиента.</param>
        /// <param name="endGrad">Цвет конца градиента.</param>
        public Carpet(Canvas canvas, int depth, Color beginGrad, Color endGrad) : base(canvas, depth, beginGrad, endGrad)
        {

        }
        /// <summary>
        /// Построение фрактала.
        /// </summary>
        public override void BuildFrac()
        {
            Recurs(0.515 * FractalCanvas.ActualWidth, 0.215 * FractalCanvas.ActualHeight, 1, Math.Sqrt(FractalCanvas.ActualHeight * FractalCanvas.ActualWidth) / 3);
        }
        /// <summary>
        /// Функция для рекурсии.
        /// </summary>
        /// <param name="x">Координата X.</param>
        /// <param name="y">Координата Y.</param>
        /// <param name="size">Размер фрактала.</param>
        /// <param name="currentDepth">Текщая глубина.</param>
        private void Recurs(double x, double y, int currentDepth, double size)
        {
            Rectangle rectangle = new Rectangle
            {
                Height = size,
                Width = size,

                Stroke = new SolidColorBrush(colorList[currentDepth - 1]),
                StrokeThickness = size / 3
            };
            Canvas.SetLeft(rectangle, x);
            Canvas.SetTop(rectangle, y);
            FractalCanvas.Children.Add(rectangle);
            if (currentDepth < UserDepth)
            {
                double x1 = x;
                double x2 = x + size / 3;
                double x3 = x + 2 * size / 3;
                double y1 = y;
                double y2 = y + size / 3;
                double y3 = y + 2 * size / 3;
                Recurs(x1, y1, currentDepth + 1, size / 3);
                Recurs(x2, y1, currentDepth + 1, size / 3);
                Recurs(x3, y1, currentDepth + 1, size / 3);
                Recurs(x1, y2, currentDepth + 1, size / 3);
                Recurs(x1, y3, currentDepth + 1, size / 3);
                Recurs(x2, y3, currentDepth + 1, size / 3);
                Recurs(x3, y2, currentDepth + 1, size / 3);
                Recurs(x3, y3, currentDepth + 1, size / 3);
            }
        }
    }
    public class Triangle : Fractal
    {
        /// <summary>
        /// Конструктор для всех параметров.
        /// </summary>
        /// <param name="canvas">Ссылка на плоскость для рисования.</param>
        /// <param name="depth">Глубина фрактала</param>
        /// <param name="beginGrad">Цвет начала градиента.</param>
        /// <param name="endGrad">Цвет конца градиента.</param>
        public Triangle(Canvas canvas, int depth, Color beginGrad, Color endGrad) : base(canvas, depth, beginGrad, endGrad)
        {

        }
        /// <summary>
        /// Построение фрактала.
        /// </summary>
        public override void BuildFrac()
        {
            Recurs(0, 0.215 * FractalCanvas.ActualHeight, 1, Math.Sqrt(FractalCanvas.ActualHeight * FractalCanvas.ActualWidth) / 3);
        }
        /// <summary>
        /// Функция для рекурсии.
        /// </summary>
        /// <param name="x">Координата X.</param>
        /// <param name="y">Координата Y.</param>
        /// <param name="size">Размер фрактала.</param>
        /// <param name="currentDepth">Текщая глубина.</param>
        private void Recurs(double x, double y, int currentDepth, double size)
        {
            PointCollection g = new PointCollection
            {
                new Point(x, FractalCanvas.RenderSize.Height - y),
                new Point(x + size / 2, FractalCanvas.RenderSize.Height - y - size * Math.Sin(Math.PI / 3)),
                new Point(x + size, FractalCanvas.RenderSize.Height - y)
            };
            Polygon polygon = new Polygon
            {
                Points = g,
                Stroke = Brushes.Black,
                StrokeThickness = 2,
                Fill = new SolidColorBrush(colorList[currentDepth - 1])
            };
            Canvas.SetLeft(polygon, FractalCanvas.RenderSize.Width / 2);
            Canvas.SetTop(polygon, -30);
            FractalCanvas.Children.Add(polygon);
            if (currentDepth < UserDepth)
            {
                size = size / 2;
                Recurs(x, y, currentDepth + 1, size);
                Recurs(x + size / 2, y + size * Math.Sin(Math.PI / 3), currentDepth + 1, size);
                Recurs(x + size, y, currentDepth + 1, size);
            }

        }
    }
    public class Kantor : Fractal
    {
        private readonly int distance;
        /// <summary>
        /// Конструктор для всех параметров.
        /// </summary>
        /// <param name="canvas">Ссылка на плоскость для рисования.</param>
        /// <param name="depth">Глубина фрактала</param>
        /// <param name="distance">Расстояние между линиями.</param>
        /// <param name="beginGrad">Цвет начала градиента.</param>
        /// <param name="endGrad">Цвет конца градиента.</param>
        public Kantor(Canvas canvas, int depth, int distance, Color beginGrad, Color endGrad) : base(canvas, depth, beginGrad, endGrad)
        {
            this.distance = distance;
        }
        /// <summary>
        /// Построение фрактала.
        /// </summary>
        public override void BuildFrac()
        {
            Recurs(0, 0.215 * FractalCanvas.ActualHeight, 1, Math.Sqrt(FractalCanvas.ActualHeight * FractalCanvas.ActualWidth) / 3);
        }
        /// <summary>
        /// Функция для рекурсии.
        /// </summary>
        /// <param name="x">Координата X.</param>
        /// <param name="y">Координата Y.</param>
        /// <param name="size">Размер фрактала.</param>
        /// <param name="currentDepth">Текщая глубина.</param>
        private void Recurs(double x, double y, int currentDepth, double size)
        {
            Line myLine = new Line
            {
                X1 = x,
                Y1 = y
            };
            Canvas.SetLeft(myLine, FractalCanvas.RenderSize.Width / 2);
            Canvas.SetTop(myLine, FractalCanvas.RenderSize.Height / 10);
            myLine.X2 = x + size;
            myLine.Y2 = y;
            myLine.StrokeThickness = 5;
            myLine.Stroke = new SolidColorBrush(colorList[currentDepth - 1]);
            FractalCanvas.Children.Add(myLine);
            if (currentDepth < UserDepth)
            {
                size /= 3;
                Recurs(x, y + distance, currentDepth + 1, size);
                Recurs(x + 2 * size, y + distance, currentDepth + 1, size);
            }
        }
    }
}