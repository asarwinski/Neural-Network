using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeuralNetworkClassLib.Interfaces;

namespace NeuralNetworkClassLib.Classes
{
    public class BlankActivationFunction : IActivationFunction
    {
        public double Calculate(double input)
        {
            return input;
        }

        public double GetDerivative(double input)
        {
            return 1;
        }
    }
}
