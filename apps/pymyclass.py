import time
from selenium.webdriver import Firefox
from selenium import webdriver
from selenium.webdriver.firefox.service import Service

# create link
s = Service(r'D:\Application\geckodriver.exe')
driver = webdriver.Firefox(service=s)
driver.get("https://newjwxt.zust.edu.cn/jwglxt/xsxk/zzxkyzb_cxZzxkYzbIndex.html?gnmkdm=N253512&layout=default&su"
           "=1210204126")

# create tr_dict
tr_dict = {
    "凌紫乔5 周四3-4": "tr_E05E9C4438BFD453E053640C10AC291A",
    "凌紫乔6 周四6-7": "tr_E05E9C4438C3D453E053640C10AC291A",
    "凌紫乔7 周四8-9": "tr_E05D3EA5A37AAF21E053640C10AC7321"
}


# tr_id对应的选课是否已满
def isFull(tr_id):
    item = driver.find_element("id", tr_id)
    full = item.find_element("class name", "full")
    return full.text == "已满"


input()  # 输入任意字符执行
while True:
    time.sleep(2)  # 查询间隔
    button_request = driver.find_element("name", "query")
    if button_request:
        button_request.click()
        for name in tr_dict:
            if tr_dict[name]:
                print(name + "是否可选: TrueTrueTrueTrueTrueTrueTrueTrue")
            else:
                print(name + "是否可选: false")
