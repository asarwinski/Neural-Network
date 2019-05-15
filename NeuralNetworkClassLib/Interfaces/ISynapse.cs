using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeuralNetworkClassLib.Classes;

namespace NeuralNetworkClassLib.Interfaces
{
    public interface ISynapse
    {
        Neuron FromNeuron { get; }
        double Weight { get; set; }
        double LastWeight { get; }
        double Value { get; }

        void PushValue(double input);
    }
}
