using WebFormsMvp;

namespace MvpDemo.Logic123
{
    public class CalculatorPresenter : Presenter<ICalculatorView>
    {
        public CalculatorPresenter(ICalculatorView view, ICalculator calculator) : base(view)
        {
            view.Calculate += (sender, args) =>
                                  {
                                      var numbers = view.Numbers;
                                      var result = calculator.Add(numbers);
                                      view.Model.Result = result;
                                  };

        }
    }
}