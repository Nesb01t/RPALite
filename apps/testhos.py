import time

import win32api
from win32con import WM_ACTIVATE, WA_CLICKACTIVE

import apps.library.wincom as wc
import apps.library.winunder as wu
from apps.hosleveling import getActualPos

handle = wc.getHandle("《风暴英雄》")


def click():
    win32api.PostMessage(handle, WM_ACTIVATE, WA_CLICKACTIVE, 0)
    win32api.PostMessage(handle, 0x06, 2, 0)
    x1, y1 = getActualPos(1050, 835)
    x2, y2 = getActualPos(1090, 1330)
    x3, y3 = getActualPos(70, 1380)
    wu.click(handle, x1, y1)  # 游戏中途防掉线
    wu.click(handle, x2, y2)  # 游戏结束后进行排队
    wu.click(handle, x3, y3)  # 游戏结算返回主界面


time.sleep(1)
win32api.PostMessage(handle, WM_ACTIVATE, WA_CLICKACTIVE, 0)
win32api.PostMessage(handle, 0x06, 2, 0)
time.sleep(0.07)
click()
