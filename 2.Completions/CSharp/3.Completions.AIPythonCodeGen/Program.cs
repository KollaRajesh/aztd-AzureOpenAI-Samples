// Note: The Azure OpenAI client library for .NET is in preview.
// Install the .NET library via NuGet: dotnet add package Azure.AI.OpenAI --version 1.0.0-beta.5
using Azure;
using Azure.AI.OpenAI;

OpenAIClient client = new OpenAIClient(
  new Uri(Environment.GetEnvironmentVariable("AZURE_OPENAI_EDAPI")),
  new AzureKeyCredential(Environment.GetEnvironmentVariable("AZURE_OPENAI_EDAPI_KEY")));

  Response<ChatCompletions> responseWithoutStream = await client.GetChatCompletionsAsync(
  "gpt-35-turbo",
  new ChatCompletionsOptions()
  {
    Messages =
    {
      new ChatMessage(ChatRole.System, @"You are a Python developer."),
      new ChatMessage(ChatRole.User, @"Write a Python function named Multiply that multiplies two numeric parameters."),     
      new ChatMessage(ChatRole.Assistant, @"Here's the Python function that multiplies two numeric parameters:

                ```python
                def Multiply(a, b):
                    return a * b
                ```

                You can call this function by passing in two numeric values as arguments:

                ```python
                result = Multiply(5, 10)
                print(result) # Output: 50
                ```

                In the example above, we're calling the `Multiply` function with arguments `5` and `10` and storing the result in a variable called `result`. The `print` function is then used to output the value of `result` which is `50`."),
    new ChatMessage(ChatRole.User, @"Write a Python function named Add that Addition of two numeric parameters.")

    },
    Temperature = (float)0.7,
    MaxTokens = 800,


    NucleusSamplingFactor = (float)0.95,
    FrequencyPenalty = 0,
    PresencePenalty = 0,
  });


ChatCompletions response = responseWithoutStream.Value;
