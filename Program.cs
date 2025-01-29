using System.Text;


//Функция записи в словарь
static void AddToDictionary(StringBuilder sbWord, SortedDictionary<string, int> dict)
{
    //Преобразуем в строку
    var key = sbWord.ToString();

    //Если в словаре нет ключа,то создаем со значением 1.
    //Если есть увеличиваем значение на 1
    if (!dict.ContainsKey(key))
        dict[key] = 1;
    else
        dict[key] += 1;
}


//Словарь для подсчета слов 
var dict = new SortedDictionary<string, int>();

//Массив для обработки строки,считанной из файла
var sbLine = new StringBuilder();

//Массив для записи слова,считанного из строки
var sbWord = new StringBuilder();

//Путь до файла
string path = @"C:\Users\Александр\Desktop\Корда\ConsoleApp1\1.txt";

//Считываем файл построчно
StreamReader f = new StreamReader(path);

while (!f.EndOfStream)
{
    //Добавляем строку в StringBuilder 
    sbLine.Append(f.ReadLine());

    //Обработка преобразованной строки
    for (int i = 0; i < sbLine.Length; i++)
    {
        //Если символ явлется буквой добавляем его
        if (char.IsLetter(sbLine[i]))
        {
            sbWord.Append(sbLine[i]);
        }

        //Если нет добавляем слово в словарь и очищаем массив для слова
        else 
        {
            if(sbWord.Length > 0)
            {
                AddToDictionary(sbWord, dict);
                sbWord.Clear();
            }
           
        }
    }
    //В конце проверяем не пустой ли массив.
    //Если нет,то добавляем в словарь.
    
    if (sbWord.Length > 0)
    {
        AddToDictionary(sbWord, dict);
        sbWord.Clear();
    }
    //Очистка массива для считанной строки
    sbLine.Clear();
}
f.Close();


//Записываем данные из словаря в файл
var resultFile= "result.txt";

using (var writer = new StreamWriter(resultFile))
{
    foreach (var person in dict)
    {
        writer.WriteLine($"{person.Key} {person.Value}");
    }
}

