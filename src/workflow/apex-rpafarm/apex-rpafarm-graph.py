import pyautogui
import sys
sys.path.append("../../clientend")
sys.path.append("../../datacollect")
import winauto
import timeutils
import winmain
import imageparser as ip


def run():
    # click image
    for clickitem in ip.imageList('click'):
        box = pyautogui.locateOnScreen(clickitem, confidence=0.8)
        if box is not None:
            winauto.focusClickCenter(box)
    # space image
    for spaceitem in ip.imageList('space'):
        box = pyautogui.locateOnScreen(spaceitem, confidence=0.8)
        if box is not None:
            winauto.pressSpace()

    # console log
    print(timeutils.getTime())


# run
winmain.mainLoop(run)
input("Press any key to continue！")
