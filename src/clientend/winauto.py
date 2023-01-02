import pydirectinput


def focusClick(pos_x, pos_y):
    last_x, last_y = pydirectinput.position()
    pydirectinput.click(pos_x, pos_y)
    pydirectinput.moveTo(last_x, last_y)


def focusClickCenter(box):
    left, top, width, height = box
    pos_x, pos_y = left + width // 2, top + height // 2
    last_x, last_y = pydirectinput.position()
    pydirectinput.click(pos_x, pos_y)
    pydirectinput.moveTo(last_x, last_y)


def pressSpace():
    pydirectinput.press('space')
