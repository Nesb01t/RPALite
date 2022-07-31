import time

import win32api
import win32com.client
import win32con
import win32gui


def click(hwnd):
    long_pos = win32api.MAKELONG(1090, 1330)
    win32api.PostMessage(hwnd, win32con.WM_MOUSEMOVE, win32con.MK_LBUTTON, long_pos)
    win32api.PostMessage(hwnd, win32con.WM_LBUTTONDOWN, win32con.MK_LBUTTON, long_pos)
    win32api.PostMessage(hwnd, win32con.WM_MOUSEMOVE, 0000, long_pos)
    win32api.PostMessage(hwnd, win32con.WM_LBUTTONUP, 0000, long_pos)
    win32api.PostMessage(hwnd, win32con.WM_MOUSEMOVE, 0000, long_pos)


def fake_active(hwnd):
    shell = win32com.client.Dispatch("WScript.Shell")
    shell.SendKeys('%')
    win32gui.SetForegroundWindow(hwnd)


if __name__ == '__main__':
    time.sleep(1)
    hos_window = win32gui.FindWindow(None, "《风暴英雄》")
    retail_window = win32gui.GetForegroundWindow()

    fake_active(hos_window)
    time.sleep(0.05)
    click(hos_window)
    fake_active(retail_window)
