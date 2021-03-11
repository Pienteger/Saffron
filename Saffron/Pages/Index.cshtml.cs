using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.ML;
using SaffronML.Model;

namespace Saffron.Pages
{
    public class IndexModel : PageModel
    {
        private readonly PredictionEnginePool<ModelInput, ModelOutput> predictionEnginePool;

        public static string Text { get; set; }
        public static string Sentiment { get; set; }
        public IndexModel(PredictionEnginePool<ModelInput, ModelOutput> predictionEnginePool)
        {
            this.predictionEnginePool = predictionEnginePool;
        }
        public void OnGet()
        {
        }
        private void OnGetAnalyzeSentiment()
        {
            if (string.IsNullOrEmpty(Text)) Sentiment = "Neutral";
            var input = new ModelInput { SentimentText = Text };
            var prediction = predictionEnginePool.Predict(input);
            var sentiment = Convert.ToBoolean(prediction.Prediction) ?
                "Toxic" : "Not Toxic";
            Sentiment = sentiment;
        }
        private async void GetSentiment()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://twinword-emotion-analysis-v1.p.rapidapi.com/analyze/"),
                Headers =
                {
                    { "x-rapidapi-key", "2xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxc" },
                    { "x-rapidapi-host", "twinword-emotion-analysis-v1.p.rapidapi.com" },
                },
                Content = new FormUrlEncodedContent(new Dictionary<string, string>
                {
                    { "text", Text},
                }),
            };

            using var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            Sentiment = await response.Content.ReadAsStringAsync();
        }
    }
}
