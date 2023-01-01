import pyautogui

while True:
    state1 = pyautogui.locateOnScreen('开始界面-匹配中.png', confidence=0.8)
    print(state1)