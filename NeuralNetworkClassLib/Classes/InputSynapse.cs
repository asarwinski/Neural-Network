using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeuralNetworkClassLib.Interfaces;

namespace NeuralNetworkClassLib.Classes
{
    public class InputSynapse : ISynapse
    {
        public Neuron FromNeuron { get; } = null;

        double _weight = 1;
        public double Weight
        {
            get
            {
                return _weight;
            }
            set
            {
                LastWeight = _weight;
                _weight = value;
            }
        }

        public double LastWeight { get; set; } = 1;
        public double Value { get; private set; }

        static Random rnd = new Random();

        public InputSynapse()
        {
            Value = 1;
        }

        public void PushValue(double input)
        {
            Value = input;
        }
    }
}
