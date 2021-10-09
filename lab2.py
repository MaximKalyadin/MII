import random


min = int(input("маленький = "))
norm = int(input("средний = "))
max = int(input("старый = "))


a1 = 0
b1 = min / 2
c1 = min + 5
print(a1, b1, c1)

a2 = min - 5
b2 = norm / 2
c2 = norm + 5
print(a2, b2, c2)

a3 = norm - 5
b3 = max
c3 = 100
print(a3, b3, c3)

arr = [random.randrange(1, 100) for i in range(20)]

print(arr)


def fuzzy_min(el):
    if (el <= b1 and el >= a1):
        return 1
    elif (el > b1 and el <= c1):
        return ((c1 - el) / (c1 - b1))
    else:
        return 0


def fuzzy_old(el):
    if (el <= b3 and el >= a3):
        return ((el - a3) / (b3 - a3))
    elif (el > b3 and el <= c3):
        return 1
    else:
        return 0


def fuzzy_norm(el):
    if (el <= b2 and el >= a2):
        return ((el - a2)/(b2 - a2))
    elif (el > b2 and el <= c2):
        return ((c2 - el)/(c2 - b2))
    else:
        return 0

massMin = []
massNorm = []
massMax  = []

for i in arr:
    print("значение = ", i,
          "маленький = ", fuzzy_min(i),
          "средний = ", fuzzy_norm(i),
          "старый = ", fuzzy_old(i))