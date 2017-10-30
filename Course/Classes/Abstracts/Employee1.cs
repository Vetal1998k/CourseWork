using System;

//источники информации:
//методичное пособие(с. 8)      https://github.com/Albarn/oop/blob/master/objective.pdf
//БУСЕЛ(информационный портал)  http://busel.org/texts/cat3kz/id5wwofud.htm

namespace Banking
{
    [Serializable]
    /// <summary>
    /// служащий в финансовой организации
    /// </summary>
    public abstract class Employee : IComparable
    {
        //класс служащий в полях должен определить:
        //-ФИО                  (SecondName, FistName, Patronymic)
        //-должность            (Position)
        //-адрес проживания     (Address)
        //-год рождения         (BirthDate)
        //
        //=> методичное пособие

        /// <summary>
        /// Фамилия
        /// </summary>
        public string SecondName;

        /// <summary>
        /// Имя
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Отчество
        /// </summary>
        public string Patronymic { get; set; }

        /// <summary>
        /// Должность
        /// </summary>
        public string Position { get; set; }

        /// <summary>
        /// Адрес проживания
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Год рождения
        /// </summary>
        public int BirthDate { get; set; }

        //определения для связки с группой

        /// <summary>
        /// ключ служащего в группе
        /// </summary>
        public string key;

        [NonSerialized]
        /// <summary>
        /// указатель на группу, в которой
        /// состоит служащий
        /// </summary>
        public Group group;

        //статические данные:
        //ограничения на возраст
        //наименование класса
        //список обязанностей

        protected static int maxAge = 70;
        protected static int minAge = 18;
        static string definition = "Organisation.Employee";
        static string[] duties = {
            "Взаимодействует с органами государственного управления, коммерческими банками, хозяйствующими субъектами, подразделениями Нацбанка РБ по решению вопросов, являющихся предметом деятельности соответствующего подразделения/сектора/отдела."
        };

        /// <summary>
        /// создание служащего с заполнением личных данных
        /// </summary>
        /// <param name="secondName">фамилия</param>
        /// <param name="firstName">имя</param>
        /// <param name="patronymic">отчество</param>
        /// <param name="position">должность</param>
        /// <param name="address">адрес</param>
        /// <param name="birthDate">год рождения</param>
        public Employee(
            string secondName = "Иванов", string firstName = "Иван",
            string patronymic = "Иванович", string position = "Служащий",
            string address = "Восточная Европа", int birthDate = 1991)
        {
            //заполняем поля
            SecondName = secondName;
            FirstName = firstName;
            Patronymic = patronymic;
            Position = position;
            Address = address;

            //проверка на возраст
            if (DateTime.Today.Year - birthDate > maxAge || DateTime.Today.Year - birthDate < minAge)
                throw new ArgumentException("год рождения не действителен для " + definition);
            BirthDate = birthDate;
        }


        //класс служащий должен определить
        //виртуальные методы для вывода:
        //-списка обязанностей  (Duties)
        //-списка подчиненных   (Subordinates)
        //
        //=> методичное пособие

        /// <summary>
        /// вывод списка обязанностей в строку
        /// </summary>
        /// <param name="res">пустая строка для ввода</param>
        public virtual void WriteDuties(ref string res)
        {

            //добавляем строку с единственной обязанностью
            foreach (string duty in duties)
                res += duty + "\n";
        }

        /// <summary>
        /// вывод списка подчиненных в строку
        /// </summary>
        /// <param name="res">контейнер для вывода</param>
        public virtual void WriteSubordinates(ref string res)
        {
            foreach (Employee emp in group)
                if (emp.key.StartsWith(key)) res += emp.ToString() + "\n";
        }

        //дополнительные методы:
        //ToString - вывод информации о работнике в виде строки
        //CompareTo - сравнение служащих по ключу в группе

        /// <summary>
        /// к строке(консольное представление)
        /// </summary>
        public override string ToString()
        {
            return ToString(EmployeeStringFormat.Console);
        }

        /// <summary>
        /// к строке(пользовательское представление)
        /// </summary>
        /// <param name="format">формат представления</param>
        public virtual string ToString(EmployeeStringFormat format)
        {

            //к строке результата прибавляем значения важнейших полей
            string res = "";

            //для каждого варианта формата ставим
            //соответствующий префикс
            switch (format)
            {
                case EmployeeStringFormat.Console:
                    res += key; break;
                case EmployeeStringFormat.ConsoleSimple:
                    {
                        int level = Group.Level(key);
                        if (level > 1)
                            res += new string('-', level - 1);
                        res += '>';
                    }; break;
                    //для TreeView префикса нет
            }

            //добавляем основную часть
            res += SecondName + " " + FirstName[0] + "." +
                Patronymic[0] + ". " + BirthDate;

            return res;
        }

        /// <summary>
        /// сравнение служащих по ключу
        /// </summary>
        /// <param name="obj">служащий</param>
        public int CompareTo(object obj)
        {
            //сравнение происходит только для служащих
            if (!(obj is Employee))
                throw new ArgumentException("нельзя сравнить с объектом");

            //разбиваем ключи
            string[] nums1 = key.Substring(0, key.Length - 1).Split('.');
            string[] nums2 = ((Employee)obj).key.Substring(0,
                ((Employee)obj).key.Length - 1).Split('.');

            //перечисляем компоненты
            for (int i = 0; i < nums1.Length && i < nums2.Length; i++)
            {

                //сравниваем в к-ве чисел, а не строк
                int a = int.Parse(nums1[i]);
                int b = int.Parse(nums2[i]);
                if (a != b)
                    return a - b;
            }

            //если значения совпадают, возвращаем разницу в длинах
            return nums1.Length - nums2.Length;
        }
    }
}

