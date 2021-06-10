import matplotlib.pyplot as plt
import pandas as pd
import numpy as np

'''
宣告變數
,usecols=['Country/Region', 'Date', 'Value']
'''

# 確診總人數list
list_tot_confirmed = []

# 每日確診人數list
list_confirmed = []


# 讀資料
def ini_data():
    #url = "https://data.humdata.org/hxlproxy/data/download/time_series_covid19_confirmed_global_narrow.csv?dest=data_edit&filter01=merge&merge-url01=https%3A%2F%2Fdocs.google.com%2Fspreadsheets%2Fd%2Fe%2F2PACX-1vTglKQRXpkKSErDiWG6ycqEth32MY0reMuVGhaslImLjfuLU0EUgyyu2e-3vKDArjqGX7dXEBV8FJ4f%2Fpub%3Fgid%3D1326629740%26single%3Dtrue%26output%3Dcsv&merge-keys01=%23country%2Bname&merge-tags01=%23country%2Bcode%2C%23region%2Bmain%2Bcode%2C%23region%2Bsub%2Bcode%2C%23region%2Bintermediate%2Bcode&filter02=merge&merge-url02=https%3A%2F%2Fdocs.google.com%2Fspreadsheets%2Fd%2Fe%2F2PACX-1vTglKQRXpkKSErDiWG6ycqEth32MY0reMuVGhaslImLjfuLU0EUgyyu2e-3vKDArjqGX7dXEBV8FJ4f%2Fpub%3Fgid%3D398158223%26single%3Dtrue%26output%3Dcsv&merge-keys02=%23adm1%2Bname&merge-tags02=%23country%2Bcode%2C%23region%2Bmain%2Bcode%2C%23region%2Bsub%2Bcode%2C%23region%2Bintermediate%2Bcode&merge-replace02=on&merge-overwrite02=on&filter03=explode&explode-header-att03=date&explode-value-att03=value&filter04=rename&rename-oldtag04=%23affected%2Bdate&rename-newtag04=%23date&rename-header04=Date&filter05=rename&rename-oldtag05=%23affected%2Bvalue&rename-newtag05=%23affected%2Binfected%2Bvalue%2Bnum&rename-header05=Value&filter06=clean&clean-date-tags06=%23date&filter07=sort&sort-tags07=%23date&sort-reverse07=on&filter08=sort&sort-tags08=%23country%2Bname%2C%23adm1%2Bname&tagger-match-all=on&tagger-default-tag=%23affected%2Blabel&tagger-01-header=province%2Fstate&tagger-01-tag=%23adm1%2Bname&tagger-02-header=country%2Fregion&tagger-02-tag=%23country%2Bname&tagger-03-header=lat&tagger-03-tag=%23geo%2Blat&tagger-04-header=long&tagger-04-tag=%23geo%2Blon&header-row=1&url=https%3A%2F%2Fraw.githubusercontent.com%2FCSSEGISandData%2FCOVID-19%2Fmaster%2Fcsse_covid_19_data%2Fcsse_covid_19_time_series%2Ftime_series_covid19_confirmed_global.csv"
    #df = pd.read_csv(url, header=0)
    file_path = "Covid_confirmed.csv"
    df = pd.read_csv(file_path, header=[0])
    df = df.fillna(value=0)
    # 刪掉第2列header
    df = df.drop(axis=0, index=0)
    # 將資料型別轉換為日期型別
    df["Date"] = pd.to_datetime(df["Date"])

    return df


# 資料過濾條件
def data_filiter(df):
    Region = df["Country/Region"] == "Afghanistan"
    Start_Date = df["Date"] >= "2020/4/22"
    End_Date = df["Date"] <= "2020/4/26"
    Date = Start_Date & End_Date
    data_f = Region & Date

    return data_f

# 計算總人數
def cal_tot_confirmed(df , filter):
   # 將Serios 存成 list
   temp = df.loc[filter, "Value"].values.tolist()
   # str 轉成 int
   temp =  list(map(int, temp))
   return temp

# 計算每日確診人數
def cal_confirmed(df , filter):
   #
   temp_d = []
   # 將Serios 存成 list
   temp = df.loc[filter, "Value"].values.tolist()
   temp = list(map(int, temp))
   for i in range( len(temp)):
       if i == 0:
           num = temp[i]
           continue
       num = num - temp[i]
       temp_d.append(num)
       num = temp[i]

   #temp_d = list(map(str, temp_d))
   return temp_d

# 日期轉換
def datecal():
    # Datetime 轉成 str
    temp = df.loc[data_filter, "Date"].apply(lambda x: x.strftime("%Y-%m-%d"))
    # 存成 list
    temp = temp.values.tolist()
    return temp

# 柱狀圖(直向)
def show_bar_v():
    # (X軸編號,資料(人數),本體顏色,邊框顏色)
    #plt.bar(list_date, list_tot_confirmed, facecolor='#9999ff', edgecolor='white', width=0.4)
    plt.bar(list_date, list_confirmed, facecolor='#9999ff', edgecolor='white', width=0.4)
    # 標籤垂直
    plt.xticks(rotation='vertical')
    # 柱狀圖加上印出數值
    for x, y in zip(list_date, list_confirmed):
        plt.text(x, y, y, va='bottom', ha="center")
    # 柱狀圖加上印出數值
    plt.show()

# 柱狀圖(橫向)
def show_bar_h():
    # (y軸編號,資料(人數),本體顏色,邊框顏色)
    plt.barh(list_date, list_confirmed, facecolor='#EED19C', edgecolor='white')
    # 柱狀圖加上數值
    for x, y in zip(list_date, list_confirmed):
        plt.text(y + 2.0, x, y, va='center', fontsize=9)
    # 柱狀圖加上印出數值
    plt.show()

# 執行
df = ini_data()

# 資料過濾
data_filter = data_filiter(df)

# 計算確診總人數
list_tot_confirmed = cal_tot_confirmed(df , data_filter)

# 計算每日確診人數
list_confirmed = cal_confirmed(df , data_filter)
#由於起始點不會有差值，所以補0，以讓plt可以運作
list_confirmed.append(0)

# 日期轉換
list_date = datecal()

# 反轉list，維持長條圖順序
list_confirmed.reverse()
list_date.reverse()
list_tot_confirmed.reverse()

print(list_tot_confirmed,"\n",list_confirmed,"\n",list_date)
show_bar_v()

























