
# 設定查核廠牌(number=財產編號)
def set_brand(number):
    # 查核廠牌
    brand = ""
    #查看財產編號的前四位數字
    if(number[0:4] == '5523'): brand = "國際牌-1853"
    elif(number[0:4] == '1800'): brand = "SANYO-1800"
    else: brand = "國際牌-1856"

    # 回傳查核廠牌
    return brand



# 擴充門市資料(listdata=只有門市名稱和編號，area=地區)
def use_store_db(listdata,area):
    ini_listdata = []
    for index in range(len(listdata[0])):
        ini_listdata.append(['中彰投', area, str(listdata[0][index]),'109-06-30',set_brand(str(listdata[1][index])), str(listdata[1][index]),'0.21','1388','無',' ','無'])
    return ini_listdata



