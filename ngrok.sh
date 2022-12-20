# Windows non-wsl users, should be ngrok.exe
 ngrok http -host-header=localhost 5000
 
 ngrok http -host-header=localhost https://localhost:44394
 
 
 ngrok http --host-header=rewrite --hostname=abcdef.ngrok.io 3978 
