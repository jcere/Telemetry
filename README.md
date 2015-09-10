## Project Description ##


My idea is to build a telemetry service to collect data around my home and provide it to a webpage for display.

This will give me a chance to investigate some features of (and gain some practice with) Microsoft's web development stack, and allow me to revisit some of my old electronics skills; by creating a fun project with data. 

Because I like data.

## The Plan ##

First, to collect the data using my Raspberry Pi and make it available on my network. Second, the data will be read by a telemetry service and stored using MS SQLServer, ASP.NET MVC/WebAPI, and Entity Framework. The third device in the chain will be a web API (using the service) that will provide querying and filtering capabilities and reply to requests providing the data as JSON. Finally, I will use a fairly simple web page as the front end (to provide pretty plots) using JavaScript and the D3.js library.

That's the plan anyway.

## In Progress ##

Some experimenting with manipulating the GPIO pins on RPi
A simple web page for displaying data
A service created with the ASP.NET WebAPI scaffolding
Several blog posts that I will (try) to continually update as I go (iterative blogging, is that a thing?)
