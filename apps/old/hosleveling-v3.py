import os
import time
import tkinter as tk

import win32api
import win32gui

import apps.lib.winunder as wu
import apps.lib.wincom as wc

handle = wc.getHandle("《风暴英雄》")
time_las = 0
win_visible = True

# basic lib
def getActualPos(x, y):  # 获取相对坐标
    width, height = wc.getWindowSize(handle)
    x = x * (width / 2560)
    y = y * (height / 1440)
    return int(x), int(y)


# runtime lib
def antiAfk():  # 伪线程执行主程序
    # 获取当前窗口, 以便恢复状态
    retail = win32gui.GetForegroundWindow()

    # 确定点击窗口位置
    x, y = wc.getWindowPos(handle)
    x1, y1 = getActualPos(1050, 835)
    x2, y2 = getActualPos(1090, 1330)
    x3, y3 = getActualPos(70, 1380)

    # 点击窗口
    wu.fake_active(handle, False)
    wu.click(handle, x1, y1)  # 游戏中途防掉线
    wu.click(handle, x2, y2)  # 游戏结束后进行排队
    wu.click(handle, x3, y3)  # 游戏结算返回主界面
    if retail:
        wu.fake_active(retail, False)


def showCmd():  # 控制cmd界面
    i = os.system("cls")  # 清屏
    os.system("mode con lines=3 cols=30")
    print(""
          "正在执行..."
          "")


def showWindo():
    window = tk.Tk()
    window.title('hosleveling')
    window.geometry('240x100')

    buttonText = tk.StringVar()
    buttonText.set('显示窗口')

    def ExitWindo():
        wc.showWindow(handle)
        exit(0)

    def buttonClick():
        global win_visible
        if win_visible:
            wc.hideWindow(handle)
            buttonText.set('显示窗口')
            win_visible = False
        else:
            wc.showWindow(handle)
            buttonText.set('隐藏窗口')
            win_visible = True

    label = tk.Label(window, text="程序运行中...", bg='red', font=('荆南麦圆体', 12))
    label.pack(expand=1)

    button = tk.Button(window, textvariable=buttonText, width=16, height=2, font=('荆南麦圆体', 12), command=buttonClick)
    button.pack(expand=1)

    window.protocol('WM_DELETE_WINDOW', ExitWindo)
    window.mainloop()


def main():
    # show window
    showWindo()

    # run thread
    afk_timer = wc.sec_timer(20, antiAfk)  # 每20秒运行一次
    while True:
        flag = afk_timer.run()  # 标志是否运行了
        time.sleep(0.1)

# pyinstaller.exe -F E:\PyAutoPlayer\apps\hosleveling.py
