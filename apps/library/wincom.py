import time

import win32con
import win32gui


# 隐藏窗口
def hideWindow(handle):
    win32gui.ShowWindow(handle, win32con.SW_HIDE)


# 显示窗口
def showWindow(handle):
    win32gui.ShowWindow(handle, win32con.SW_SHOW)


# 获取窗口位置
def getWindowPos(handle):
    x, y, _a, _b = win32gui.GetWindowRect(handle)
    return x, y


# 获取窗口宽高
def getWindowSize(handle):
    x, y, w, h = win32gui.GetWindowRect(handle)
    return w - x, h - y


# 获取窗口 handle
def getHandle(name):
    return win32gui.FindWindow(None, name)


# Timer 间隔时间执行指令
class sec_timer:
    _time_las = 0
    interval = 0
    runfunc = None

    def __init__(self, sec, func):
        self.interval = sec
        self.runfunc = func

    def run(self):  # 执行的命令
        if time.time() - self._time_las > self.interval:
            self._time_las = time.time()
            self.runfunc()