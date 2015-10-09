import spidev
import time
import os
import sqlite3
import sys

# Open SPI bus
spi = spidev.SpiDev()
spi.open(0,0)

vMax = 1.25 # full scale voltage in mv
vRef = 3.30
# Function to read SPI data from MCP3008 chip
# Channel must be an integer 0-7
def ReadChannel(channel):
    adc = spi.xfer2([1,(8+channel)<<4,0])
    data = ((adc[1]&3) << 8) + adc[2]
    return data

# Function to convert data to voltage level,
# rounded to specified number of decimal places.
def ConvertVolts(data,places):
    volts = (data * vRef) / float(1023)
    volts = round(volts,places)
    return volts

# Function to calculate temperature from
# TMP35 data, rounded to specified
# number of decimal places.
def ConvertTemp(data,places):
	 
	# ADC Value (need to apply ref voltage for TMP35 if we want full 
        # scale, highest res)
	# (approx)  Temp  Volts
	#  0          0    0.00
	#  79        25    0.25
	#  157       50    0.50
	#  236       75    0.75
	#  315      100    1.00
	#  393      125    1.25
	 
	temp = ((data * vRef)/float(1023))*100 
	temp = round(temp,places)
	return temp
	 
# Define sensor channels
pot_channel  = 0
	 
# Define delay between readings
delay = 1

# column names
id_col = 'ID'
time_col = 'Time'
date_col = 'DateTime'
level_col = 'Level'
volt_col = 'Volt'
tempc_col = 'TempC'

# Open db connection
sqlite_file = '/home/pi/projects/sqlite1.db'
table_name = 'Temperatures'
conn = sqlite3.connect(sqlite_file)
c = conn.cursor()
 
# Get a time stamp
gmTime = time.gmtime()
strTime = time.asctime(gmTime)
timeStamp = time.time()

# Read the input voltage
level = ReadChannel(pot_channel)
volts = ConvertVolts(level,3)
temp = ConvertTemp(level,2)
    
# Create output sql strings
sql_insert = "INSERT INTO {tn} ({tc}, {dc}, {lc}, {vc}, {tmp}) ".\
        format(tn=table_name, tc=time_col, dc=date_col, lc=level_col, vc=volt_col, tmp=tempc_col)
        
sql_values = "VALUES ({tc}, '{dc}', {lc}, {vc}, {tmp})".\
        format(tc=timeStamp, dc=strTime, lc=level, vc=volts, tmp=temp)
        
sql_string = sql_insert + sql_values

# execute the script, commit changes and disconnect
try:
    c.execute(sql_string)
    conn.commit()
    conn.close()
except: # catch *all* exceptions
    e = sys.exc_info()[0]
    print("Error:{msg}".format(msg=e))

# Wait before repeating loop
time.sleep(delay)

