import os
import sqlite3
import sys
import time

# Open db connection
sqlite_file = '/home/pi/projects/sqlite1.db'
conn = sqlite3.connect(sqlite_file)
cur = conn.cursor()

# Create output sql string
sql_create_table = "CREATE TABLE Temperatures (ID INTEGER PRIMARY KEY, Time REAL, Level INTEGER, Volt REAL, TempC REAL, DateTime TEXT);"

try:
    cur.execute(sql_create_table)
    conn.commit()
    conn.close()
    print("Success!")
except: # catch *all* exceptions
    e = sys.exc_info()[0]
    print("Error:{msg}".format(msg=e))


