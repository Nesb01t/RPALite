import pyautogui
import time


def focusClick(pos_x, pos_y):
    pyautogui.click(pos_x, pos_y)
    pyautogui.click(pos_x, pos_y)


def pressSpace():
    pyautogui.press('space')


while True:
    stateList = 'N/A'
    now_time = time.strftime("%Y-%m-%d %H:%M:%S", time.localtime())

    # 开始界面 - 匹配中
    box = pyautogui.locateOnScreen('1.png', confidence=0.7)
    if box is not None:
        left, top, width, height = box
        x, y = left + width // 2, top + height // 2
        stateList = '1'
        focusClick(x, y)

    # 游戏中 - 等待结束
    box = pyautogui.locateOnScreen('2.png', confidence=0.7)
    if box is not None:
        left, top, width, height = box
        x, y = left + width // 2, top + height // 2
        stateList = '2'
        pressSpace()

    # 游戏中 - 确认退出
    box = pyautogui.locateOnScreen('3.png', confidence=0.7)
    if box is not None:
        left, top, width, height = box
        x, y = left + width // 2, top + height // 2
        stateList = '3'
        focusClick(x, y)

    # 结算画面 - 点击继续
    box = pyautogui.locateOnScreen('4.png', confidence=0.7)
    if box is not None:
        left, top, width, height = box
        x, y = left + width // 2, top + height // 2
        stateList = '4'
        focusClick(x, y)

    # 输出调试信息
    print(now_time, stateList)
