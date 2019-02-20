using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace kalk1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string[] signs = { "*", "/", "+", "-" };

        /// <summary>
        /// Конструктор
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Добавление содержимого кнопок в строку
        /// </summary>
        /// <param name="sender">Объект</param>
        /// <param name="e">Событие</param>
        private void clickOnBtn(object sender, RoutedEventArgs e)
        {
            string data = (string)((Button)e.OriginalSource).Content;
            
            answLabel.Content += data;
            
        }

        /// <summary>
        /// Считывание корня числа, при условии, что строка не пустая, и в ней только число, без действий
        /// </summary>
        /// <param name="sender">объект</param>
        /// <param name="e">событие</param>
        private void clickOnKorenBtn(object sender, RoutedEventArgs e)
        {
            if (Convert.ToString(answLabel.Content) != "")
            {
                for (int i = 0; i < signs.Length; i++)
                {
                    if (Convert.ToString(answLabel.Content).Contains(signs[i]) == true)
                        break;
                    else
                    {
                        try
                        {
                            answLabel.Content = Math.Sqrt(Convert.ToDouble(answLabel.Content));
                        }
                        catch {}

                    }
                }
            }
            
        }

        /// <summary>
        /// Очищение строки при нажатии на кнопку C
        /// </summary>
        /// <param name="sender">объект</param>
        /// <param name="e">событие</param>
        private void clrButton(object sender, RoutedEventArgs e)
        {
            answLabel.Content = "";
        }

        /// <summary>
        /// Функция рассчета данных в лейбле
        /// </summary>
        /// <param name="sender">объект</param>
        /// <param name="e">событие</param>
        private void clickOnAnswBtn(object sender, RoutedEventArgs e)
        {
            string st = Convert.ToString(answLabel.Content);
            //Строка разделяется на 2 числа и действие между ними
            string ch1 = ""; 
            string ch2 = "";
            string deistv = "";
            int stLen = st.Length;

            //Если знак действия последний или его вообще нет, то кнопка = не сработает
            if (st[st.Length - 1] != '*' || st[st.Length - 1] != '/' || st[st.Length - 1] != '+' || st[st.Length - 1] != '-' || st[st.Length - 1] != '^'
                && st.Contains('*') == true || st.Contains('/') == true || st.Contains('+') == true || st.Contains('+') == true || st.Contains('^') == true)
                {
                    for (int i = 0; i < st.Length; i++)
                    {
                        ch1 += st[i];
                        if (st[i] == '*' || st[i] == '/' || st[i] == '+' || st[i] == '-' || st[i] == '^')
                        {
                            deistv += st[i];
                            ch2 += ch1;
                            ch1 = "";
                        }

                    }
                    string chh2 = "";

                    // Удаление действия из строки 2.
                    for(int i = 0; i < ch2.Length-1; i++)
                    {
                        chh2 += ch2[i];
                    }
                    
                    double result1 = 0.0;
                    double result2 = 0.0;

                    // Выполнение различных математических действий
                    try
                    {
                        if (deistv == "*")
                        {
                            result1 = Convert.ToDouble(ch1);
                            result2 = Convert.ToDouble(chh2);
                            answLabel.Content = Convert.ToString(result2 * result1);
                        }
                        else if (deistv == "/")
                        {
                            result1 = Convert.ToDouble(ch1);
                            result2 = Convert.ToDouble(chh2);
                            answLabel.Content = Convert.ToString(result2 / result1);
                        }
                        else if (deistv == "+")
                        {
                            result1 = Convert.ToDouble(ch1);
                            result2 = Convert.ToDouble(chh2);
                            answLabel.Content = Convert.ToString(result2 + result1);
                        }
                        else if (deistv == "-")
                        {
                            result1 = Convert.ToDouble(ch1);
                            result2 = Convert.ToDouble(chh2);
                            answLabel.Content = Convert.ToString(result2 - result1);
                        }
                        else if (deistv == "^")
                        {
                            result1 = Convert.ToDouble(ch1);
                            result2 = Convert.ToDouble(chh2);
                            answLabel.Content = Convert.ToString(Math.Pow(result2, result1));
                        }
                    }
                    catch { }

                }

        }
  
    }
}
