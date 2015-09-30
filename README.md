## Project Description ##


My idea is to build a telemetry service to collect data around my home and provide it to a webpage for display.

This will give me a chance to investigate some features of (and gain some practice with) Microsoft's web development stack, and allow me to revisit some of my old electronics skills; by creating a fun project with data. 

Because I like data.

## The Setup ##

I have created a data acquisition module using a Raspberry Pi writing to a SQLite database. The database is available on my home network and is connected to a telemetry service built using ASP.NET MVC/WebAPI, and Entity Framework. To view my data I have also built a simple web page using the default ASP views combined with a JavaScript library called Chart.Js.
