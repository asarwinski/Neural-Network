using System;
using System.Collections.Generic;
using System.Text;
using NeuralNetworkClassLib.Interfaces;

namespace NeuralNetworkClassLib.Classes
{
    public class SigmoidActivationFunction : IActivationFunction
    {
        public double Calculate(double input)
        {
            return 1 / (1 + Math.Exp(-input));
        }

        public double GetDerivative(double input)
        {
            return input * (1 - input);
        }
    }
}
