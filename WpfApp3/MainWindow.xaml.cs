using System;
using System.Windows;

namespace WpfApp3
{
    /// <summary>
    /// Главное окно приложения
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Обработчик события нажатия кнопки "Calculate"
        /// </summary>
        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Создание объекта OneDimensionalArray с использованием второго конструктора
                OneDimensionalArray<double> array = new OneDimensionalArray<double>(0.5, 10);

                // Вывод количества элементов меньше 0.2
                int count = array.CountElementsLessThanPointTwo;
                double sum = array.SumOfAbsoluteValuesBeforeFirstZero();

                // Отображение результатов на экране
                ResultTextBlock.Text = $"Number of elements less than 0.2: {count}\n" +
                                       $"Sum of absolute values before first zero: {sum}";
            }
            catch (Exception ex)
            {
                // Отображение сообщения об ошибке на экране
                ResultTextBlock.Text = $"Error: {ex.Message}";
            }
        }
    }

    /// <summary>
    /// Класс для работы с одномерным массивом
    /// </summary>
    public class OneDimensionalArray<T>
    {
        private T[] array;

        /// <summary>
        /// Конструктор для создания массива заданного размера
        /// </summary>
        public OneDimensionalArray(int size)
        {
            if (size <= 0)
                throw new ArgumentException("Size must be greater than zero.");

            array = new T[size];
        }

        /// <summary>
        /// Конструктор для создания массива и заполнения его значениями ряда Тейлора для функции ln x
        /// </summary>
        public OneDimensionalArray(double x, int size)
        {
            if (size <= 0)
                throw new ArgumentException("Size must be greater than zero.");

            array = new T[size];
            for (int i = 0; i < size; i++)
            {
                array[i] = (T)Convert.ChangeType(Math.Log(x + i), typeof(T));
            }
        }

        /// <summary>
        /// Свойство для получения количества элементов массива, значения которых меньше 0.2
        /// </summary>
        public int CountElementsLessThanPointTwo
        {
            get
            {
                int count = 0;
                foreach (var item in array)
                {
                    if (Convert.ToDouble(item) < 0.2)
                        count++;
                }
                return count;
            }
        }

        /// <summary>
        /// Метод для вычисления суммы модулей элементов массива до первого элемента, равного нулю
        /// </summary>
        public double SumOfAbsoluteValuesBeforeFirstZero()
        {
            double sum = 0;
            foreach (var item in array)
            {
                if (Convert.ToDouble(item) == 0)
                    break;

                sum += Math.Abs(Convert.ToDouble(item));
            }
            return sum;
        }
    }
}
