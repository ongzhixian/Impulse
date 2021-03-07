################################################################################
# Modules and functions import statements
################################################################################

import logging as log

import numpy
from scipy import stats
import matplotlib.pyplot as plt

from helpers.app_logging import setup_logging, print_test_log_messages


################################################################################
# Main function
################################################################################

if __name__ == '__main__':
    setup_logging()
    log.info("[PROGRAM START]")
    
    speed = [99,86,87,88,111,86,103,87,94,78,77,85,86]

    x = [5,7,8,7,2,17,2,9,4,11,12,9,6]
    y = [99,86,87,88,111,86,103,87,94,78,77,85,86]

    
    x_mean = numpy.mean(speed)
    x_median = numpy.median(speed)
    x_mode = stats.mode(speed).mode[0] 
    x_mode_count = stats.mode(speed).count[0]
    x_stddev = numpy.std(speed)
    x_variance = numpy.var(speed)
    x_percentile = numpy.percentile(speed, 75)
    x_random = numpy.random.uniform(0.0, 5.0, 100000)
    x_normal = numpy.random.normal(5.0, 1.0, 100000)




    log.info(f"mean: {x_mean}, median: {x_median}, mode: {x_mode} (x{x_mode_count})")
    log.info(f"stdDev: {x_stddev}, variance: {x_variance}, pct: {x_percentile}")

    #log.info(x_random)
    #log.info(x_normal)

    #plt.hist(x_random, 100)
    # plt.hist(x_normal, 100)
    # plt.show()

    # x = numpy.random.normal(5.0, 1.0, 1000)
    # y = numpy.random.normal(10.0, 2.0, 1000)

    plt.scatter(x, y)
    plt.show()
    
    log.info("[PROGRAM END]")