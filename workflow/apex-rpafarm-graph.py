import pyautogui
from clientend import winauto
from clientend import timeutils
from clientend import winmain
from datacollect import imageparser as ip

def run():
    for clickitem in ip.imageList('click'):
        print(clickitem)
    print(timeutils.getTime())


winmain.mainLoop(run)
