using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeuralNetworkClassLib.Interfaces;

namespace NeuralNetworkClassLib
{
    class Neuron
    {
        List<double> weights = new List<double>();
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
        
        public Neuron(int numberOfInputs, IActivationFunction activationFunction)
        {
            InitalizeWeights(numberOfInputs);
            this.activationFunction = activationFunction;
        }
        
        public void PushValues(List<double> inputValues)
        {
            double weightedSum;
            //need one more weight for bias
            inputValues.Insert(0,1);
            weightedSum = inputValues.Select(value => value * weights[inputValues.IndexOf(value)]).Sum();
            Value = activationFunction.Calculate(weightedSum);
        }
        
        void InitalizeWeights(int numberOfInputs)
        {    
            for(int i = 0; i < numberOfInputs+1; i++)
            {
                double newWeight = rnd.NextDouble()*10-5;
                weights.Add(newWeight); 
            }
        }
    }
}
