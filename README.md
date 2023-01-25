# Итоги блока. Выбор специализации

## Поставленная задача

Собрать массив из введённых пользователем в консоль значений. Из значений, длина которых меньше либо равна трём, сформировать новый массив.

## Описание решения

1. Пользователю предлагается ввести элементы массива через консоль. Окончанием формирования массива служит кодовое слово `exit`.

2. Каждое новое значение попадает в массив `arr`, размер массива предварительно увеличивается на единицу.

3. Для формирования итогового массива `newArr` можно было бы использовать тот же принцип - увеличение размера массива на единицу при каждом добавлении в него значения с длиной меньше либо равной трём символам. Но для разнообразия используется другой принцип - требуемые значения составляются в строку, разделителем значений служит набор символов `$$$`. Затем строка делится по данному разделителю через метод `Split`, формируя массив `newArr`. В методе формирования начального массива пришлось исключить ситуацию, когда пользователь вводит этот набор символов. 

## Ссылки

[Блок-схема с алгоритмом решения задачи](algorithm.drawio)

[Файл C# с решением задачи](task/Program.cs)