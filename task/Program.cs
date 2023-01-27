/* Замеры производительности разных решений

string[] genArr()
{
    int len = 100000;
    string[] array = new string[len];
    for (int i = 0; i < len; i ++)
        array[i] = "tst";
    return array;
}

string[] array = genArr();

// Решение через разбивку строки на массив

DateTime dt1 = DateTime.Now;

string elemsStr = "";
string delim    = "$$$";

for (int i = 0; i < array.Length; i ++) 
{
    if (array[i].Length <= 3)
        elemsStr += (elemsStr != "" ? delim : "")+array[i];
}

string[] newArray = elemsStr.Split(delim);

Console.WriteLine((DateTime.Now - dt1).TotalMilliseconds);

// Решение через предварительный просчёт размера массива

DateTime dt2 = DateTime.Now;

int newArraySize  = 0;
int newArrayIndex = 0;

for (int i = 0; i < array.Length; i ++)
    if (array[i].Length <= 3) 
        newArraySize ++;

string[] array1 = new string[newArraySize];

for (int i = 0; i < array.Length; i ++)
    if (array[i].Length <= 3) 
        array1[newArrayIndex ++] = array[i];

Console.WriteLine((DateTime.Now - dt2).TotalMilliseconds);

// Решение через многократное изменение размера массива

DateTime dt3 = DateTime.Now;

string[] array2 = new string[0];

for (int i = 0; i < array.Length; i ++)
{
    if (array[i].Length <= 3) 
    {
        Array.Resize(ref array2, array2.Length + 1);
        array2[array2.Length - 1] = array[i];
    }
}

Console.WriteLine((DateTime.Now - dt3).TotalMilliseconds);

return;

*/


// Разделитель, по которому будем потом разбивать строку для формирования итогового массива
string delimiter = "$$$"; 

// Получает с клавиатуры значения элементов массива
// Массив формируем путём преобразования его размера и добавления нового элемента при каждом вводе значения
string[] BuildArrayFromConsole()
{
    string[] arr = new string[0];

    while (true)
    {        
        Console.Write(arr.Length == 0
            ? "Введите значение элемента массива: "
            : "Введите значение элемента массива (для выхода введите значение \"exit\"): "
        );

        string input = Console.ReadLine() ?? "";

        if (input.Trim() == "")
            Console.WriteLine("Вы ничего не ввели.");
        
        else if (input.Trim().Contains(delimiter))
            Console.WriteLine($"Не используйте, пожалуйста, сочетание символов {delimiter}.");

        else if (input == "exit")
            break;

        else 
        {
            Array.Resize(ref arr, arr.Length + 1);
            arr[arr.Length - 1] = input;
        }

    }
    
    return arr;
}

// Выводит массив в консоль
void PrintArray(string message, string[] arr)
{
    Console.WriteLine($"{message}: ");
    
    Console.WriteLine("{");

    for (int i = 0; i < arr.Length; i ++)
        Console.WriteLine($"    {i}: {arr[i]}");

    Console.WriteLine("}");
}

// Формирует массив, значения которого - это значения массива arr длиной <= 3
// Массив формируем путём разбивки строки
string[] BuildNewArray(string[] arr) {
    
    string elemsStr = "";

    for (int i = 0; i < arr.Length; i ++) 
    {
        if (arr[i].Length <= 3)
            elemsStr += (elemsStr != "" ? delimiter : "")+arr[i];
    }
    
    return elemsStr.Split(delimiter);
}



Console.WriteLine();
Console.WriteLine("================ START ================");
Console.WriteLine();

string[] arr = BuildArrayFromConsole();

Console.WriteLine();

PrintArray("Сформированный массив", arr);

Console.WriteLine();

string[] newArr = BuildNewArray(arr);
if (newArr.Length == 0)
    Console.WriteLine("В массиве нет елементов, длина которых меньше или равна трём символам");
else
    PrintArray("Массив с елементами, длина которых меньше или равна трём символам", newArr);

Console.WriteLine();
Console.WriteLine("================== END ================");
Console.WriteLine();
