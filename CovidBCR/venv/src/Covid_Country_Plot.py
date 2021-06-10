'''
Covid-19 全球 確診人數、死亡人數、康復人數(以日更新)
只可使用國家搜尋資料
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
fig, ax = plt.subplots(figsize=(12, 6))

# Region
regions = ["Taiwan*", "Japan", "Korea, South", "China", "Germany"]

# 折線圖顏色
colors = dict(zip(
    ["Taiwan*", "Japan", "Korea, South", "China", "Germany"],
    ["#800000", "#D8BFD8", "#BC8F8F", "#2F4F4F", "#D2B48C"]
))

# marker
markers =  dict(zip(
    ["Taiwan*", "Japan", "Korea, South", "China", "Germany"],
    ["^", "o", "*", "s", "|"]
))

def ini_data(data_type):
    if data_type == 1:
        #url = "https://data.humdata.org/hxlproxy/data/download/time_series_covid19_confirmed_global_narrow.csv?dest=data_edit&filter01=merge&merge-url01=https%3A%2F%2Fdocs.google.com%2Fspreadsheets%2Fd%2Fe%2F2PACX-1vTglKQRXpkKSErDiWG6ycqEth32MY0reMuVGhaslImLjfuLU0EUgyyu2e-3vKDArjqGX7dXEBV8FJ4f%2Fpub%3Fgid%3D1326629740%26single%3Dtrue%26output%3Dcsv&merge-keys01=%23country%2Bname&merge-tags01=%23country%2Bcode%2C%23region%2Bmain%2Bcode%2C%23region%2Bsub%2Bcode%2C%23region%2Bintermediate%2Bcode&filter02=merge&merge-url02=https%3A%2F%2Fdocs.google.com%2Fspreadsheets%2Fd%2Fe%2F2PACX-1vTglKQRXpkKSErDiWG6ycqEth32MY0reMuVGhaslImLjfuLU0EUgyyu2e-3vKDArjqGX7dXEBV8FJ4f%2Fpub%3Fgid%3D398158223%26single%3Dtrue%26output%3Dcsv&merge-keys02=%23adm1%2Bname&merge-tags02=%23country%2Bcode%2C%23region%2Bmain%2Bcode%2C%23region%2Bsub%2Bcode%2C%23region%2Bintermediate%2Bcode&merge-replace02=on&merge-overwrite02=on&filter03=explode&explode-header-att03=date&explode-value-att03=value&filter04=rename&rename-oldtag04=%23affected%2Bdate&rename-newtag04=%23date&rename-header04=Date&filter05=rename&rename-oldtag05=%23affected%2Bvalue&rename-newtag05=%23affected%2Binfected%2Bvalue%2Bnum&rename-header05=Value&filter06=clean&clean-date-tags06=%23date&filter07=sort&sort-tags07=%23date&sort-reverse07=on&filter08=sort&sort-tags08=%23country%2Bname%2C%23adm1%2Bname&tagger-match-all=on&tagger-default-tag=%23affected%2Blabel&tagger-01-header=province%2Fstate&tagger-01-tag=%23adm1%2Bname&tagger-02-header=country%2Fregion&tagger-02-tag=%23country%2Bname&tagger-03-header=lat&tagger-03-tag=%23geo%2Blat&tagger-04-header=long&tagger-04-tag=%23geo%2Blon&header-row=1&url=https%3A%2F%2Fraw.githubusercontent.com%2FCSSEGISandData%2FCOVID-19%2Fmaster%2Fcsse_covid_19_data%2Fcsse_covid_19_time_series%2Ftime_series_covid19_confirmed_global.csv"
        url = "Covid_confirmed.csv"
    elif data_type == 2:
        # url = "https://data.humdata.org/hxlproxy/data/download/time_series_covid19_deaths_global_narrow.csv?dest=data_edit&filter01=merge&merge-url01=https%3A%2F%2Fdocs.google.com%2Fspreadsheets%2Fd%2Fe%2F2PACX-1vTglKQRXpkKSErDiWG6ycqEth32MY0reMuVGhaslImLjfuLU0EUgyyu2e-3vKDArjqGX7dXEBV8FJ4f%2Fpub%3Fgid%3D1326629740%26single%3Dtrue%26output%3Dcsv&merge-keys01=%23country%2Bname&merge-tags01=%23country%2Bcode%2C%23region%2Bmain%2Bcode%2C%23region%2Bsub%2Bcode%2C%23region%2Bintermediate%2Bcode&filter02=merge&merge-url02=https%3A%2F%2Fdocs.google.com%2Fspreadsheets%2Fd%2Fe%2F2PACX-1vTglKQRXpkKSErDiWG6ycqEth32MY0reMuVGhaslImLjfuLU0EUgyyu2e-3vKDArjqGX7dXEBV8FJ4f%2Fpub%3Fgid%3D398158223%26single%3Dtrue%26output%3Dcsv&merge-keys02=%23adm1%2Bname&merge-tags02=%23country%2Bcode%2C%23region%2Bmain%2Bcode%2C%23region%2Bsub%2Bcode%2C%23region%2Bintermediate%2Bcode&merge-replace02=on&merge-overwrite02=on&filter03=explode&explode-header-att03=date&explode-value-att03=value&filter04=rename&rename-oldtag04=%23affected%2Bdate&rename-newtag04=%23date&rename-header04=Date&filter05=rename&rename-oldtag05=%23affected%2Bvalue&rename-newtag05=%23affected%2Binfected%2Bvalue%2Bnum&rename-header05=Value&filter06=clean&clean-date-tags06=%23date&filter07=sort&sort-tags07=%23date&sort-reverse07=on&filter08=sort&sort-tags08=%23country%2Bname%2C%23adm1%2Bname&tagger-match-all=on&tagger-default-tag=%23affected%2Blabel&tagger-01-header=province%2Fstate&tagger-01-tag=%23adm1%2Bname&tagger-02-header=country%2Fregion&tagger-02-tag=%23country%2Bname&tagger-03-header=lat&tagger-03-tag=%23geo%2Blat&tagger-04-header=long&tagger-04-tag=%23geo%2Blon&header-row=1&url=https%3A%2F%2Fraw.githubusercontent.com%2FCSSEGISandData%2FCOVID-19%2Fmaster%2Fcsse_covid_19_data%2Fcsse_covid_19_time_series%2Ftime_series_covid19_deaths_global.csv"
        url = "Covid_deaths.csv"
    elif data_type == 3:
        # url = "https://data.humdata.org/hxlproxy/data/download/time_series_covid19_recovered_global_narrow.csv?dest=data_edit&filter01=merge&merge-url01=https%3A%2F%2Fdocs.google.com%2Fspreadsheets%2Fd%2Fe%2F2PACX-1vTglKQRXpkKSErDiWG6ycqEth32MY0reMuVGhaslImLjfuLU0EUgyyu2e-3vKDArjqGX7dXEBV8FJ4f%2Fpub%3Fgid%3D1326629740%26single%3Dtrue%26output%3Dcsv&merge-keys01=%23country%2Bname&merge-tags01=%23country%2Bcode%2C%23region%2Bmain%2Bcode%2C%23region%2Bsub%2Bcode%2C%23region%2Bintermediate%2Bcode&filter02=merge&merge-url02=https%3A%2F%2Fdocs.google.com%2Fspreadsheets%2Fd%2Fe%2F2PACX-1vTglKQRXpkKSErDiWG6ycqEth32MY0reMuVGhaslImLjfuLU0EUgyyu2e-3vKDArjqGX7dXEBV8FJ4f%2Fpub%3Fgid%3D398158223%26single%3Dtrue%26output%3Dcsv&merge-keys02=%23adm1%2Bname&merge-tags02=%23country%2Bcode%2C%23region%2Bmain%2Bcode%2C%23region%2Bsub%2Bcode%2C%23region%2Bintermediate%2Bcode&merge-replace02=on&merge-overwrite02=on&filter03=explode&explode-header-att03=date&explode-value-att03=value&filter04=rename&rename-oldtag04=%23affected%2Bdate&rename-newtag04=%23date&rename-header04=Date&filter05=rename&rename-oldtag05=%23affected%2Bvalue&rename-newtag05=%23affected%2Binfected%2Bvalue%2Bnum&rename-header05=Value&filter06=clean&clean-date-tags06=%23date&filter07=sort&sort-tags07=%23date&sort-reverse07=on&filter08=sort&sort-tags08=%23country%2Bname%2C%23adm1%2Bname&tagger-match-all=on&tagger-default-tag=%23affected%2Blabel&tagger-01-header=province%2Fstate&tagger-01-tag=%23adm1%2Bname&tagger-02-header=country%2Fregion&tagger-02-tag=%23country%2Bname&tagger-03-header=lat&tagger-03-tag=%23geo%2Blat&tagger-04-header=long&tagger-04-tag=%23geo%2Blon&header-row=1&url=https%3A%2F%2Fraw.githubusercontent.com%2FCSSEGISandData%2FCOVID-19%2Fmaster%2Fcsse_covid_19_data%2Fcsse_covid_19_time_series%2Ftime_series_covid19_recovered_global.csv"
        url = "Covid_recovered.csv"
    else:
        raise ValueError

    # 讀檔，只讀取'Country/Region', 'Date', 'Value'三個column
    df = pd.read_csv(url, usecols=['Country/Region', 'Date', 'Value'])
    # 將空值填0
    df = df.fillna(value=0)
    # 刪掉第2列header
    df = df.drop(axis=0, index=0)
    # 將資料型別轉換為日期型別
    df["Date"] = pd.to_datetime(df["Date"])
    return df


# 資料過濾條件
def data_filiter(df):
    Region = df["Country/Region"].isin(regions)
    data_f = Region

    return data_f


# 對資料排序
def race_data_sort(data, input_day):
    # 獲得符合input_day的資料
    dff = data[data['Date']<=input_day].sort_values(by=['Country/Region','Value'], ascending=[True,True])
    # 將Country/Region的值 轉成 str型態
    dff['Country/Region'] = dff['Country/Region'].astype(str)
    # 將Value的值 轉成 float
    dff['Value'] = dff['Value'].astype(float)

    # 將相同Region合併
    dff = dff.groupby(['Country/Region', 'Date'])
    # 計算人數總合
    dff = dff.sum().reset_index()
    # 由於第一次排序無法將資料完整排序，再進行排序
    dff = dff.sort_values(by=['Country/Region', 'Value'], ascending=[True, True])

    return dff


def race_plotchart(input_day):
    # 對資料排序
    dff = race_data_sort(done_confirmed, input_day)

    # 清空畫布
    ax.clear()

    # 折線圖(確診)
    dis = dff['Value'].max() / 100.0

    # 每個地區的值
    value_list = []
    # 計算總人數
    Sum = 0
    # 一次一個地區畫折線圖
    for i in range(0,len(regions)):
        # 依地區取值
        dt = dff[dff["Country/Region"] == regions[i]]
        # 將值轉成list
        value_list = dt["Value"].values.tolist()
        # 折線圖
        ax.plot(np.arange(len(dt["Date"])), value_list ,color=colors[regions[i]],label=regions[i],marker=markers[regions[i]])
        # 人數
        ax.text(np.arange(len(dt["Date"])).max(), value_list[-1], f'{value_list[-1]:,.0f}', size=8, ha='left', va='center')
        # 計算總人數
        Sum = Sum + value_list[-1]


    # 將input_day 轉成 str型態
    datetime_str = np.datetime_as_string(input_day)
    # 小標題
    ax.text(0, 1.1, 'Covid-19 : Confirmed - Deaths - Recovered', transform=ax.transAxes, size=14, color='#777777')

    # 增加日期(只印出前10個字元)
    ax.text(0.12, 0.7, datetime_str[:10], transform=ax.transAxes, color='#777777', size=12, ha='center',va='top')
    # 增加總確診人數
    ax.text(0.12, 0.65, 'Total(con): ' + '{:,.0f}'.format(Sum), transform=ax.transAxes, size=10,color='#777777', ha='center',va='top')

    # 調整橫軸顏色、標籤大小
    ax.tick_params(axis='x', colors='#777777', labelsize=12)
    # 將y軸放到左邊
    ax.yaxis.set_ticks_position('left')
    # 將x軸隱藏
    ax.set_xticks([])

    # 增加格線
    ax.grid(which='major', axis='y', linestyle='-')
    # 取消邊界
    plt.box(False)
    # 顯示圖標
    plt.legend(loc='upper left')


# 執行
dc = ini_data(1)
#dd = ini_data(2)
#dr = ini_data(3)

# 資料過濾(確診)
data_con_filter = data_filiter(dc)
# done為過濾後的資料(確診)
done_confirmed = dc[data_con_filter]

# 資料過濾(死亡)
#data_de_filter = data_filiter(dd)
# done_deaths為過濾後的資料(死亡)
#done_deaths = dd[data_de_filter]

# 資料過濾(康復)
#data_re_filter = data_filiter(dr)
# done_recovered為過濾後的資料(康復)
#done_recovered = dr[data_re_filter]

# 整理Frame數
month = list(set(dc.Date.values))
# 排序時間
month.sort()

# 動畫
animator = animation.FuncAnimation(fig, race_plotchart, frames=month, repeat=False)

# 執行動畫
plt.show()