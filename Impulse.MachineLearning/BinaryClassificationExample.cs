using Impulse.Common;
using Microsoft.ML;
using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Microsoft.ML.DataOperationsCatalog;

namespace Impulse.MachineLearning
{
    public class BinaryClassificationExample : IApplication
    {
        // TODO: Move this common somehow...
        private static readonly string entryAssemblyPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
        private static readonly string dataDirectoryPath = System.IO.Path.Combine(entryAssemblyPath, "data");
        private static readonly string dataFileName = @"wikiDetoxAnnotated40kRows.tsv";
        private static readonly string dataFilePath = System.IO.Path.Combine(dataDirectoryPath, dataFileName);
        private static readonly string dataFileSourceUrl = @"https://github.com/dotnet/machinelearning-samples/raw/master/samples/csharp/getting-started/BinaryClassification_SentimentAnalysis/SentimentAnalysis/Data/wikiDetoxAnnotated40kRows.tsv";
  

        public Task Run(string[] args)
        {
            // Get data file if we do not have it; so that we do not have to check in data files
            if (!System.IO.File.Exists(dataFilePath))
            {
                // Download data file

                var wc = new WebClient();
                Console.WriteLine($"Downloading {dataFileName}");
                var download = Task.Run(() => wc.DownloadFile(dataFileSourceUrl, dataFilePath));
                while (!download.IsCompleted)
                {
                    Thread.Sleep(1000);
                    Console.Write(".");
                }
                Console.Write("Download complete");
            }


            return Task.Run(() =>
            {
                // 



                // Create MLContext to be shared across the model creation workflow objects 
                // Set a random seed for repeatable/deterministic results across multiple trainings.
                var mlContext = new MLContext(seed: 1);

                //// STEP 1: Common data loading configuration
                //IDataView dataView = mlContext.Data.LoadFromTextFile<SentimentIssue>(DataPath, hasHeader: true);

                
                //TrainTestData trainTestSplit = mlContext.Data.TrainTestSplit(dataView, testFraction: 0.2);
                //IDataView trainingData = trainTestSplit.TrainSet;
                //IDataView testData = trainTestSplit.TestSet;

                //// STEP 2: Common data process configuration with pipeline data transformations          
                //var dataProcessPipeline = mlContext.Transforms.Text.FeaturizeText(outputColumnName: "Features", inputColumnName: nameof(SentimentIssue.Text));

                //// STEP 3: Set the training algorithm, then create and config the modelBuilder                            
                //var trainer = mlContext.BinaryClassification.Trainers.SdcaLogisticRegression(labelColumnName: "Label", featureColumnName: "Features");
                //var trainingPipeline = dataProcessPipeline.Append(trainer);

                //// STEP 4: Train the model fitting to the DataSet
                //ITransformer trainedModel = trainingPipeline.Fit(trainingData);

                //// STEP 5: Evaluate the model and show accuracy stats
                //var predictions = trainedModel.Transform(testData);
                //var metrics = mlContext.BinaryClassification.Evaluate(data: predictions, labelColumnName: "Label", scoreColumnName: "Score");

                //ConsoleHelper.PrintBinaryClassificationMetrics(trainer.ToString(), metrics);

                //// STEP 6: Save/persist the trained model to a .ZIP file
                //mlContext.Model.Save(trainedModel, trainingData.Schema, ModelPath);

                //Console.WriteLine("The model is saved to {0}", ModelPath);

                //// TRY IT: Make a single test prediction, loading the model from .ZIP file
                //SentimentIssue sampleStatement = new SentimentIssue { Text = "I love this movie!" };

                //// Create prediction engine related to the loaded trained model
                //var predEngine = mlContext.Model.CreatePredictionEngine<SentimentIssue, SentimentPrediction>(trainedModel);

                //// Score
                //var resultprediction = predEngine.Predict(sampleStatement);

                //Console.WriteLine($"=============== Single Prediction  ===============");
                //Console.WriteLine($"Text: {sampleStatement.Text} | Prediction: {(Convert.ToBoolean(resultprediction.Prediction) ? "Toxic" : "Non Toxic")} sentiment | Probability of being toxic: {resultprediction.Probability} ");
                //Console.WriteLine($"================End of Process.Hit any key to exit==================================");

            });
        }

        //public static string GetAbsolutePath(string relativePath)
        //{
        //    FileInfo _dataRoot = new FileInfo(typeof(Program).Assembly.Location);
        //    string assemblyFolderPath = _dataRoot.Directory.FullName;

        //    string fullPath = Path.Combine(assemblyFolderPath, relativePath);

        //    return fullPath;
        //}

        //public static bool Download(string url, string destDir, string destFileName)
        //{
        //    if (destFileName == null)
        //        destFileName = url.Split(Path.DirectorySeparatorChar).Last();

        //    Directory.CreateDirectory(destDir);

        //    string relativeFilePath = Path.Combine(destDir, destFileName);

        //    if (File.Exists(relativeFilePath))
        //    {
        //        Console.WriteLine($"{relativeFilePath} already exists.");
        //        return false;
        //    }

        //    var wc = new WebClient();
        //    Console.WriteLine($"Downloading {relativeFilePath}");
        //    var download = Task.Run(() => wc.DownloadFile(url, relativeFilePath));
        //    while (!download.IsCompleted)
        //    {
        //        Thread.Sleep(1000);
        //        Console.Write(".");
        //    }
        //    Console.WriteLine("");
        //    Console.WriteLine($"Downloaded {relativeFilePath}");

        //    return true;
        //}
    }

    public class SentimentPrediction
    {
        // ColumnName attribute is used to change the column name from
        // its default value, which is the name of the field.
        [ColumnName("PredictedLabel")]
        public bool Prediction { get; set; }

        // No need to specify ColumnName attribute, because the field
        // name "Probability" is the column name we want.
        public float Probability { get; set; }

        public float Score { get; set; }
    }

    public class SentimentIssue
    {
        [LoadColumn(0)]
        public bool Label { get; set; }
        [LoadColumn(2)]
        public string Text { get; set; }
    }

}
