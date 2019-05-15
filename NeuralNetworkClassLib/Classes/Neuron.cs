using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeuralNetworkClassLib.Interfaces;

namespace NeuralNetworkClassLib.Classes
{
    public class Neuron
    {
        public List<ISynapse> InputSynapses = new List<ISynapse>();
        public List<ISynapse> OutputSynapses = new List<ISynapse>();
        IActivationFunction activationFunction;
        
        static Random rnd = new Random();
        
        public double _value;
        public double Value 
        {      
            get
            {
                return _value;   
            }
            private set
            {
                PreviousValue = _value;
                _value = value;
            }
        }
        public double PreviousValue { get; private set; }
        
        public Neuron(IActivationFunction activationFunction)
        {
            this.activationFunction = activationFunction;
            //adding bias
            InputSynapses.Add(new Bias());
        }

        public void AddInputNeuron(Neuron input)
        {
            var synapse = new Synapse(input, this);
            InputSynapses.Add(synapse);
            input.OutputSynapses.Add(synapse);
        }
        
        public void PushValues()
        {
            double weightedSum;
            weightedSum = InputSynapses.Select(synapse => synapse.Value).Sum();
            Value = activationFunction.Calculate(weightedSum);
            OutputSynapses.ForEach(synapse => synapse.PushValue(Value));
        }

        public void PushValueOnInput(List<double> inputs)
        {
            InputSynapses.ForEach(synapse => synapse.PushValue(inputs[InputSynapses.IndexOf(synapse)]));
        }
    }
}
