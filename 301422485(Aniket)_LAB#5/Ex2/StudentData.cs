using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * Developed By - Aniket Monani
 * Student Number - 301422485
 */
namespace Ex2
{
    public class StudentData
    {
        [LoadColumn(0)]
        public float STG { get; set; }
        [LoadColumn(1)]
        public float SCG { get; set; }
        [LoadColumn(2)]
        public float STR { get; set; }
        [LoadColumn(3)]
        public float LPR { get; set; }
        [LoadColumn(4)]
        public float PEG { get; set; }
        [LoadColumn(5)]
        public string ? UNS { get; set; }
    }
    public class StudentPrediction
    {
        [ColumnName("PredictedLabel")]
        public float ? PredictedLabel { get; set; }
    }

}
