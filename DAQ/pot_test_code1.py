import spidev
import time
import os

# import ptvsd

# Enable remote debugging
# ptvsd.enable_attach(secret = 'stuff', address = ('0.0.0.0', 5657))
# ptvsd.wait_for_attach()
	 
# Open SPI bus
spi = spidev.SpiDev()
spi.open(0,0)

# ptvsd.break_into_debugger()	 
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
delay = 60

# Get a time stamp
gmtime = time.gmtime()
current_time = time.asctime(gmtime)

# Limit the loop 	 
for x in range(0, 5):
	 
	# Read the input voltage
    level = ReadChannel(pot_channel)
    volts = ConvertVolts(level,2)
    temp = ConvertTemp(level,2)
    
    # Print out results
    print "------------------------------------------------"
    print("Level: {} ({}V) {}".format(level,volts,current_time))
    print("Temp: {} ({}V) {}".format(level,temp,current_time))
    
    # Wait before repeating loop
    time.sleep(delay)