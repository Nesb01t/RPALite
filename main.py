# from apps.hosleveling import main  # 自动风暴英雄挂箱
from apps.pymyclass import main
if __name__ == '__main__':
    main()

# 默认编译方法
# pyinstaller.exe -F E:\PyAutoPlayer\main.py

# 隐藏窗口台
# pyinstaller.exe -F -w E:\PyAutoPlayer\main.py

# 添加图标
# pyinstaller.exe -F -w -i E:\PyAutoPlayer\apps\res\icon.ico E:\PyAutoPlayer\main.py
