
# ЗАДАНИЕ 1


value = float(input())
from_unit = input()
to_unit = input()

units = {"s": 1, "m": 60, "h": 3600}

if from_unit in units and to_unit in units:
    result = value * units[from_unit] / units[to_unit]
    print(result)
else:
    print("Error!")



# ЗАДАНИЕ 2


amount = int(input())
years = int(input())

if amount < 30000 or years <= 0:
    print("Error!")
else:
    if years <= 3:
        rate = 0.03
    elif years <= 6:
        rate = 0.05
    else:
        rate = 0.02

    bonus = (amount // 10000) * 0.003
    if bonus > 0.05:
        bonus = 0.05

    rate += bonus

    total = amount
    for i in range(years):
        total += total * rate

    print(round(total - amount, 2))



# ЗАДАНИЕ 3


start = int(input())
end = int(input())

if start > end or end < 2:
    print("Error!")
else:
    found = False
    for num in range(max(2, start), end + 1):
        is_prime = True
        for i in range(2, int(num ** 0.5) + 1):
            if num % i == 0:
                is_prime = False
                break
        if is_prime:
            print(num, end=" ")
            found = True

    if not found:
        print("Error!")



# ЗАДАНИЕ 4


n = int(input())

if n <= 2:
    print("Error!")
else:
    a = []
    b = []

    for i in range(n):
        a.append(list(map(int, input().split())))

    for i in range(n):
        b.append(list(map(int, input().split())))

    for i in range(n):
        for j in range(n):
            print(a[i][j] + b[i][j], end=" ")
        print()



# ЗАДАНИЕ 5
# Палиндром


text = input()

clean = ""
for c in text:
    if c.isalnum():
        clean += c.lower()

if clean == clean[::-1]:
    print("Да")
else:
    print("Нет")
