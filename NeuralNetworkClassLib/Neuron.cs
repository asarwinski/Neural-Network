using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        
        public Neuron(int numberOfInputs, IActivationFunciotn activationFunction)
        {
            InitalizeWeights(numberOfInputs);
            this.activaionFunction = activationFunction;
        }
        
        public void PushValues(List<double> inputValues)
        {
            double weightedSum;
            inputValues.Insert(1,0);
            weightedSum = inputValues.ForEach(value => value*weights[inputValues.IndexOf(value)]);
            Value = activationFuntion(weightedSum);
        }
        
        InitalizeWeights(int numberOfInputs)
        {
            //need one more weight for bias
            for(int i = 0; i < numberOfInputs+1; i++)
            {
                double newWeight = rnd.NextDouble()*10-5;
                weights.Add(newWeight); 
            }
        }
    }
}
