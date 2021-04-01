# Imports
import sqlite3

from impulse_sqlite import test

sqlitedb_path = "C:/Users/zhixian/Documents/PowerShell/impulse.sqlite3"

with sqlite3.connect(sqlitedb_path) as conn:
    cur = conn.cursor()
    cur.execute('''CREATE TABLE stocks5 (date text, trans text, symbol text, qty real, price real)''')
    conn.commit()
