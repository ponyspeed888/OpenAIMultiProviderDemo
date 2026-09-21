using OpenAI;
using System;
using System.ClientModel;
using System.Collections.Generic;
using System.Text;

namespace OpenAIMultiProviderShared
{
    public  class MultiProvider
    {

        #region Update as needed for your environment


        public static string GEMINI_ENDPOINT = "https://generativelanguage.googleapis.com/v1beta/openai/";
        public static string AZURE_ENDPOINT = "https://<resource>.openai.azure.com/openai/v1/";

#if GEMINIOPENAI

#elif AZUREOPENAI


#else
        public static string ModelHigh = "gpt-4o";
        public static string ModelMedium = "gpt-4o";
        public static string ModelLow = "gpt-4o";

#endif



        public static string GetApiKey()
        {

#if GEMINIOPENAI
            return Environment.GetEnvironmentVariable("GEMINI_API_KEY");

#elif AZUREOPENAI
            return Environment.GetEnvironmentVariable("AZURE_API_KEY");


#else
            return Environment.GetEnvironmentVariable("OPENAI_API_KEY");
#endif


        }

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
