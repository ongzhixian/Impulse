################################################################################
# Modules and functions import statements
################################################################################

import logging
from helpers.app_logging import setup_logging, print_test_log_messages

import csv
import sqlite3

# from modules import *
# from api import *
# from pages import *
# from os import getenv

################################################################################
# Main function
################################################################################

def add_to_database(cur):
    sql = "INSERT INTO result (draw, date, n1, n2, n3, n4, n5, n6, n7) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?)"
    with open('./data/toto/toto.csv') as csv_file:
        csv_reader = csv.reader(csv_file, delimiter=',')
        line_count = 0
        for row in csv_reader:
            if line_count == 0:
                line_count += 1
                continue # Skip first line
            else:
                print(f'\tDraw [{row[0]}], date [{row[1]}] Numbers: {row[2]} , {row[3]}, {row[4]}, {row[5]}, {row[6]}, {row[7]}, {row[8]}')
                cur.execute(sql, (row[0], row[1], row[2], row[3], row[4], row[5], row[6], row[7], row[8] ))
                line_count += 1
        print(f'Processed {line_count} lines.')

def create_database_from_csv():
    try:
        with sqlite3.connect('./data/toto/toto.sqlite3') as db:
            cur = db.cursor()

            add_to_database(cur)

            db.commit()
    except sqlite3.OperationalError as ex:
        logging.error(f"[{ex}]; Trying to open database failed.")
    except Exception as ex:
        logging.error(f"[{ex}];")


if __name__ == '__main__':
    
    setup_logging()
    
    logging.info("[PROGRAM START]")
    
    # TOTO Analysis using Python 😁

    
    logging.info("[PROGRAM END]")
