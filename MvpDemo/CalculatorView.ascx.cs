using System;
using MvpDemo.Logic123;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace MvpDemo
{
    [PresenterBinding(typeof(CalculatorPresenter))]
    public partial class CalculatorView : MvpUserControl<CalculatorModel>, ICalculatorView
    {
        public event EventHandler Calculate
        {
            add { button.Click += value; }
            remove { button.Click -= value; }
        }

        public string Numbers
        {
            get { return tbInput.Text; }
        }
    }
}