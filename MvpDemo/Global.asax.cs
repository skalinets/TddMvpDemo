using System;
using System.Linq;
using System.Web;
using Microsoft.Practices.Unity;
using WebFormsMvp.Binder;
using WebFormsMvp.Unity;

namespace MvpDemo
{
    public class Global : HttpApplication
    {
        private void Application_Start(object sender, EventArgs e)
        {
            var container = new UnityContainer();
            container.RegisterType<ICalculator, MyCalculator>();

            PresenterBinder.Factory = new UnityPresenterFactory(container);
        }
    }

    internal class MyCalculator : ICalculator
    {
        public int Add(string numbers)
        {
            return numbers.Split(',').Sum(s => Int32.Parse(s));
        }
    }
}