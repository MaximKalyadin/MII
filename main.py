import matplotlib.pyplot as plt
import pandas as pd

a = 5
b = 10
c = 15
d = 20
clear_set = []
fuzzy_set = []


def get_function_fuzzy(value):
    if (value <= b) and (value >= a):
        return (value - a) / (b - a)
    elif (value > b) and (value < c):
        return 1
    elif (value >= c) and (value <= d):
        return (d - value) / (d - c)
    else:
        return 0


def init_clear_set():
    for i in range(0, 5):
        element = int(input("element = "))
        clear_set.append(element)
        fuzzy_set.append(get_function_fuzzy(element))
        print(element, get_function_fuzzy(element))


def init_fuzzy_set():
    for i in range(0, 5):
        element = get_function_fuzzy(clear_set[i])
        fuzzy_set.append(element)


def show_fuzzy_set_graph():
    data = {'set': [get_function_fuzzy(a),
                    get_function_fuzzy(b),
                    get_function_fuzzy(c),
                    get_function_fuzzy(d), ]}
    df = pd.DataFrame(data)
    x = [a, b, c, d]
    plt.axis([0, 22, 0, 2])
    plt.plot(x, df)
    plt.legend(data)
    plt.show()


init_clear_set()
# init_fuzzy_set()
# print(a, b, c, d)
# print(clear_set)
# print(fuzzy_set)
show_fuzzy_set_graph()
