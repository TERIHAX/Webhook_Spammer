# Webhook Spammer
Webhook Spammer by me (TERI#6116) Make sure to give credits! AND NO IT'S NOT SKIDDED

Screenshot:
![ss](https://cdn.discordapp.com/attachments/818588428685148200/823175617461092372/webhookspammer.png)

It uses 2 ways to send to the webhook,
```cs
1. System.Net.WebClient().UploadValues(string, NameValueCollection)
2. System.Net.HttpClient().PostAsync(string, HttpContent)
```
When the 1st way gets an error because of too many requests, it switches to the 2nd, & then goes back to the 1st.
