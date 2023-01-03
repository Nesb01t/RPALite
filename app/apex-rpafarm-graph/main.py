import pyautogui
import src.clientend.winauto as winauto
import src.clientend.winmain as winmain
import src.clientend.timeutils as timeutils
import src.datacollect.imagehitbox as ihb


def run():
    # click image
    for clickitem in ihb.imageList('click'):
        box = pyautogui.locateOnScreen(clickitem, confidence=0.8)
        if box is not None:
            winauto.focusClickCenter(box)
    # space image
    for spaceitem in ihb.imageList('space'):
        box = pyautogui.locateOnScreen(spaceitem, confidence=0.8)
        if box is not None:
            winauto.pressSpace()

    # console log
    print(timeutils.getTime(), timeutils.getRuntime())


# run
winmain.mainLoop(run)
