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
                OneDimensionalArray array = new OneDimensionalArray(0.5, 10);

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
    public class OneDimensionalArray
    {
        private double[] array;

        /// <summary>
        /// Конструктор для создания массива заданного размера
        /// </summary>
        public OneDimensionalArray(int size)
        {
            // Проверка на некорректный размер массива
            if (size <= 0)
                throw new ArgumentException("Size must be greater than zero.");

            // Выделение памяти под массив
            array = new double[size];
        }

        /// <summary>
        /// Конструктор для создания массива и заполнения его значениями ряда Тейлора для функции ln x
        /// </summary>
        public OneDimensionalArray(double x, int size)
        {
            // Проверка на некорректный размер массива
            if (size <= 0)
                throw new ArgumentException("Size must be greater than zero.");

            // Выделение памяти под массив
            array = new double[size];
            // Заполнение массива значениями ряда Тейлора для ln x
            for (int i = 0; i < size; i++)
            {
                array[i] = Math.Log(x + i);
            }
        }

        /// <summary>
        /// Свойство для получения количества элементов массива, значения которых меньше 0.2
        /// </summary>
        public int CountElementsLessThanPointTwo
        {
            get
            {
                // Инициализация счетчика элементов меньше 0.2
                int count = 0;
                // Перебор всех элементов массива
                foreach (var item in array)
                {
                    // Проверка, является ли текущий элемент меньше 0.2
                    if (item < 0.2)
                        // Если да, увеличиваем счетчик
                        count++;
                }
                // Возвращаем количество элементов меньше 0.2
                return count;
            }
        }

        /// <summary>
        /// Метод для вычисления суммы модулей элементов массива до первого элемента, равного нулю
        /// </summary>
        public double SumOfAbsoluteValuesBeforeFirstZero()
        {
            // Инициализация переменной для хранения суммы модулей
            double sum = 0;
            // Перебор всех элементов массива
            for (int i = 0; i < array.Length; i++)
            {
                // Проверка, является ли текущий элемент равным нулю
                if (array[i] == 0)
                    // Если да, завершаем цикл
                    break;

                // Добавление модуля текущего элемента к сумме
                sum += Math.Abs(array[i]);
            }
            // Возвращаем сумму модулей элементов до первого нуля
            return sum;
        }
    }
}
