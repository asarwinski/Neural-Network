﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeuralNetworkClassLib.Interfaces;

namespace NeuralNetworkClassLib.Classes
{
    public class Synapse : ISynapse
    {
        public Neuron FromNeuron { get; private set; }
        public Neuron ToNeuron { get; private set; }

        double _weight;
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

        public double LastWeight { get; set; }
        public double Value { get; private set; }

        static Random rnd = new Random();

        public Synapse(Neuron fromNeuron, Neuron toNeuron)
        {
            this.FromNeuron = fromNeuron;
            this.ToNeuron = toNeuron;
            this.Weight = rnd.NextDouble() * 10 - 5;
            LastWeight = Weight;
        }

        public void PushValue(double input)
        {
            Value = input * Weight;
        }

    }
}
