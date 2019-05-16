using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetworkClassLib
{
    public class NeuralNetworkTrainingData
    {
        static public Tuple<double[], double>[] AndTrainingData { get; set; } =
        {
            Tuple.Create(new double[] {1,1},1d),
            Tuple.Create(new double[] {1,0},-1d),
            Tuple.Create(new double[] {0,1},-1d),
            Tuple.Create(new double[] {0,0},-1d)
        };

        static public Tuple<double[], double>[] OrTrainingData { get; set; } =
        {
            Tuple.Create(new double[] {1,1},1d),
            Tuple.Create(new double[] {1,0},1d),
            Tuple.Create(new double[] {0,1},1d),
            Tuple.Create(new double[] {0,0},-1d)
        };

        static public Tuple<double[], double[]>[] XorTrainingData { get; set; } =
        {
            Tuple.Create(new double[] {1,1}, new double[] {0 }),
            Tuple.Create(new double[] {1,0}, new double[] {1 }),
            Tuple.Create(new double[] {0,1}, new double[] {1 }),
            Tuple.Create(new double[] {0,0}, new double[] {0 })
        };

        static public Tuple<double[], double[]>[] AndMlpTrainingData { get; set; } =
        {
            Tuple.Create(new double[] {1,1}, new double[] {1 }),
            Tuple.Create(new double[] {1,0}, new double[] {0 }),
            Tuple.Create(new double[] {0,1}, new double[] {0 }),
            Tuple.Create(new double[] {0,0}, new double[] {0 })
        };
    }
}
