using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeuralNetworkClassLib.Interfaces;

namespace NeuralNetworkClassLib.Classes
{
    public class NeuronLayer
    {
        public List<Neuron> Neurons = new List<Neuron>();

        public NeuronLayer(IActivationFunction activationFunciton, int numberOfNeurons)
        {
            for (int i = 0; i < numberOfNeurons; i++)
            {
                Neurons.Add(new Neuron(activationFunciton));
            }
        }

        public void ConnectLayers(NeuronLayer inputLayer)
        {
            var combos = Neurons.SelectMany(neuron => inputLayer.Neurons, (neuron, input) => new { neuron, input });
            combos.ToList().ForEach(x => x.neuron.AddInputNeuron(x.input));
        }
    }
}
