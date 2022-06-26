using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace FractalWPF
{
    /// <summary>
    /// Логика для окна Window.
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Делегат для рисования.
        /// </summary>
        /// <param name="sender">Издатель.</param>
        /// <param name="e">Информация о событии.</param>
        private delegate void ReCreateFrac(object sender, RoutedEventArgs e);
        /// <summary>
        /// Экземпляр делегата.
        /// </summary>
        private ReCreateFrac reCreateFrac;
        /// <summary>
        /// Экземпляр класса фрактал.
        /// </summary>
        private Fractal.Fractal globeFrac;
        /// <summary>
        /// Приближение окна при масштабировании.
        /// </summary>
        private readonly ScaleTransform scaleTransform = new();
       /// <summary>
       /// Конструктор главного окна.
       /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            globeFrac = new Fractal.Fractal(drawingSurface);
            Width = System.Windows.SystemParameters.PrimaryScreenWidth / 2;
            Height = System.Windows.SystemParameters.PrimaryScreenHeight / 2;
            ResizeMode = ResizeMode.NoResize;
            leftAngleSlider.Value = 45;
            rightAngleSlider.Value = 45;
            colorBegin.SelectedColor = Color.FromRgb(0, 0, 255);
            colorEnd.SelectedColor = Color.FromRgb(255, 0, 0);
            scaleTransform = new ScaleTransform(1, 1);
            drawingSurface.LayoutTransform = scaleTransform;
            drawingSurface.Width = canvasGrid.RenderSize.Width;
            drawingSurface.Height = canvasGrid.RenderSize.Height;
        }
        /// <summary>
        /// Выбирает для рисования фрактал Дерево.
        /// </summary>
        /// <param name="sender">Издатель.</param>
        /// <param name="e">Информация о событии.</param>
        private void TreeButtonClick(object sender, RoutedEventArgs e)
        {
            Title = "Фрактальное дерево";
            reCreateFrac = TreeButtonClick;
            globeFrac = new Fractal.TreeFrac(drawingSurface, (int)slider.Value,
                rightAngleSlider.Value, leftAngleSlider.Value, nextTimesSlider.Value,
                Math.Sqrt(drawingSurface.ActualHeight * drawingSurface.ActualWidth) / 8,
                colorBegin.SelectedColor, colorEnd.SelectedColor);
            slider.Maximum = 11;
        }

        /// <summary>
        /// Выбирает для рисования фрактал Коха.
        /// </summary>
        /// <param name="sender">Издатель.</param>
        /// <param name="e">Информация о событии.</param>
        private void KockButtonClick(object sender, RoutedEventArgs e)
        {
            Title = "Кривая Коха";
            reCreateFrac = KockButtonClick;
            globeFrac = new Fractal.KochLine(drawingSurface, (int)slider.Value,
                Math.Sqrt(drawingSurface.ActualHeight * drawingSurface.ActualWidth) / 5
                , colorBegin.SelectedColor, colorEnd.SelectedColor);
            slider.Maximum = 6;
        }
        /// <summary>
        /// Выбирает для рисования фрактал Ковер Серпинского.
        /// </summary>
        /// <param name="sender">Издатель.</param>
        /// <param name="e">Информация о событии.</param>
        private void CarpetButtonClick(object sender, RoutedEventArgs e)
        {
            Title = "Ковер Серпинского";
            reCreateFrac = CarpetButtonClick;
            globeFrac = new Fractal.Carpet(drawingSurface, (int)slider.Value, colorBegin.SelectedColor, colorEnd.SelectedColor);
            slider.Maximum = 5;
        }
        /// <summary>
        /// Выбирает для рисования фрактал Треугольник серпинского.
        /// </summary>
        /// <param name="sender">Издатель.</param>
        /// <param name="e">Информация о событии.</param>
        private void TriangleButtonClick(object sender, RoutedEventArgs e)
        {
            Title = "Треугольник Серпинского";
            reCreateFrac = TriangleButtonClick;
            globeFrac = new Fractal.Triangle(drawingSurface, (int)slider.Value, colorBegin.SelectedColor, colorEnd.SelectedColor);
            slider.Maximum = 8;
        }
        /// <summary>
        /// Выбирает для рисования фрактал кантора.
        /// </summary>
        /// <param name="sender">Издатель.</param>
        /// <param name="e">Информация о событии.</param>
        private void CantorButtonClick(object sender, RoutedEventArgs e)
        {
            Title = "Множество Кантера";
            reCreateFrac = CantorButtonClick;
            globeFrac = new Fractal.Kantor(drawingSurface, (int)slider.Value,
                (int)widthBetweenSlider.Value, colorBegin.SelectedColor, colorEnd.SelectedColor);
            slider.Maximum = 8;
        }
        /// <summary>
        /// Изменяет размер окна на 1/4;
        /// </summary>
        /// <param name="sender">Издатель.</param>
        /// <param name="e">Информация о событии.</param>
        private void MinSizeButtonClick(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Normal;

            Width = System.Windows.SystemParameters.PrimaryScreenWidth / 2;
            Height = System.Windows.SystemParameters.PrimaryScreenHeight / 2;
            WindowSizeChanged(sender, null);
        }
        /// <summary>
        /// Изменяет размер окна на 3/4;
        /// </summary>
        /// <param name="sender">Издатель.</param>
        /// <param name="e">Информация о событии.</param>
        private void MedSizeButtonClick(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Normal;
            Width = System.Windows.SystemParameters.PrimaryScreenWidth / 3 * 2;
            Height = System.Windows.SystemParameters.PrimaryScreenHeight / 3 * 2;
            WindowSizeChanged(sender, null);
        }
        /// <summary>
        /// Изменяет размер окна на 1/1;
        /// </summary>
        /// <param name="sender">Издатель.</param>
        /// <param name="e">Информация о событии.</param>
        private void MaxSizeButtonClick(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Maximized;
            WindowSizeChanged(sender, null);
        }
        /// <summary>
        /// Рисует фрактал.
        /// </summary>
        /// <param name="sender">Издатель.</param>
        /// <param name="e">Информация о событии.</param>
        private void ButtonDrowClick(object sender, RoutedEventArgs e)
        {
            ButtonX1Click(sender, e);
            reCreateFrac?.Invoke(sender, e);
            drawingSurface.Children.Clear();
            globeFrac.BuildFrac();

        }
        /// <summary>
        /// Измеенение глубины рисования.
        /// </summary>
        /// <param name="sender">Издатель.</param>
        /// <param name="e">Информация о событии.</param>
        private void LevelSliderValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            textBlock.Text = "Глубина: " + slider.Value;
            if (drawingSurface == null)
            {
                return;
            }
            ButtonDrowClick(sender, e);
        }
        /// <summary>
        /// Изменеие значения правого угла.
        /// </summary>
        /// <param name="sender">Издатель.</param>
        /// <param name="e">Информация о событии.</param>
        private void RigthAngleSliderValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            rightAngleText.Content = "Правый угол: " + rightAngleSlider.Value;
            if (reCreateFrac == TreeButtonClick)
            {
                ButtonDrowClick(sender, e);
            }
        }
        /// <summary>
        /// Изменеие значения левого угла.
        /// </summary>
        /// <param name="sender">Издатель.</param>
        /// <param name="e">Информация о событии.</param>
        private void LeftAngleSliderValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            leftAngleText.Content = "Левый угол: " + leftAngleSlider.Value;
            if (reCreateFrac == TreeButtonClick)
            {
                ButtonDrowClick(sender, e);
            }
        }
        /// <summary>
        /// Изменеие сдайдера коэфа умножения. 
        /// </summary>
        /// <param name="sender">Издатель.</param>
        /// <param name="e">Информация о событии.</param>
        private void NextTimesSliderValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            nextTimeText.Content = "Коэффициент: " + nextTimesSlider.Value.ToString("F2");
            if (reCreateFrac == TreeButtonClick)
            {
                ButtonDrowClick(sender, e);
            }
        }
        /// <summary>
        /// Изменение слайдера расстояние между линиями.
        /// </summary>
        /// <param name="sender">Издатель.</param>
        /// <param name="e">Информация о событии.</param>
        private void WidthBetweenSliderValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            widthBetweenText.Content = "Расстояние: " + widthBetweenSlider.Value;
            if (reCreateFrac == CantorButtonClick)
            {
                ButtonDrowClick(sender, e);
            }
        }
        /// <summary>
        /// Изменение начла градиента.
        /// </summary>
        /// <param name="sender">Издатель.</param>
        /// <param name="e">Информация о событии.</param>
        private void ColorBeginColorChanged(object sender, RoutedEventArgs e)
        {

            if (drawingSurface == null)
            {
                return;
            }

            ButtonDrowClick(sender, e);
        }
        /// <summary>
        /// Изменение конца градиента.
        /// </summary>
        /// <param name="sender">Издатель.</param>
        /// <param name="e">Информация о событии.</param>
        private void ColorEndColorChanged(object sender, RoutedEventArgs e)
        {
            if (drawingSurface == null)
            {
                return;
            }

            ButtonDrowClick(sender, e);
        }
        /// <summary>
        /// Делает скрин шот.
        /// </summary>
        /// <param name="sender">Издатель.</param>
        /// <param name="e">Информация о событии.</param>
        private void ScreenShot(object sender, RoutedEventArgs e)
        {
            RenderTargetBitmap renderTargetBitmap =
                new RenderTargetBitmap((int)Width,
                    (int)Height, 96, 96, PixelFormats.Pbgra32);
            renderTargetBitmap.Render(drawingSurface);
            PngBitmapEncoder pngImage = new PngBitmapEncoder();
            pngImage.Frames.Add(BitmapFrame.Create(renderTargetBitmap));
            Stream myStream;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog
            {
                Filter = "Jpg files (*.jpg)|*.jpg",
                FilterIndex = 2,
                RestoreDirectory = true
            };
            bool? result = saveFileDialog1.ShowDialog();
            try
            {
                if (result == true)
                {
                    if ((myStream = saveFileDialog1.OpenFile()) != null)
                    {
                        pngImage.Save(myStream);
                        myStream.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }


        /// <summary>
        /// Масштабирует в X1 раз.
        /// </summary>
        /// <param name="sender">Издатель.</param>
        /// <param name="e">Информация о событии.</param>
        private void ButtonX1Click(object sender, RoutedEventArgs e)
        {
            scaleTransform.ScaleX = 1;
            scaleTransform.ScaleY = 1;
        }
        /// <summary>
        /// Масштабирует в X2 раз.
        /// </summary>
        /// <param name="sender">Издатель.</param>
        /// <param name="e">Информация о событии.</param>
        private void ButtonX2Click(object sender, RoutedEventArgs e)
        {
            scaleTransform.ScaleX = 2;
            scaleTransform.ScaleY = 2;
        }
        /// <summary>
        /// Масштабирует в X3 раз.
        /// </summary>
        /// <param name="sender">Издатель.</param>
        /// <param name="e">Информация о событии.</param>
        private void ButtonX3Click(object sender, RoutedEventArgs e)
        {
            scaleTransform.ScaleX = 3;
            scaleTransform.ScaleY = 3;
        }
        /// <summary>
        /// Масштабирует в X5 раз.
        /// </summary>
        /// <param name="sender">Издатель.</param>
        /// <param name="e">Информация о событии.</param>
        private void ButtonX5Click(object sender, RoutedEventArgs e)
        {
            scaleTransform.ScaleX = 5;
            scaleTransform.ScaleY = 5;
        }
        /// <summary>
        /// Изменился размер экрана событие.
        /// </summary>
        /// <param name="sender">Издатель.</param>
        /// <param name="e">Информация о событии.</param>
        private void WindowSizeChanged(object sender, SizeChangedEventArgs e)
        {
            drawingSurface.Width = canvasGrid.RenderSize.Width;
            drawingSurface.Height = canvasGrid.RenderSize.Height;
            ButtonDrowClick(sender, e);
        }
    }
}
