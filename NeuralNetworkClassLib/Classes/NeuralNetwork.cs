using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeuralNetworkClassLib.Interfaces;

namespace NeuralNetworkClassLib.Classes
{
    public class NeuralNetwork
    {
        List<NeuronLayer> layers = new List<NeuronLayer>();

        public NeuralNetwork(int numberOfInputs)
        {
            CreateInputLayer(numberOfInputs);
        }

        public void AddLayer(int numberOfNeurons, IActivationFunction activationFunction)
        {
            var newLayer = new NeuronLayer(activationFunction, numberOfNeurons);
            newLayer.ConnectLayers(layers.Last());
            layers.Add(newLayer);
        }

        void CreateInputLayer(int numberOfInputs)
        {
            var inputLayer = new NeuronLayer(new BlankActivationFunction(), numberOfInputs);
            inputLayer.Neurons.ForEach(neuron => neuron.InputSynapses.Add(new InputSynapse()));
            layers.Add(inputLayer);
        }

        public void PushValuesOnInput(double[] inputs)
        {
            layers.First().Neurons.ForEach(neuron => neuron.InputSynapses.First().PushValue(inputs[layers.First().Neurons.IndexOf(neuron)]));
        }

        public double[] GetOutput()
        {
            layers.ForEach(layer => layer.Neurons.ForEach(neuron => neuron.PushValues()));
            return layers.Last().Neurons.Select(neuron => neuron.Value).ToArray();
        }
    }
}
