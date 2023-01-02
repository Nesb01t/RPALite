import pyautogui
from clientend import winauto
from clientend import timeutils
from clientend import winmain


def run():
    # 开始界面 - 匹配中
    box = pyautogui.locateOnScreen('1.png', confidence=0.85)
    if box is not None:
        stateList = '1'
        winauto.focusClickCenter(box)

    # 游戏中 - 等待结束
    box = pyautogui.locateOnScreen('2.png', confidence=0.7)
    if box is not None:
        stateList = '2'
        winauto.pressSpace()

    # 游戏中 - 确认退出
    box = pyautogui.locateOnScreen('3.png', confidence=0.7)
    if box is not None:
        stateList = '3'
        winauto.focusClickCenter(box)

    # 结算画面 - 点击继续
    box = pyautogui.locateOnScreen('4.png', confidence=0.7)
    if box is not None:
        stateList = '4'
        winauto.focusClickCenter(box)

    print(timeutils.getTime(), stateList)


winmain.mainLoop(run)
