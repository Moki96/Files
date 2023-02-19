using System.Text;

namespace ConsoleApp456
{
    class Program
    {
        const string PATH_TO_FILE = "Notebook2.txt";

        static void Main(string[] args)
        {
            Menu();
        }
        static void Menu()
        {
            ConsoleKeyInfo consoleKeyInfo;
            do
            {
                Console.WriteLine("Введите 1 - чтобы вывести данные на экран");
                Console.WriteLine("Введите 2 - чтобы заполнить данные и добавить новую запись в конце файла");
                Console.WriteLine("Введите 0 - чтобы завершить программу");
                consoleKeyInfo = Console.ReadKey();
                Console.WriteLine();

                switch (consoleKeyInfo.KeyChar)
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
                        Console.WriteLine("Неизвестный пункт меню");
                        break;
                }
            }
            while (consoleKeyInfo.Key != ConsoleKey.D0 && consoleKeyInfo.Key != ConsoleKey.NumPad0);
        }
        static void Input()
        {
            StringBuilder stringBuilder = new StringBuilder();
            int id = 1;
            if (!File.Exists(PATH_TO_FILE))
            {
                File.Create(PATH_TO_FILE).Close();
                Console.WriteLine("Файл создан");
            }
            else
            {
                id = File.ReadAllLines(PATH_TO_FILE).Length + 1;
            }
            Console.WriteLine($"Id {id}: Дата и время добавления записи: {DateTime.Now.ToString()}");
            stringBuilder.Append($"{id++}#");
            stringBuilder.Append($"{DateTime.Now.ToString()}#");
            Console.WriteLine("\nВведите Ф.И.О: ");
            stringBuilder.Append($"{Console.ReadLine()}#");
            Console.WriteLine("Введите возраст: ");
            stringBuilder.Append($"{Console.ReadLine()}#");
            Console.WriteLine("Введите рост: ");
            stringBuilder.Append($"{Console.ReadLine()}#");
            Console.WriteLine("Введите дату рождения: ");
            stringBuilder.Append($"{Console.ReadLine()}#");
            Console.WriteLine("Введите место рождения: ");
            stringBuilder.Append($"{Console.ReadLine()}");
            using (StreamWriter list = new StreamWriter("Notebook.txt", true, Encoding.Unicode))
            {
                list.WriteLine(stringBuilder.ToString());
            }
        }
        static void Print()
        {
            if (!File.Exists(PATH_TO_FILE))
            {
                Console.WriteLine("Файл не существует");
                return;
            }
            else
            { 
            using (StreamReader list2 = new StreamReader(PATH_TO_FILE, Encoding.Unicode))
            {
                string line;
                Console.WriteLine($"{"Id",5}{"Дата и время",20}{"Ф.И.О",15} {"Возраст",15} {"Рост",15} {"Дата Рождения",15} {"Место",20}");
                while ((line = list2.ReadLine()) != null)
                {
                    string[] daty = line.Split('#');
                    Console.WriteLine($"{daty[0],5}{daty[1],20} {daty[2],14} {daty[3],15} {daty[4],15} {daty[5],15} {daty[6],20}");
                }
            }
        }
        }
    }
}