using System;
using System.Collections.Generic;
using System.Windows;
using ELW.Library.Math;
using ELW.Library.Math.Exceptions;
using ELW.Library.Math.Expressions;
using ELW.Library.Math.Tools;

namespace Calculator228
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // Парсинг строки и выполнение необходимых действий при нажатии на кнопку "Посчитать"
        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Парсинг строки
                PreparedExpression preparedExpression = ToolsHelper.Parser.Parse(textBox.Text);
                // Компиляция распарсеных данных
                CompiledExpression compiledExpression = ToolsHelper.Compiler.Compile(preparedExpression);
                // Создаёт лист переменных (в данной программе переменные по типу X и Y,
                // используемые для рассчёта уравнений, не используются,
                // но они необходимы т.к. этого требует библиотека ELW
                List<VariableValue> variables = new List<VariableValue>();

                // Рассчёт
                double res = ToolsHelper.Calculator.Calculate(compiledExpression, variables);
                // Отображение результата
                result.Content = String.Format("Результат: {0}", res);
            }
            // Обработчики ошибок
            catch (CompilerSyntaxException ex)
            {
                result.Content = String.Format("Ошибка синтаксиса: {0}", ex.Message);
            }
            catch (MathProcessorException ex)
            {
                result.Content = String.Format("Ошибка: {0}", ex.Message);
            }
            catch (ArgumentException)
            {
                result.Content = "Ошибка в входных данных";
            }
        }

    }
}
