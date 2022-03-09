using System;
using System.Collections.Generic;
using System.Text;
using ReactiveUI;
using RomanCalc.Models;
using RomanNumbers;

namespace RomanCalc.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public string expression = "";
        public ReactiveCommand<string, string> OnClickCommand { get; }
        public MainWindowViewModel()
        {
            OnClickCommand = ReactiveCommand.Create<string, string>((str) => Expression = str);
        }
        public string Expression
        {
            set
            {
                if (expression == "Error")
                    expression = "";
                if (value != "=")
                    this.RaiseAndSetIfChanged(ref expression, expression + value);
                else
                {
                    try
                    {
                        if (expression.IndexOf('+') == 0 || expression.IndexOf('+') == expression.Length - 1 ||
                            expression.IndexOf('-') == 0 || expression.IndexOf('-') == expression.Length - 1 ||
                            expression.IndexOf('*') == 0 || expression.IndexOf('*') == expression.Length - 1 ||
                            expression.IndexOf('/') == 0 || expression.IndexOf('/') == expression.Length - 1)
                            throw new RomanNumberException("Error");
                        if (expression.IndexOf('+') != -1)
                        {
                            RomanNumberExtend a = new(expression.Substring(0, expression.IndexOf('+')));
                            RomanNumberExtend b = new(expression.Substring(expression.IndexOf('+')));
                            this.RaiseAndSetIfChanged(ref expression, (a + b).ToString());
                        }
                        if (expression.IndexOf('-') != -1)
                        {
                            RomanNumberExtend a = new(expression.Substring(0, expression.IndexOf('-')));
                            RomanNumberExtend b = new(expression.Substring(expression.IndexOf('-')));
                            this.RaiseAndSetIfChanged(ref expression, (a - b).ToString());
                        }
                        if (expression.IndexOf('*') != -1)
                        {
                            RomanNumberExtend a = new(expression.Substring(0, expression.IndexOf('*')));
                            RomanNumberExtend b = new(expression.Substring(expression.IndexOf('*')));
                            this.RaiseAndSetIfChanged(ref expression, (a * b).ToString());
                        }
                        if (expression.IndexOf('/') != -1)
                        {
                            RomanNumberExtend a = new(expression.Substring(0, expression.IndexOf('/')));
                            RomanNumberExtend b = new(expression.Substring(expression.IndexOf('/')));
                            this.RaiseAndSetIfChanged(ref expression, (a / b).ToString());
                        }
                        expression = "";
                    }
                    catch (RomanNumberException)
                    {
                        this.RaiseAndSetIfChanged(ref expression, "Error");
                    }
                }
            }
            get
            {
                return expression;
            }
        }
    }
}