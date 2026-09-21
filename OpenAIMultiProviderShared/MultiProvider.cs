using OpenAI;
using System;
using System.ClientModel;
using System.Collections.Generic;
using System.Text;

namespace OpenAIMultiProviderShared
{
    public  class MultiProvider
    {

        #region Constants


        public static string GEMINI_ENDPOINT = "https://generativelanguage.googleapis.com/v1beta/openai/";
        public static string AZURE_ENDPOINT = "https://<resource>.openai.azure.com/openai/v1/";


        #endregion



        public static OpenAIClient GetOpenAIClient(string apiKeyIn)
        {

            ApiKeyCredential cred = new ApiKeyCredential(apiKeyIn);



            OpenAIClientOptions options = new OpenAIClientOptions
            {
#if GEMINIOPENAI
               Endpoint = new Uri(GEMINI_ENDPOINT)
#elif AZUREOPENAI
               Endpoint = new Uri(AZURE_ENDPOINT)
#endif
            };

            return new OpenAIClient(cred, options);





        }
    }
}
