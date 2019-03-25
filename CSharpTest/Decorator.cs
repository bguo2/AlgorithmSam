using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTest
{
    public abstract class BakeryComponet
    {
        public abstract string GetName();
        public abstract double GetPrice();
    }

    public class Cake : BakeryComponet
    {
        private string m_name = "cake base";
        private double m_price = 10.0;

        public override string GetName()
        {
            return m_name;
        }

        public override double GetPrice()
        {
            return m_price;
        }
    }

    public class Decorator : BakeryComponet
    {
        private readonly BakeryComponet m_baseComponent;
        protected string m_name = "undefined decortor";
        protected double m_price = 0.0;

        protected Decorator(BakeryComponet baseComponent)
        {
            m_baseComponent = baseComponent;
        }

        public override string GetName()
        {
            return string.Format("{0},{1}", m_baseComponent.GetName(), m_name);
        }

        public override double GetPrice()
        {
            return m_price + m_baseComponent.GetPrice();
        }
    }

    public class CreamDecorator : Decorator
    {
        public CreamDecorator(BakeryComponet baseComponent)
            : base(baseComponent)
        {
            this.m_name = "Cream";
            this.m_price = 2.0;
        }
    }

    public class CherryDecorator : Decorator
    {
        public CherryDecorator(BakeryComponet baseComponent)
            : base(baseComponent)
        {
            this.m_name = "Cherry";
            this.m_price = 4.0;
        }
    }

    public class DecoratorTest
    {
        public static void Print(Decorator decorator)
        {
            Console.WriteLine("Name: {0}", decorator.GetName());
            Console.WriteLine("Name: {0}", decorator.GetPrice());
        }

        public static void Test()
        {
            var cake = new Cake();
            var creamCake = new CreamDecorator(cake);
            var cherryCreamCake = new CherryDecorator(creamCake);
            Print(cherryCreamCake);
        }
    }
}
