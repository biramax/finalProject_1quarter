
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
