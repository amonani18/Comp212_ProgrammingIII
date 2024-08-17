using System;
using Microsoft.ML;
using Microsoft.ML.Data;
/*
 * Developed By - Aniket Monani
 * Student Number - 301422485
 */
class Program
{
    static void Main(string[] args)
    {
        // Create MLContext
        var context = new MLContext();
        // Load data
        var dataPath = "insurance.csv";
        var data = context.Data.LoadFromTextFile<InsuranceData>(dataPath, separatorChar: ',', hasHeader: true);
        // Define data preparation and model training pipeline
        var pipeline = context.Transforms.Categorical.OneHotEncoding(new[] {
                new InputOutputColumnPair("SexEncoded", "Sex"),
                new InputOutputColumnPair("SmokerEncoded", "Smoker"),
                new InputOutputColumnPair("RegionEncoded", "Region")
            })
            .Append(context.Transforms.Concatenate("Features", "Age", "Bmi", "Children", "SexEncoded", "SmokerEncoded", "RegionEncoded"))
            .Append(context.Transforms.NormalizeMinMax("Features"))
            .Append(context.Regression.Trainers.Sdca(labelColumnName: "Charges", featureColumnName: "Features"));
        // Train model
        var model = pipeline.Fit(data);
        // Evaluate model
        var predictions = model.Transform(data);
        var metrics = context.Regression.Evaluate(predictions, "Charges");
        Console.WriteLine($"R^2: {metrics.RSquared}");
        Console.WriteLine($"RMSE: {metrics.RootMeanSquaredError}");
        // Save model
        var modelPath = "model.zip";
        context.Model.Save(model, data.Schema, modelPath);
        // Load model and make a prediction
        var loadedModel = context.Model.Load(modelPath, out var schema);
        var predictionEngine = context.Model.CreatePredictionEngine<InsuranceData, InsurancePrediction>(loadedModel);
        // Example prediction
        var input = new InsuranceData { Age = 28, Sex = "male", Bmi = 33, Children = 3, Smoker = "no", Region = "southeast" };
        var prediction = predictionEngine.Predict(input);
        Console.WriteLine($"Predicted Charges: {prediction.PredictedCharges}");
    }
}