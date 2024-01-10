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
openai.api_base =os.getenv("AZURE_OPENAI_EDAPI") # "https://enterprisedata-openai.openai.azure.com/"
openai.api_version = "2023-07-01-preview"
openai.api_key = os.getenv("AZURE_OPENAI_EDAPI_KEY")

message_text = [{"role":"system","content":"You are a Python developer."},
                {"role":"user","content":"Write a Python function named Multiply that multiplies two numeric parameters."},
                {"role":"assistant","content":"Here's the Python function that multiplies two numeric parameters:\n\n```python\ndef Multiply(a, b):\n    return a * b\n```\n\nYou can call this function by passing in two numeric values as arguments:\n\n```python\nresult = Multiply(5, 10)\nprint(result) # Output: 50\n```\n\nIn the example above, we're calling the `Multiply` function with arguments `5` and `10` and storing the result in a variable called `result`. The `print` function is then used to output the value of `result` which is `50`."},
                {"role":"user","content":"Write a Python function named Add that Addition of two numeric parameters."}
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
  #print(completion)
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
  else:
    print("Invalid input.\n")
    break
user_input = input("\033[1;33;40mDo you want to see payload of prompts& completions messages? \033[0m ")
if user_input.upper() in ['YES']:
  print("\033[1;33;40m Message Prompts & Completions:\n \033[0m")
  print(message_text)
print("\033[1;32;40mThank you!\033[0m \n")