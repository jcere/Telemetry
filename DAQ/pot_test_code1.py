import spidev
import time
import os
import json


# Open SPI bus
spi = spidev.SpiDev()
spi.open(0,0)

# Function to read SPI data from MCP3008 chip
# Channel must be an integer 0-7
def ReadChannel(channel):
	adc = spi.xfer2([1,(8+channel)<<4,0])
	data = ((adc[1]&3) << 8) + adc[2]
	return data
	 
# Function to convert data to voltage level,
# rounded to specified number of decimal places.
def ConvertVolts(data,places):
	volts = (data * 3.3) / float(1023)
	volts = round(volts,places)
	return volts
	 
# Function to calculate temperature from
# TMP36 data, rounded to specified
# number of decimal places.
def ConvertTemp(data,places):
	 
	# ADC Value
	# (approx)  Temp  Volts
	#    0      -50    0.00
	#   78      -25    0.25
	#  155        0    0.50
	#  233       25    0.75
	#  310       50    1.00
	#  465      100    1.50
	#  775      200    2.50
	# 1023      280    3.30
	 
	temp = ((data * 330)/float(1023))-50
	temp = round(temp,places)
	return temp
	 
# Define sensor channels
pot_channel  = 0
	 
# Define delay between readings
delay = 5

# Open file for output
fileOp = 'a'
fileName = 'temperatureData.json'
outputFile = open(fileName, fileOp)

# Limit the loop 	 
for x in range(0, 3):
	 
    # Get a time stamp
    gmTime = time.gmtime()
    currentTime = time.asctime(gmTime) 
    
	# Read the input voltage
    level = ReadChannel(pot_channel)
    volts = ConvertVolts(level,2)
    temp = ConvertTemp(level,2)
    
    # Print out results
    print("Temp: {} ({}C) {}".format(level,temp,currentTime))
    

    #dataArr = [level,volts,temp,currentTime]
    data = { 'level':level, 'volts':volts, 'temp':temp, 'time':currentTime }
    
    # Print results to file
    json.dump(data, outputFile)
    
    # Wait before repeating loop
    time.sleep(delay)


