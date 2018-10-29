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

        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Парсинг строки
                PreparedExpression preparedExpression = ToolsHelper.Parser.Parse(textBox.Text);
                // Компиляция распарсеных данных
                CompiledExpression compiledExpression = ToolsHelper.Compiler.Compile(preparedExpression);
                // Creating list of variables specified
                List<VariableValue> variables = new List<VariableValue>();

                try
                {
                    // Рассчёт
                    double res = ToolsHelper.Calculator.Calculate(compiledExpression, variables);
                    // Отображение результата
                    result.Content = String.Format("Результат: {0}", res);
                }
                catch { };
            }
            catch (CompilerSyntaxException ex)
            {
                result.Content = String.Format("Ошибка синтаксиса: {0}", ex.Message);
            }
            catch (MathProcessorException ex)
            {
                result.Content = String.Format("Ошибка: {0}", ex.Message);
            }
        }
    }
}
