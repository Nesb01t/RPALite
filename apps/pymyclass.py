import time
from selenium.webdriver import Firefox
from selenium import webdriver
from selenium.webdriver.firefox.service import Service

# create link
s = Service(r'D:\Application\geckodriver.exe')
driver = webdriver.Firefox(service=s)
driver.get("https://newjwxt.zust.edu.cn/jwglxt/xsxk/zzxkyzb_cxZzxkYzbIndex.html?gnmkdm=N253512&layout=default&su"
           "=1210204126")


def isFull(tr_id):
    item = driver.find_element("id", tr_id)
    full = item.find_element("class name", "full")
    return full.text == "已满"


while True:
    input()
    if isFull("tr_E05EFFAC58C8DDD6E053640C10ACADDD"):
        print("已经满了")
    else:
        print("选课还没满")
