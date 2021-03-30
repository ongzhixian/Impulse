################################################################################
# Modules and functions import statements
################################################################################

import logging
from helpers.app_logging import setup_logging, print_test_log_messages

import csv
import sqlite3

from pandas import read_csv

# Charting imports
from matplotlib import pyplot
from pandas.plotting import scatter_matrix

# Splitting data 
from sklearn.model_selection import train_test_split

# Machine learning algorithms
from sklearn.linear_model import LogisticRegression
from sklearn.discriminant_analysis import LinearDiscriminantAnalysis
from sklearn.neighbors import KNeighborsClassifier
from sklearn.tree import DecisionTreeClassifier
from sklearn.naive_bayes import GaussianNB
from sklearn.svm import SVC

# Imports needed for model evaluation
from sklearn.model_selection import cross_val_score
from sklearn.model_selection import StratifiedKFold

# Imports needed for evaluating predictions
from sklearn.metrics import classification_report
from sklearn.metrics import confusion_matrix
from sklearn.metrics import accuracy_score


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
# Display dataset info

def print_data_shape(dataset):
    print("Data Shape")
    print("==========")
    print(dataset.shape) # (150, 5) 150 records with 5 fields/record
    print()

def print_top_n_records(dataset, n):
    # Display first 20 records
    print(dataset.head(n))
    print()

def print_dataset_statistics(dataset):
    # Statistical Summary
    print("Data Statistics")
    print("===============")
    print(dataset.describe())
    print()

def print_dataset_distribution(dataset):
    # class distribution
    print(dataset.groupby('classification-name').size()) # display number of records per classification
    print()

########################################
# Display data visualization

def display_box_and_whisker_plot(dataset):
    # box and whisker plots
    dataset.plot(kind='box', subplots=True, layout=(2,2), sharex=False, sharey=False)
    pyplot.show()

def display_histogram(dataset):
    # histograms
    dataset.hist()
    pyplot.show()

def display_scatter_plot(dataset):
    # scatter plot matrix
    scatter_matrix(dataset)
    pyplot.show()


def evaluate_modes(X_train, Y_train):
    models = []
    models.append(('LR',    LogisticRegression(solver='liblinear', multi_class='ovr')))
    models.append(('LDA',   LinearDiscriminantAnalysis()))
    models.append(('KNN',   KNeighborsClassifier()))
    models.append(('CART',  DecisionTreeClassifier()))
    models.append(('NB',    GaussianNB()))
    models.append(('SVM',   SVC(gamma='auto')))

    # evaluate each model in turn
    results = []
    names = []
    for name, model in models:
        kfold = StratifiedKFold(n_splits=10, random_state=1, shuffle=True)
        cv_results = cross_val_score(model, X_train, Y_train, cv=kfold, scoring='accuracy')
        results.append(cv_results)
        names.append(name)
        print('%s: %f (%f)' % (name, cv_results.mean(), cv_results.std()))

    # Compare Algorithms
    pyplot.boxplot(results, labels=names)
    pyplot.title('Algorithm Comparison')
    pyplot.show()

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
    
    # Base on   https://machinelearningmastery.com/machine-learning-in-python-step-by-step/
    #           https://machinelearningmastery.com/index-slice-reshape-numpy-arrays-machine-learning-python/

    setup_logging()

    logging.info("[PROGRAM START]")
    
    # Machine learning (classification) using Python 😁
    # Load data
    # Split data into training and test datasets

    data_file_path = "./data/iris/iris_data.csv"
    data_field_names = ['sepal-length', 'sepal-width', 'petal-length', 'petal-width', 'classification-name']
    dataset = read_csv(data_file_path, names=data_field_names) # Read CSV as dataframe

    #print(str(type(dataset)))

    # Display basic information about dataset
    # print_data_shape(dataset)
    # print_top_n_records(dataset, 20) # Display first 20 records
    # print_dataset_statistics(dataset)
    # print_dataset_distribution(dataset)

    # Data visualization
    # display_box_and_whisker_plot(dataset)
    # display_histogram(dataset)
    # display_scatter_plot(dataset)

    #
    # Split-out validation dataset
    # Split the loaded dataset into two:
    #   80% of which we will use to train, evaluate and select among our models
    #   20% that we will hold back as a validation dataset (test_size)

    # dataset.values
    #[[5.1 3.5 1.4 0.2 'Iris-setosa']
    # ...
    # [5.9 3.0 5.1 1.8 'Iris-virginica']]

    # Cheatsheet for numpy data slicing: array[ <row_from_in>:<row_to_ex> , <col_from_in>:<col_to_ex>  ]
    # array[:]      # all elements in the array.
    # array[0:1]    # subarray with the first element
    # array[-2:]    # subarray with the last two items only
    # array[:, :-1] # all rows and all columns except the last one by specifying ‘:’ for in the rows index, and :-1 in the columns index
    # array[:, -1]  # all rows and just the last column

    # Split loaded data into input variables (X) and the output variable (y).
    array = dataset.values
    X = array[:,0:4]    # 1st 4 columns (0:4) as inputs -- 'sepal-length', 'sepal-width', 'petal-length', 'petal-width'
    y = array[:,4]      # Last column   (4)   as output -- 'classification-name'
    X_train, X_validation, Y_train, Y_validation = train_test_split(X, y, test_size=0.20, random_state=1)

    
    # Test harness
    # We will use stratified 10-fold cross validation to estimate model accuracy.
    # This split our dataset into 10 parts:
    #   train on 9 and 
    #   test on 1 
    # And then repeat for all combinations of train-test splits.
    # Stratified means that each fold or split of the dataset will aim to have 
    # the same distribution of example by class as exist in the whole training dataset.


    # Spot Check Algorithms
    
    
    models = []
    models.append(('LR',    LogisticRegression(solver='liblinear', multi_class='ovr')))
    models.append(('LDA',   LinearDiscriminantAnalysis()))
    models.append(('KNN',   KNeighborsClassifier()))
    models.append(('CART',  DecisionTreeClassifier()))
    models.append(('NB',    GaussianNB()))
    models.append(('SVM',   SVC(gamma='auto')))

    # evaluate each model in turn
    #evaluate_modes(X_train, Y_train)

    # Make predictions on validation dataset
    model = SVC(gamma='auto')
    model.fit(X_train, Y_train)
    predictions = model.predict(X_validation)

    # Evaluate predictions
    print(accuracy_score(Y_validation, predictions))
    print(confusion_matrix(Y_validation, predictions))
    print(classification_report(Y_validation, predictions))

    logging.info("[PROGRAM END]")
