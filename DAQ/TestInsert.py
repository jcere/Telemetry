import os
import sqlite3
import sys
import time

# column names
id_col = 'ID'
time_col = 'Time'
date_col = 'DateTime'
level_col = 'Level'
volt_col = 'Volt'
tempc_col = 'TempC'

# Get a time stamp
gmTime = time.gmtime()
strTime = time.asctime(gmTime)
timeStamp = time.time()

# Read the input voltage
level = 17
volts = 18
temp = 19

# Define delay between readings
delay = 2

# Open db connection
sqlite_file = '/home/pi/projects/sqlite1.db'
table_name = 'Temperatures'
conn = sqlite3.connect(sqlite_file)
c = conn.cursor()

# Create output sql string
sql_insert = "INSERT INTO {tn} ({tc}, {dc}, {lc}, {vc}, {tmp}) ".\
        format(tn=table_name, tc=time_col, dc=date_col, lc=level_col, vc=volt_col, tmp=tempc_col)
        
sql_values = "VALUES ({tc}, '{dc}', {lc}, {vc}, {tmp})".\
        format(tc=timeStamp, dc=strTime, lc=level, vc=volts, tmp=temp)
        
sql_string = sql_insert + sql_values
print(sql_string)

try:
    c.execute(sql_string)
    conn.commit()
    conn.close()
    print("success")
except: # catch *all* exceptions
    e = sys.exc_info()[0]
    print("Error:{msg}".format(msg=e))

# Wait before repeating loop
time.sleep(delay)
