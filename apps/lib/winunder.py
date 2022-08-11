import time

import win32api
import win32com.client
import pythoncom
import win32con
import win32gui

from apps.lib.wincom import hideWindow


def click(hwnd, x, y):
    long_pos = win32api.MAKELONG(x, y)
    win32api.PostMessage(hwnd, win32con.WM_MOUSEMOVE, win32con.MK_LBUTTON, long_pos)
    win32api.PostMessage(hwnd, win32con.WM_LBUTTONDOWN, win32con.MK_LBUTTON, long_pos)
    win32api.PostMessage(hwnd, win32con.WM_MOUSEMOVE, 0000, long_pos)
    win32api.PostMessage(hwnd, win32con.WM_LBUTTONUP, 0000, long_pos)
    win32api.PostMessage(hwnd, win32con.WM_MOUSEMOVE, 0000, long_pos)


def fake_active(hwnd, hide):
    shell = win32com.client.Dispatch("WScript.Shell")
    shell.SendKeys('%')
    win32gui.SetForegroundWindow(hwnd)
    if hide:
        hideWindow(hwnd)
    time.sleep(0.07)
