using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public interface ICalculation
    {
        double Perform(double k);
    }

    //класс сложения
    public class Add : ICalculation
    {
        double term;
        public Add(double term)
        {
            this.term = term;

        }

        //метод преобразования
        public double Perform(double k)
        {
            return k + term;
        }
    }

    public class Divide : ICalculation
    {
        double devisor;
        //конструтктор
        public Divide(double devisor)
        {
            if (devisor == 0.0) throw new DivideByZeroException("нельзя делить на ноль.");
            this.devisor = devisor;
        }

        //метод из интерфейса
        public double Perform(double k)
        {
            return k / devisor;
        }
    }
}
