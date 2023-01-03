import time

startTime = 0


def getTime():
    now_time = time.strftime("%Y-%m-%d %H:%M:%S", time.localtime())
    return now_time


def getRuntime():
    global startTime
    if startTime == 0:
        startTime = time.time()
        return "正在开始运行"
    else:
        runtime_str = '已运行 '
        seconds = int(time.time() - startTime) // 1
        minutes = seconds // 60
        hour = seconds // 3600
        if hour > 0:
            runtime_str += f'{hour:02d} 小时 '
        if minutes > 0:
            runtime_str += f'{minutes:02d} 分钟 '
        runtime_str += f'{seconds:02d} 秒 '
        return runtime_str
