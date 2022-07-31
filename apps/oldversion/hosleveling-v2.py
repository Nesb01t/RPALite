import apps.library.winfront as wf
import apps.library.wincom as wc

time_las, afk_time, join_time, fini_time = 0, 0, 0, 0


def antiAfk():  # 游戏中途防掉线
    wf.click(1050, 835)


def joinGame():  # 游戏结束后进行排队
    wf.click(1090, 1330)


def finishGame():  # 游戏结算返回主界面
    wf.click(70, 1380)


if __name__ == '__main__':
    afk_timer = wc.sec_timer(15, antiAfk)
    join_timer = wc.sec_timer(15, joinGame)
    fini_timer = wc.sec_timer(15, finishGame)
    while True:
        afk_timer.run()
        join_timer.run()
        fini_timer.run()

