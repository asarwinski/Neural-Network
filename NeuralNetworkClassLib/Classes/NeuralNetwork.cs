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
            newLayer.Neurons.ForEach(neuron => neuron.InputSynapses.Add(new Bias(neuron)));
            newLayer.ConnectLayers(layers.Last());
            layers.Add(newLayer);
        }

        void CreateInputLayer(int numberOfInputs)
        {
            var inputLayer = new NeuronLayer(new BlankActivationFunction(), numberOfInputs);
            inputLayer.Neurons.ForEach(neuron => neuron.InputSynapses.Add(new InputSynapse(neuron)));
            layers.Add(inputLayer);
        }

        public void PushValuesOnInput(double[] inputs)
        {
            layers.First().Neurons.ForEach(neuron => neuron.InputSynapses.First().PushValue(inputs[layers.First().Neurons.IndexOf(neuron)]));
            layers.ForEach(layer => layer.Neurons.ForEach(neuron => neuron.PushValues()));
        }

        public double[] GetOutput()
        {
            return layers.Last().Neurons.Select(neuron => neuron.Value).ToArray();
        }

        public void Train(double trainingRate, Tuple<double[], double[]> trainingData)
        {
            PushValuesOnInput(trainingData.Item1);

            for (int i = layers.Count-1; i > 0; i--)
            {
                foreach(Neuron neuron in layers[i].Neurons)
                {
                    double derivative = neuron.ActivationFunction.GetDerivative(neuron.Value);
                    if (i == layers.Count-1)
                    {
                        neuron.Delta = (trainingData.Item2[layers[i].Neurons.IndexOf(neuron)] - neuron.Value) * derivative;
                    }
                    else
                    {
                        neuron.Delta = neuron.OutputSynapses.Select(synapse => synapse.Weight * synapse.ToNeuron.Delta).Sum() * derivative;
                    }
                    neuron.InputSynapses.ForEach
                        (
                            synapse =>
                            {
                                if (synapse.FromNeuron == null) synapse.Weight += trainingRate * synapse.ToNeuron.Delta;
                                else synapse.Weight += trainingRate * synapse.ToNeuron.Delta * synapse.FromNeuron.Value;
                            }
                        );
                }
            }
        }
    }
}
