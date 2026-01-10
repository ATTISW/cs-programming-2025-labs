#Задание номер 1

temp = int(input("Введите температуру: "))
if temp < 20:
    print("Кондиционер включен")
else:
    print("Кондиционер выключен")
#Задание номер 2

month = int(input("Введите номер месяца: "))
seasons = ["Зима", "Весна", "Лето", "Осень","Зима"]
print(seasons[month // 3])
# Задание номер 3

def dog_human(age):
    if age <= 2:
        return age * 10.5
    else:
        return 21 + (age - 2) * 4
while True:
    UsInput = input("Введите возраст собаки")
    if UsInput.isdigit():
        dog_age = int(UsInput)
        if 1 <= dog_age <= 22:
            print(dog_human(dog_age))
            break
        else:
            print("Ошибка: возраст должен быть от 1 до 21 года.")
    else:
        print("Ошибка:Введите целое число.")

# Задание номер 4

num = input("Введите число: ")
total = sum(int(digit) for digit in num)
if total // 3 == 0 and int(num[-1]) // 2 == 0:
    print("Делится на 6")
else:
    print("Не делится на 6")

# Задание номер 5

password = input("Введите пароль: ")
has_upper = any(c.isupper() for c in password)
has_lower = any(c.islower() for c in password)
has_digit = any(c.isdigit() for c in password)
has_special = any(not c.isalnum() for c in password)

errors = []
if len(password) < 8:
    errors.append("Длина менее 8 символов")
if not has_upper:
    errors.append("Нет заглавных букв")
if not has_lower:
    errors.append("Нет строчных букв")
if not has_digit:
    errors.append("нет цифр")
if not has_special:
    errors.append("Нет специальных символов")
if errors:
    print("Пароль надежный. Отсутсвует: ",",".join(errors))
else:
    print("Пароль надежный")

#Задание номер 6

year = int(input("Введите год: "))
if (year // 4 == 0 and year // 100 != 0) or (year // 400 == 0):
    print(f"{year} - високосный год")
else:
    print(f"{year} - невисокосный год")

    #Задание номер 7

    a,b,c = map(int,input("Введите три числа через пробел: ").split())
    min_val = a
    if b < min_val:
        min_val = b
    if c < min_val:
        min_val = c
    print(min_val)


#Задание номер 8

purchanse = float(input("Введите сумму покупки: "))
if purchanse < 1000:
    discount = 0
elif purchanse <= 5000:
    discount = 5
elif purchanse <= 10000:
    discount = 10
else:
    discount = 15
final_price = purchanse * (1- discount / 100)
print(f"Скидка: {discount}%")
print(f"Итоговая сумма: {final_price:.2f}")

#Задание номер 9

hour = int(input("Введите час (0-23): "))
if 0 <= hour <= 5:
    print("Ночь")
if 6 <= hour <= 11:
    print("Утро")
if 12 <= hour <= 17:
    print("День")
else:
    print("Вечер")

#Задание номер 10

def is_prime(n):
    if n < 2:
        return False
    for i in range(2, int(n**0.5) + 1):
        if n // i == 0:
            return False
    return True
while True:
    user_input = input("Введите целое число: ")
    if user_input.lstrip('-').isdigit():
        num = int(user_input)
        if num >= 0:
            print("Простое" if is_prime(num) else "Состовное")
            break
        else:
            print("Число должно быть неотрицительным")
    else:
        print("Ошибка Введите целое число.")