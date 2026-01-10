# Задание 1
numbers1 = [1, 3, 5, 7, 9, 11, 13, 15, 17, 19]
for i in range(len(numbers1)):
    if numbers1[i] == 3:
        numbers1[i] = 30
print("Задание 1:", numbers1)

# Задание 2
numbers2 = [2, 4, 6, 8, 10]
for i in range(len(numbers2)):
    numbers2[i] = numbers2[i] ** 2
print("Задание 2:", numbers2)

# Задание 3
numbers3 = [4, 7, 1, 9, 3]
max_number = numbers3[0]
for n in numbers3:
    if n > max_number:
        max_number = n
result = max_number / len(numbers3)
print("Задание 3:", result)

#  Задание 4
data = (3, 1, 4, 2)
only_numbers = True
for x in data:
    if not isinstance(x, (int, float)):
        only_numbers = False

if only_numbers:
    data = tuple(sorted(data))
print("Задание 4:", data)

#  Задание 5
products = {
    "Хлеб": 45,
    "Молоко": 80,
    "Сыр": 350,
    "Яблоки": 120
}

min_product = list(products.keys())[0]
max_product = list(products.keys())[0]

for product in products:
    if products[product] < products[min_product]:
        min_product = product
    if products[product] > products[max_product]:
        max_product = product

print("Задание 5:")
print("Минимальная цена:", min_product, products[min_product])
print("Максимальная цена:", max_product, products[max_product])

#  Задание 6
elements = ["a", 1, True, 3.14]
new_dict = {}
for elem in elements:
    new_dict[elem] = elem
print("Задание 6:", new_dict)

# Задание 7
dictionary = {
    "cat": "кот",
    "dog": "собака",
    "apple": "яблоко",
    "book": "книга"
}

rus_word = input("Задание 7. Введите русское слово: ")
found = False

for eng in dictionary:
    if dictionary[eng] == rus_word:
        print("Перевод:", eng)
        found = True

if not found:
    print("Слово не найдено")

# Задание 8
user_choice = input("Задание 8. Ваш выбор: ").lower()
computer_choice = "камень"
print("Компьютер выбрал:", computer_choice)

if user_choice == computer_choice:
    print("Ничья")
elif user_choice == "бумага":
    print("Вы победили")
elif user_choice == "ножницы":
    print("Компьютер победил")
elif user_choice == "ящерица":
    print("Компьютер победил")
elif user_choice == "спок":
    print("Вы победили")
else:
    print("Неверный ввод")

#Задание 9
words = ["яблоко", "груша", "банан", "киви", "апельсин", "ананас"]
word_dict = {}

for word in words:
    letter = word[0]
    if letter not in word_dict:
        word_dict[letter] = []
    word_dict[letter].append(word)

print("Задание 9:", word_dict)

# Задание 10
students = [
    ("Анна", [5, 4, 5]),
    ("Иван", [3, 4, 4]),
    ("Мария", [5, 5, 5])
]

averages = {}
for name, grades in students:
    averages[name] = sum(grades) / len(grades)

best_student = ""
best_score = 0

for name in averages:
    if averages[name] > best_score:
        best_score = averages[name]
        best_student = name

print("Задание 10:")
print(best_student, "имеет наивысший средний балл:", best_score)
