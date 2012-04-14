using System;
using MvpDemo.Logic123;
using NSubstitute;
using WebFormsMvp;
using Xunit;
using FluentAssertions;

namespace MvpDemo
{
    public class CalculatorPresenterTests
    {
        private readonly ICalculatorView calculatorView;
        private readonly CalculatorPresenter calculatorPresenter;
        private readonly ICalculator calculator;

        public CalculatorPresenterTests()
        {
            calculatorView = Substitute.For<ICalculatorView>();
            calculator = Substitute.For<ICalculator>();
            calculatorPresenter = new CalculatorPresenter(calculatorView, calculator);
        }

        [Fact]
        public void should_be_presenter()
        {
            // assert
            calculatorPresenter.Should()
                .BeAssignableTo<Presenter<ICalculatorView>>();
        }

        const string numbers = "numbers";
        const int expected = 123;

        [Fact]
        public void should_udpate_model_by_event()
        {
            // arrange
            calculator.Add(numbers).Returns(expected);
            calculatorView.Numbers.Returns(numbers);

            // act
            calculatorView.Calculate += Raise.EventWith(calculatorView, EventArgs.Empty);

            // assert
            calculatorView.Model.Result
                .Should()
                .Be(expected);
        }
    }

    public class CalculatorModel
    {
        public int Result { get; set; }
    }

    public interface ICalculator
    {
        int Add(string numbers);
    }

    public interface ICalculatorView : IView<CalculatorModel>
    {
        event EventHandler Calculate;
        string Numbers { get; }
    }
}