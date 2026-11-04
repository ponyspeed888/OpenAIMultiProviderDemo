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
        public static string GROQ_ENDPOINT = "https://api.groq.com/openai/v1/";

#if GEMINIOPENAI
        public static string ModelHigh = "gemini-4-argon";
        public static string ModelMedium = "gemini-3.8-flash";
        public static string ModelLow = "gemini-3.5-flash-lite";


#elif AZUREOPENAI
      /* Azure use deployment name, not model name, for the model parameter in the API call. 
         * The deployment name is set when you create a deployment in Azure OpenAI Studio.
         * You can have multiple deployments for the same model, each with a different deployment name.
         * For example, you can have two deployments of gpt-4o with different names, such as "gpt-4o-deployment1" and "gpt-4o-deployment2".
         * You can then use either deployment name in your API calls to access the same underlying model.
         
         
         * The definition is left blank on purpose, as you will need to set the deployment name for your Azure OpenAI deployment.
         */



#elif GROQOPENAI

        public static string ModelHigh = "llama-3.3-70b-versatile";
        public static string ModelMedium = "openai/gpt-oss-120b" ;
        public static string ModelLow = "openai/gpt-oss-20b";


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

#elif GROQOPENAI
            return Environment.GetEnvironmentVariable("GROQ_API_KEY");

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
#elif GROQOPENAI
               Endpoint = new Uri(GROQ_ENDPOINT)

#endif
            };

            return new OpenAIClient(cred, options);





        }
    }
}
