import time

import apps.lib.winfront as wf

time_las, afk_time, join_time, fini_time = 0, 0, 0, 0


def antiAfk(sec):  # 游戏中途防掉线
    global time_las, afk_time
    if time_las - afk_time > sec:  # 间隔 sec 秒
        wf.click(1050, 835)  # 2560x1440
        afk_time = time_las


def joinGame(sec):  # 游戏结束后进行排队
    global time_las, join_time
    if time_las - join_time > sec:  # 间隔 sec 秒
        wf.click(1090, 1330)  # 2560x1440
        join_time = time_las


def finishGame(sec):  # 游戏结算返回主界面
    global time_las, fini_time
    if time_las - fini_time > sec:  # 间隔 sec 秒
        wf.click(70, 1380)  # 2560x1440
        fini_time = time_las


if __name__ == '__main__':
    while True:
        time_las = time.time()  # 时间结算
        antiAfk(1)
        joinGame(5)
        finishGame(5)
