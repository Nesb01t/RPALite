import time

import win32api
import win32gui

import apps.library.winunder as wu
import apps.library.wincom as wc

handle = wc.getHandle("《风暴英雄》")
time_las = 0


def getActualPos(x, y):
    width, height = wc.getWindowSize(handle)
    x = x * (width / 2560)
    y = y * (height / 1440)
    return int(x), int(y)


def antiAfk():
    # 获取当前窗口, 以便恢复状态
    retail = win32gui.GetForegroundWindow()

    # 确定点击窗口位置
    x, y = wc.getWindowPos(handle)
    x1, y1 = getActualPos(1050, 835)
    x2, y2 = getActualPos(1090, 1330)
    x3, y3 = getActualPos(70, 1380)
    # 点击窗口
    wu.fake_active(handle, True)
    wu.click(handle, x1, y1)  # 游戏中途防掉线
    wu.click(handle, x2, y2)  # 游戏结束后进行排队
    wu.click(handle, x3, y3)  # 游戏结算返回主界面
    if retail:
        wu.fake_active(retail, False)


def main():
    afk_timer = wc.sec_timer(20, antiAfk)
    while True:
        afk_timer.run()
        time.sleep(0.1)

# pyinstaller.exe -F E:\PyAutoPlayer\apps\hosleveling.py
