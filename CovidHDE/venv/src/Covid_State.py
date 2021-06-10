'''
Covid-19 全球 確診人數、死亡人數、康復人數(以日更新)
可使用國家、地區搜尋資料
'''
import matplotlib.pyplot as plt
import pandas as pd
import numpy as np
from matplotlib import animation, rc
from IPython.display import HTML


'''
宣告變數
'''

# 畫布
fig, ax = plt.subplots(figsize=(15, 6))

# 長條圖顏色
colors = dict(zip(
    ["Taiwan*", "Japan","China","Korea, South"],
    ["#FFE4E1", "#D8BFD8" ,"#FAF0E6","#FFC8B4"]
))

def ini_data(data_type):
    if data_type == 1:
        url = "Covid_confirmed.csv"
    elif data_type == 2:
        url = "Covid_deaths.csv"
    elif data_type == 3:
        url = "Covid_recovered.csv"
    else:
        raise ValueError

    # 讀檔，只讀取'Country/Region', 'Date', 'Value'三個column
    df = pd.read_csv(url, usecols=['Province/State','Country/Region', 'Date', 'Value'])
    # 將空值填0
    df = df.fillna(value='-')
    # 刪掉第2列header
    df = df.drop(axis=0, index=0)
    # 將資料型別轉換為日期型別
    df["Date"] = pd.to_datetime(df["Date"])
    return df

# 資料過濾條件
def data_filiter(df):
    Region = df["Country/Region"].isin(["Taiwan*","Japan","Korea, South"])
    Mask1 = df["Country/Region"] == "China"
    State_Mask = df["Province/State" ].isin(["Beijing","Shanghai"])
    State = Mask1 & State_Mask

    data_f = Region | State

    return data_f


# 對資料排序
def race_data_sort(data,input_day):
    # 獲得符合input_day的資料
    dff = data[data['Date'].eq(input_day)].sort_values(by='Value', ascending=True)
    # 將Country/Region的值 轉成 str型態
    dff['Country/Region'] = dff['Country/Region'].astype(str)
    # 將Value的值 轉成 float
    dff['Value'] = dff['Value'].astype(float)

    dff['Province/State'] = dff['Province/State'].astype(str)

    # 由於第一次排序無法將資料完整排序，再進行排序
    dff = dff.sort_values(by="Value", ascending=True)

    return dff

# 長條圖新增人數、人數比例
def race_barh_text(data , dis , y_dis):

    for i, (value, name) in enumerate(zip(data['Value'], data['Country/Region'])):
        # 將人數放到對應的長條旁邊
        ax.text(value + dis, i - y_dis,f'{value:,.0f}',  size=8, ha='left',  va='center')

        # 計算人數比例
        if float(data['Value'].sum()) == 0:
            percent = 0
        else:
            percent = value / float(data['Value'].sum())
            percent = percent * 100.0
        # 將人數比例放到對應的長條旁邊
        ax.text(value + dis, i-(y_dis+0.1), f'{percent:.2f}%' , size=6, ha='left', va='center')


def race_barchart(input_day):

    # 對資料排序
    dff = race_data_sort(done_confirmed,input_day)
    deaths = race_data_sort(done_deaths,input_day)
    recover = race_data_sort(done_recovered,input_day)

    # 清空畫布
    ax.clear()

    # 長條圖
    ax.barh(np.arange(len(dff['Country/Region'])) , dff['Value'], height=0.2,color=[colors[x] for x in dff['Country/Region']],edgecolor='#666666',hatch='/' , label="confiemed")
    ax.barh(np.arange(len(dff['Country/Region']))- 0.3 , deaths['Value'], height=0.2, color=[colors[x] for x in dff['Country/Region']],edgecolor='#666666', hatch='-' , label="deaths")
    ax.barh(np.arange(len(dff['Country/Region'])) - 0.6, recover['Value'], height=0.2,color=[colors[x] for x in dff['Country/Region']], edgecolor='#666666', hatch='+' , label="recovered")

    # 文字距離(確診)
    dis = dff['Value'].max() / 100.0
    for i, (value, name,state) in enumerate(zip(dff['Value'], dff['Country/Region'],dff['Province/State'])):
        # 將每個國家名稱和地區(如果沒地區以'-'代替)放到對應的長條旁邊
        ax.text(0, i, name + ' ' + state, size=12, weight=300, ha='right', va='center')
    # 長條圖新增人數、人數比例
    race_barh_text(dff , dis , 0.0)

    # 文字距離(死亡)
    deaths_dis = dff['Value'].max() / 100.0
    # 長條圖新增人數、人數比例
    race_barh_text(deaths, deaths_dis, 0.3)

    # 文字距離(康復)
    recover_dis = dff['Value'].max() / 100.0
    # 長條圖新增人數、人數比例
    race_barh_text(recover, recover_dis, 0.6)


    # 將input_day 轉成 str型態
    datetime_str = np.datetime_as_string(input_day)
    # 小標題
    ax.text(0, 1.1, 'Covid-19 : Confirmed - Deaths - Recovered', transform=ax.transAxes, size=14, color='#777777')


    # 增加日期(只印出前10個字元)
    ax.text(0.82, 0.15, datetime_str[:10], transform=ax.transAxes, color='#777777', size=12, ha='right')
    # 增加總確診人數
    ax.text(0.82, 0.11, 'Total(con): ' + '{:,.0f}'.format(dff['Value'].sum()), transform=ax.transAxes, size=12,color='#777777', ha='right')
    # 增加總死亡人數
    ax.text(0.82, 0.07, 'Total(de): ' + '{:,.0f}'.format(deaths['Value'].sum()), transform=ax.transAxes, size=12,color='#777777', ha='right')
    # 增加總康復人數
    ax.text(0.82, 0.03, 'Total(re): ' + '{:,.0f}'.format(recover['Value'].sum()), transform=ax.transAxes, size=12,color='#777777', ha='right')


    # 調整橫軸顏色、標籤大小
    ax.tick_params(axis='x', colors='#777777', labelsize=12)
    # 將橫軸放到頂端
    ax.xaxis.set_ticks_position('top')
    # 將y軸隱藏
    ax.set_yticks([])

    # 增加格線
    ax.grid(which='major', axis='x', linestyle='-')
    # 取消邊界
    plt.box(False)
    # 顯示圖標
    plt.legend(loc='lower right')

# 執行
dc = ini_data(1)
dd = ini_data(2)
dr = ini_data(3)


# 資料過濾(確診)
data_con_filter = data_filiter(dc)
# done為過濾後的資料(確診)
done_confirmed = dc[data_con_filter]

# 資料過濾(死亡)
data_de_filter = data_filiter(dd)
# done_deaths為過濾後的資料(死亡)
done_deaths = dd[data_de_filter]

# 資料過濾(康復)
data_re_filter = data_filiter(dr)
# done_recovered為過濾後的資料(康復)
done_recovered  = dr[data_re_filter]


# 整理Frame數
month = list(set(dc.Date.values))
# 排序時間
month.sort()

# 動畫
animator = animation.FuncAnimation(fig, race_barchart, frames=month,repeat=False)

# 執行動畫
plt.show()







