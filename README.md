# Webhook_Spammer
Webhook Spammer by me (TERI#6116) Make sure to give credits! AND NO IT'S NOT SKIDDED

Screenshot:
![ss](https://cdn.discordapp.com/attachments/613066593177436160/823650616240242718/unknown.png)

Same as the spammer, it uses 2 ways to send to the webhook,
```cs
1. System.Net.WebClient().UploadValues(string address, NameValueCollection data)
2. System.Net.HttpClient().PostAsync(string requestUri, HttpContent content)
```
When the 1st way gets an error (just in case), it switches to the 2nd, & then goes back to the 1st.
