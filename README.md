OpenAIMultiProviderDemo

With the early start of Open AI's API, other AI providers try to make their service available using the same API. This project is a demo of how to use multiple AI providers in a single application.

Currently, the following providers are supported: Azure, Gemini,Groq

All providers are supported in the same way, by changing the endpoint URL and by setting different model.  These 2 changed are encapitulate in MultiProvider class, so you can switch between them by defining GEMINIOPENAI, AZUREOPENAI, or GROQOPENAI.


HOW TO USE

1. Add OpenAI package
2. Add OpenAIMultiProviderShared to our solution and reference it in your project.
3. Update the regions "#region Update as needed for your environment to your actual values
4. Define GEMINIOPENAI or AZUREOPENAI or GROQOPENAI compiler directive in your project to switch between providers.  If none is defined, it will be native OpenAI provider.
5. Note Azure OpenAI use deployment name, not model name, so you need to set the model to deployment name in your code.  For example, if you have a deployment named "gpt-35-turbo", you need to set the model to "gpt-35-turbo" instead of "gpt-35-turbo-0301".  The MultiProvider class will handle this for you if you set the model to the deployment name.
6. If you use free account api key, some models won't be availe can cause a runtime error.  Gemini free account for example

