#Note: The openai-python library support for Azure OpenAI is in preview.
#Note: This code sample requires OpenAI Python library version 0.28.1 or lower.
#pip install openai==0.28
#python -u "3.AIPythonCodeGen.py"

import os
import openai

from dotenv import load_dotenv


load_dotenv()  # take environment variables from .env.
#MY_ENV_VAR = os.getenv('MY_ENV_VAR')
#print(MY_ENV_VAR)

openai.api_type = "azure"
openai.api_base = os.getenv("AZURE_OPENAI_EDAPI")
openai.api_version = "2023-07-01-preview"
openai.api_key = os.getenv("AZURE_OPENAI_EDAPI_KEY")

message_text = [
                {"role":"system","content":"You are an AI assistant that helps people find information."},
                {"role":"user","content":"can you list out  hotels and rate hotels with price details"},
                {"role":"assistant","content":"Of course, I can help you with that. However, I would need more specific information such as the location and dates of your travel to provide accurate hotel recommendations and price details. Could you please provide me with that information?"},
                {"role":"user","content":"can you list out  hotels and rate hotels with price details near by prospect heights"},
                {"role":"assistant","content":"Sure, here are some hotel recommendations with price details near Prospect Heights, Illinois:\n\n1. Hilton Garden Inn Lake Forest Mettawa - Starting from $109 per night\n2. Hyatt Regency Deerfield - Starting from $119 per night\n3. Courtyard by Marriott Chicago Deerfield - Starting from $99 per night\n4. La Quinta Inn & Suites Bannockburn-Deerfield - Starting from $89 per night\n5. Red Roof Inn PLUS+ Chicago - Willowbrook - Starting from $79 per night\n\nPlease note that prices may vary depending on the dates of your travel and availability of rooms. It's always a good idea to check multiple booking sites for the best rates."},
                {"role":"user","content":"The system is an AI teacher that helps people learn about AI"},
                {"role":"assistant","content":"Great! I'm happy to help people learn about AI. What would you like me to teach?"},
                {"role":"user","content":"What are different types of artificial intelligence?"},
                {"role":"assistant","content":"There are mainly four types of artificial intelligence:\n \n1. Reactive AI: This type of AI is designed to respond to a particular situation based on the available data, without the ability to form memories or use past experiences to inform future decisions. Examples of reactive AI include chess-playing programs and voice assistants like Siri and Alexa. \n \n 2. Limited Memory AI: This type of AI builds on reactive AI by adding the ability to use past experiences to inform future decisions. Limited memory AI is often used in self-driving cars, which use data from past trips to improve their performance in the future. \n \n  3. Theory of Mind AI: This type of AI is designed to understand the mental states of other agents, including humans. Theory of Mind AI is still largely a theoretical concept, but it could be used in the future to create more intuitive and responsive virtual assistants. \n \n 4. Self-aware AI: This type of AI is the most advanced and hypothetical form of AI, with the ability to form a sense of self and consciousness. Self-aware AI does not currently exist, but it is a popular topic in science fiction and is the subject of ongoing research."},
                {"role":"user","content":"How is it related to machine learning?"},
                {"role":"assistant","content":"Artificial intelligence (AI) and machine learning (ML) are closely related. Machine learning is a subset of AI that focuses on teaching machines how to learn from data, without being explicitly programmed. Machine learning algorithms allow machines to learn from experience, adapt to new data, and make predictions or decisions based on that data.\n \n In other words, machine learning is the technology that enables artificial intelligence to learn and improve over time. By training a machine learning model with large amounts of data, the model can learn to recognize patterns and make predictions based on new data. \n \n Many of the most advanced AI systems today are powered by machine learning, including image recognition, speech recognition, and natural language processing systems. In essence, machine learning is a key tool that enables AI to become more intelligent and better at handling complex tasks."},
                {"role":"user","content":"What is Azure Open Service and why it is related to chat GPT?"}
                ]
while True:
  completion = openai.ChatCompletion.create(
    engine = os.getenv('engine'),
    messages = message_text,
    temperature=0.7,
    max_tokens=800,
    top_p=0.95,
    frequency_penalty=0,
    presence_penalty=0,
    stop=None
  )
  
  '''
  print(completion )
  print("\n\n\n")
  print("Message Prompts & Contents:")
  print(message_text)
  print("\n\n\n")
  ''' 
  response=completion.choices[0].message.content
  print(response)
  message_text.append( {"role":"assistant","content":""+response+""})
  print("\n")
  user_input = input("\033[1;33;40mDo you want to continue (Yes/No)? \033[0m ")
  if user_input.upper() in ['YES', 'NO']:
    if user_input.upper() in ['NO']:
       break
    else: 
        user_input = input("\033[1;32;40mEnter your next question?\033[0m \n")
        message_text.append( {"role":"user","content":""+user_input+""})
        '''         
        print(message_text)
        user_input = input("")
        '''
  else:
    print("Invalid input.\n")
    break

user_input = input("\033[1;33;40mDo you want to see payload of prompts& completions messages? \033[0m ")
if user_input.upper() in ['YES']:
  print("\033[1;33;40m Message Prompts & Completions:\n \033[0m")
  print(message_text)
print("\033[1;32;40mThank you!\033[0m \n")