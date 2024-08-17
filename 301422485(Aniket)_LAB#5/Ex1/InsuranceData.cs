using Microsoft.ML.Data;
/*
 * Developed By - Aniket Monani
 * Student Number - 301422485
 */
public class InsuranceData
{
    [LoadColumn(0)]
    public float Age { get; set; }

    [LoadColumn(1)]
    public string ? Sex { get; set; }

    [LoadColumn(2)]
    public float Bmi { get; set; }

    [LoadColumn(3)]
    public float Children { get; set; }

    [LoadColumn(4)]
    public string ? Smoker { get; set; }

    [LoadColumn(5)]
    public string ? Region { get; set; }

    [LoadColumn(6)]
    public float Charges { get; set; }
}

public class InsurancePrediction
{
    [ColumnName("Score")]
    public float PredictedCharges { get; set; }
}
