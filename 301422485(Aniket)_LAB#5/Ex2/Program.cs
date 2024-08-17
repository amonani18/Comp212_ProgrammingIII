using System;
using Microsoft.ML;
using Microsoft.ML.Data;
/*
 * Developed By - Aniket Monani
 * Student Number - 301422485
 */
namespace Ex2
{
    class Program
    {
        static void Main(string[] args)
        {
            var mlContext = new MLContext();

            // Load data
            var dataPath = "Student.csv";
            
            var data = mlContext.Data.LoadFromTextFile<StudentData>(dataPath, separatorChar: ',', hasHeader: true);
            // Define pipeline
            var pipeline = mlContext.Transforms.Concatenate("Features", "STG", "SCG", "STR", "LPR", "PEG")
                            .Append(mlContext.Transforms.Conversion.MapValueToKey("Label", "UNS"))
                            .Append(mlContext.Transforms.NormalizeMinMax("Features"))
                            .AppendCacheCheckpoint(mlContext)
                            .Append(mlContext.MulticlassClassification.Trainers.SdcaMaximumEntropy("Label", "Features"))
                            .Append(mlContext.Transforms.Conversion.MapKeyToValue("PredictedLabel"));

            // Train model
            var model = pipeline.Fit(data);

            // Make predictions
            var predictionEngine = mlContext.Model.CreatePredictionEngine<InputData, Prediction>(model);

            // Example prediction
            var input = new InputData
            {
                STG = 0.1f,
                SCG = 0.1f,
                STR = 0.15f,
                LPR = 0.65f,
                PEG = 0.3f
            };

            var prediction = predictionEngine.Predict(input);
            Console.WriteLine($"Predicted Label: {prediction.PredictedLabel}");
        }

        // Define data schema
        public class InputData
        {
            [LoadColumn(0)] public float STG { get; set; }
            [LoadColumn(1)] public float SCG { get; set; }
            [LoadColumn(2)] public float STR { get; set; }
            [LoadColumn(3)] public float LPR { get; set; }
            [LoadColumn(4)] public float PEG { get; set; }
            [LoadColumn(5)] public string ? UNS { get; set; }
        }

        // Define prediction result schema
        public class Prediction
        {
            [ColumnName("PredictedLabel")] public string PredictedLabel { get; set; }
        }
    }
}
