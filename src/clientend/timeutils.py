import time


def getTime():
    now_time = time.strftime("%Y-%m-%d %H:%M:%S", time.localtime())
    return now_time
