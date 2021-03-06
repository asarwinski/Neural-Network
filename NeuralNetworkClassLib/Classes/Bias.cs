﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeuralNetworkClassLib.Interfaces;

namespace NeuralNetworkClassLib.Classes
{
    public class Bias : ISynapse
    {
        public Neuron FromNeuron { get; } = null;
        public Neuron ToNeuron { get; }

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
        public double Value
        {
            get
            {
                return Weight;
            }
        }

        static Random rnd = new Random();

        public Bias(Neuron toNeuron)
        {
            this.ToNeuron = toNeuron;
            this.Weight = rnd.NextDouble() * 10 - 5;
            LastWeight = Weight;
        }

        public void PushValue(double input)
        {
            
        }
    }
}
