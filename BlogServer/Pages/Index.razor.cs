using Microsoft.Extensions.ML;
using SaffronML.Model;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace BlogServer.Pages
{
    public partial class Index
    {
        public string Text { get; set; }
        public string Sentiment { get; set; }
        protected override void OnInitialized()
        {
            base.OnInitialized();
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
                    { "x-rapidapi-key", "258d28d81dmshf86a1ae06a9a6fep12d0d3jsn428d6f5b8d3c" },
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
            StateHasChanged();
        }
    }
}
