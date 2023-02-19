using System.Text;




const string searchedFile = "List of Employees.txt";
menu();

static void menu()
{
    ConsoleKeyInfo key;
    do
    {
        Console.WriteLine("\nВведите 1 - чтобы вывести данные на экран\n" +
            "Введите 2 - чтобы заполнить данные и добавить новую запись в конце файла\n" +
            "Введите 0 - чтобы завершить программу\n");
        
        key = Console.ReadKey();

        switch (key.KeyChar)
        {
            case '0':
                break;
            case '1':
                Print();
                break;
            case '2':
                Input();
                break;
            default:
                Console.WriteLine("Некорректный выбор. Повторите попытку.");
                break;
        }
    }
    while (key.Key != ConsoleKey.D0 && key.Key != ConsoleKey.NumPad0);

}

static void Input()
{
    StringBuilder newStringBuilder = new StringBuilder();
    int ID = 1;

    if(!File.Exists(searchedFile))
    {
        File.Create(searchedFile).Close();
        Console.WriteLine("Файл List of Employees.txt создан");
    }
    else
    {
        ID = File.ReadAllLines(searchedFile).Length;
    }
    Console.WriteLine($" ID {ID}: Дата и время добавления записи : {DateTime.Now.ToString()} ");
    newStringBuilder.Append($"{ID++}#");
    newStringBuilder.Append($"{DateTime.Now.ToString()}#");
    Console.WriteLine("\nВведите ФИО сотрудника:");
    newStringBuilder.Append($"{Console.ReadLine()}#");
    Console.WriteLine("\nВведите возраст:");
    newStringBuilder.Append($"{Console.ReadLine()}#");
    Console.WriteLine("\nВведите рост:");
    newStringBuilder.Append($"{Console.ReadLine()}#");
    Console.WriteLine("Введите дату рождения: ");
    newStringBuilder.Append($"{Console.ReadLine()}#");
    Console.WriteLine("Введите место рождения: ");
    newStringBuilder.Append($"{Console.ReadLine()}");

    using(StreamWriter list = new StreamWriter("List of Employees.txt", true , Encoding.Unicode))
    {
        list.WriteLine(newStringBuilder.ToString());
    }



}


static void Print()
{
    if (!File.Exists(searchedFile))
    {
        Console.WriteLine("Файл не существует");
        return;
    }
    else
    {
        using (var printText = new StreamReader(searchedFile, Encoding.Unicode))
        {
            string line;
         Console.WriteLine($"{"id",5} {"Дата и время",20}{"Ф.И.О",20} {"Возраст",15} {"Рост",15} {"Дата Рождения",15} {"Место",20}");
            Console.WriteLine("");

            while ((line = printText.ReadLine()) != null)
            {
                string[] daty = line.Split('#');
                Console.WriteLine($"{daty[0],5}{daty[1],20} {daty[2],20} {daty[3],15} {daty[4],15} {daty[5],15} {daty[6],20}");
            }
        }
    }
}
