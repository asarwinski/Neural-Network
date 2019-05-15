using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetworkClassLib.Interfaces
{
    public interface IActivationFunction
    {
        double Calculate(double input);
        double GetDerivative(double input);
    }
}
