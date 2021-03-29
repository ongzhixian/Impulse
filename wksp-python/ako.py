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

########################################
# Add data

def add_result(cur):
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

def add_pivot_result(cur):
    sql = "INSERT INTO pivot_result (n, draw, date, is_add) VALUES (?, ?, ?, ?)"
    with open('./data/toto/toto.csv') as csv_file:
        csv_reader = csv.reader(csv_file, delimiter=',')
        line_count = 0
        for row in csv_reader:
            if line_count == 0:
                line_count += 1
                continue # Skip first line
            else:
                print(f'\tDraw [{row[0]}], date [{row[1]}] Numbers: {row[2]} , {row[3]}, {row[4]}, {row[5]}, {row[6]}, {row[7]}, {row[8]}')
                cur.execute(sql, (row[2], row[0], row[1], False))
                cur.execute(sql, (row[3], row[0], row[1], False))
                cur.execute(sql, (row[4], row[0], row[1], False))
                cur.execute(sql, (row[5], row[0], row[1], False))
                cur.execute(sql, (row[6], row[0], row[1], False))
                cur.execute(sql, (row[7], row[0], row[1], False))
                cur.execute(sql, (row[8], row[0], row[1], True))

                line_count += 1
        print(f'Processed {line_count} lines.')

def create_database_from_csv():
    try:
        with sqlite3.connect('./data/toto/toto.sqlite3') as db:
            cur = db.cursor()

            #add_result(cur)
            #add_pivot_result(cur)

            db.commit()
    except sqlite3.OperationalError as ex:
        logging.error(f"[{ex}]; Trying to open database failed.")
    except Exception as ex:
        logging.error(f"[{ex}];")

########################################
# Analysis

def get_total_number_of_games(cur, game_format="all"):
    if game_format == "all":
        sql = "SELECT COUNT(*) 'total_number_of_games' FROM result;"
    if game_format == "old":
        sql = "SELECT COUNT(*) 'total_number_of_games' FROM result WHERE date < '2014-10-07';"
    if game_format == "new":
        sql = "SELECT COUNT(*) 'total_number_of_games' FROM result WHERE date >= '2014-10-07';"

    cur.execute(sql)
    result = cur.fetchone()
    return result[0]

def display_analysis():
    try:
        with sqlite3.connect('./data/toto/toto.sqlite3') as db:
            cur = db.cursor()

            all_games_count = get_total_number_of_games(cur)
            new_games_count = get_total_number_of_games(cur, 'new')
            old_games_count = get_total_number_of_games(cur, 'old')

            logging.info(f"all_games_count: {all_games_count}")
            logging.info(f"new_games_count: {new_games_count}")
            logging.info(f"old_games_count: {old_games_count}")

            # write strategies based on new games



            db.commit()
    except sqlite3.OperationalError as ex:
        logging.error(f"[{ex}]; Trying to open database failed.")
    except Exception as ex:
        logging.error(f"[{ex}];")

if __name__ == '__main__':
    
    setup_logging()

    logging.info("[PROGRAM START]")
    
    # TOTO Analysis using Python 😁
    # create_database_from_csv()
    display_analysis()
    
    logging.info("[PROGRAM END]")
