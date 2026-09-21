OpenAIMultiProviderDemo

With the early start of Open AI's API, other AI providers try to make their service available using the same API. This project is a demo of how to use multiple AI providers in a single application.

Currently, the following providers are supported: Azure, Gemini

Both providers are supported in the same way, by changing the endpoint URL and by setting different model.  These 2 changed is encapitulate in MultiProvider class, so you can switch between them by defining GEMINIOPENAI, AZUREOPENAI.


HOW TO USE

1. Add OpenAI package
2. Add OpenAIMultiProviderShared to our solution and reference it in your project.
3. Update the regions "#region Update as needed for your environment to your actual values
4. Define GEMINIOPENAI or AZUREOPENAI compiler directive in your project to switch between providers.  If none is defined, it will native OpenAI provider.

