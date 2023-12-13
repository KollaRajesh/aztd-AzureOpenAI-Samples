
using System;
using System.Security.AccessControl;
// See https://aka.ms/new-console-template for more information
using Azure;
using Azure.AI.OpenAI;
Environment.
//System.Console.WriteLine(Environment.GetEnvironmentVariable("AZURE_OPENAI_EDAPI"));
OpenAIClient client = new OpenAIClient(
	new Uri(Environment.GetEnvironmentVariable("AZURE_OPENAI_EDAPI")),
	new AzureKeyCredential(Environment.GetEnvironmentVariable("AZURE_OPENAI_EDAPI_KEY")));

 Response<ChatCompletions> responseWithoutStream = await client.GetChatCompletionsAsync(
  deploymentOrModelName:"gpt-35-turbo",
  new ChatCompletionsOptions()
  {
    Messages =
    {
      new ChatMessage(ChatRole.System, @"You are an AI assistant that helps people find information."),
      new ChatMessage(ChatRole.User, @"can you list out  hotels and rate hotels with price details"), 
      new ChatMessage(ChatRole.Assistant, @"Of course, I can help you with that. However, I would need more specific information such as the location and dates of your travel to provide accurate hotel recommendations and price details. Could you please provide me with that information?"),
      new ChatMessage(ChatRole.User, @"can you list out  hotels and rate hotels with price details near by prospect heights"),     
      new ChatMessage(ChatRole.Assistant, @"Sure, here are some hotel recommendations with price details near Prospect Heights, Illinois:

                1. Hilton Garden Inn Lake Forest Mettawa - Starting from $109 per night
                2. Hyatt Regency Deerfield - Starting from $119 per night
                3. Courtyard by Marriott Chicago Deerfield - Starting from $99 per night
                4. La Quinta Inn & Suites Bannockburn-Deerfield - Starting from $89 per night
                5. Red Roof Inn PLUS+ Chicago - Willowbrook - Starting from $79 per night

                Please note that prices may vary depending on the dates of your travel and availability of rooms. It's always a good idea to check multiple booking sites for the best rates."),      
    new ChatMessage(ChatRole.User, @"The system is an AI teacher that helps people learn about AI"),      
    new ChatMessage(ChatRole.Assistant, @"Great! I'm happy to help people learn about AI. What would you like me to teach?"),     
    new ChatMessage(ChatRole.User, @"What are different types of artificial intelligence?"),      
    new ChatMessage(ChatRole.Assistant, @"There are mainly four types of artificial intelligence:

                1. Reactive AI: This type of AI is designed to respond to a particular situation based on the available data, without the ability to form memories or use past experiences to inform future decisions. Examples of reactive AI include chess-playing programs and voice assistants like Siri and Alexa.

                2. Limited Memory AI: This type of AI builds on reactive AI by adding the ability to use past experiences to inform future decisions. Limited memory AI is often used in self-driving cars, which use data from past trips to improve their performance in the future.

                3. Theory of Mind AI: This type of AI is designed to understand the mental states of other agents, including humans. Theory of Mind AI is still largely a theoretical concept, but it could be used in the future to create more intuitive and responsive virtual assistants.

                4. Self-aware AI: This type of AI is the most advanced and hypothetical form of AI, with the ability to form a sense of self and consciousness. Self-aware AI does not currently exist, but it is a popular topic in science fiction and is the subject of ongoing research."),  
    new ChatMessage(ChatRole.User, @"How is it related to machine learning?"),
    new ChatMessage(ChatRole.Assistant, @"Artificial intelligence (AI) and machine learning (ML) are closely related. Machine learning is a subset of AI that focuses on teaching machines how to learn from data, without being explicitly programmed. Machine learning algorithms allow machines to learn from experience, adapt to new data, and make predictions or decisions based on that data.
        In other words, machine learning is the technology that enables artificial intelligence to learn and improve over time. By training a machine learning model with large amounts of data, the model can learn to recognize patterns and make predictions based on new data.

        Many of the most advanced AI systems today are powered by machine learning, including image recognition, speech recognition, and natural language processing systems. In essence, machine learning is a key tool that enables AI to become more intelligent and better at handling complex tasks."),
    },
    Temperature = (float)0.7,
    MaxTokens = 800,


    NucleusSamplingFactor = (float)0.95,
    FrequencyPenalty = 0,
    PresencePenalty = 0,
  });


ChatCompletions response = responseWithoutStream.Value;

