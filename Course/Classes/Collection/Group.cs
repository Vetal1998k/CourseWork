using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Soap;
using System.Text;
using System.Windows.Forms;

namespace Banking
{

    [Serializable]
    public class Group : IEnumerable<Employee>
    {
        /// <summary>
        /// список подчиненных
        /// </summary>
        List<Employee> emps = new List<Employee>();

        public EmployeeStringFormat format;

        /// <summary>
        /// создание пустой группы
        /// </summary>
        /// <param name="format">формат представления</param>
        public Group(EmployeeStringFormat format)
        {
            this.format = format;
        }

        /// <summary>
        /// создание случайной группы
        /// </summary>
        /// <param name="d">кол-во начальников отдела</param>
        /// <param name="h">кол-во начальников сектора</param>
        /// <param name="s">кол-во специалистов</param>
        /// <param name="fpath">путь к файлу с журналом имен</param>
        /// <param name="ppath">путь к файлу с журналом фамилий</param>
        /// <param name="spath">путь к файлу с журналом отчеств</param>
        /// <param name="format">формат представления</param>
        public Group(
            int d, int h, int s,
            string fpath = "FirstNames.txt",
            string ppath = "Patronymics.txt",
            string spath = "SecondNames.txt",
            EmployeeStringFormat format = EmployeeStringFormat.Console)
        {
            this.format = format;

            // поток чтения списков имен, фамилий, отчеств из
            //локальных файлов
            StreamReader sr = new StreamReader(new FileStream(
                fpath, FileMode.Open));

            //список имен
            List<string> firstNames = new List<string>();
            for (string str = sr.ReadLine(); str != null; str = sr.ReadLine())
                firstNames.Add(str);
            sr.Close();

            //фамилии
            sr = new StreamReader(new FileStream(
                spath, FileMode.Open));
            List<string> secondNames = new List<string>();
            for (string str = sr.ReadLine(); str != null; str = sr.ReadLine())
                secondNames.Add(str);
            sr.Close();

            //отчества
            sr = new StreamReader(new FileStream(
                 ppath, FileMode.Open));
            List<string> patronymics = new List<string>();
            for (string str = sr.ReadLine(); str != null; str = sr.ReadLine())
                patronymics.Add(str);
            sr.Close();

            //дата и генератор случайных чисел нужны для создания
            //случайных служащих
            DateTime now = DateTime.Now;
            Random f = new Random(now.Millisecond + now.Second);

            //добавляем работников циклически, сверху вниз
            //создаем н. отдела и добавляем его
            //для него создаем н. секторов и добавляем их
            //для н. секторов создаем спецов и добавляем их
            //для начальника отдела создаем спецов и добавляем их
            for (int i = 0; i < d; i++)
            {
                //создание случайного служащего
                //на основе загруженых списков
                //текущей даты
                //случайного числа
                Department_head dh = new Department_head(
                    secondNames[f.Next(0, secondNames.Count)],
                    firstNames[f.Next(0, firstNames.Count)],
                    patronymics[f.Next(0, patronymics.Count)],
                    "", "", now.Year - f.Next(36, 46));

                //добваляем сотрудника
                Add(dh);

                for (int j = 0; j < h; j++)
                {

                    Head_of_Sector hs = new Head_of_Sector(
                        secondNames[f.Next(0, secondNames.Count)],
                        firstNames[f.Next(0, firstNames.Count)],
                        patronymics[f.Next(0, patronymics.Count)],
                        "", "", now.Year - f.Next(26, 36));
                    Add(hs, dh.key);

                    for (int k = 0; k < s; k++)
                    {
                        Specialist spec = new Specialist(
                            secondNames[f.Next(0, secondNames.Count)],
                            firstNames[f.Next(0, firstNames.Count)],
                            patronymics[f.Next(0, patronymics.Count)],
                            "", "", now.Year - f.Next(18, 26));
                        Add(spec, hs.key);
                    }
                }
                for (int k = 0; k < s; k++)
                {
                    Specialist spec = new Specialist(
                        secondNames[f.Next(0, secondNames.Count)],
                        firstNames[f.Next(0, firstNames.Count)],
                        patronymics[f.Next(0, patronymics.Count)],
                        "", "", now.Year - f.Next(18, 26));
                    Add(spec, dh.key);
                }
            }
        }

        /// <summary>
        /// прямое взятие по индексу в коллекции
        /// </summary>
        /// <param name="index">индекс</param>
        public Employee this[int index]
        {
            get { return emps[index]; }
        }

        /// <summary>
        /// взятие по ключу в коллекции
        /// </summary>
        /// <param name="key">ключ</param>
        public Employee this[string key]
        {
            get
            {
                foreach (Employee e in emps)
                    if (e.key == key)
                        return e;

                //если ключа нет, возвращаем нулевую ссылку
                return null;
            }
        }

        /// <summary>
        /// поиск сотрудника по фамилии
        /// </summary>
        /// <typeparam name="T">тип искомого сотрудника</typeparam>
        /// <param name="secondname"></param>
        public T FindByName<T>(string secondname)
            where T : Employee
        {
            foreach (Employee e in emps)
                if (e is T && e.SecondName == secondname)
                    return (T)e;

            //если такого сотрудника нет, возвращаем нулевую ссылку
            return null;
        }

        /// <summary>
        /// поиск старшего сотрудника
        /// </summary>
        /// <typeparam name="T">тип искомого сотрудника</typeparam>
        public T FindOldest<T>()
            where T : Employee
        {
            T res = null;
            foreach (Employee e in emps)
                if (e is T && (res == null || res.BirthDate > e.BirthDate))
                    res = (T)e;

            //если сотрудников типа Т вообще нет
            //res не инициализируется, возратится пустая ссылка
            return res;
        }

        /// <summary>
        /// поиск младшего сотрудника
        /// </summary>
        /// <typeparam name="T">тип искомого сотрудника</typeparam>
        public T FindYoungest<T>()
            where T : Employee
        {
            T res = null;
            foreach (Employee e in emps)
                if (e is T && (res == null || res.BirthDate < e.BirthDate))
                    res = (T)e;

            //если сотрудников типа Т вообще нет
            //res не инициализируется, возратится пустая ссылка
            return res;
        }

        /// <summary>
        /// добавление сотрудника в коллекцию
        /// </summary>
        /// <typeparam name="T">тип добавляемого сотрудника</typeparam>
        /// <param name="member">экземпляр</param>
        /// <param name="headkey">
        /// ключ начальника, если его нет,
        /// оставьте ключ пустым</param>
        public void Add<T>(T member, string headkey = "")
            where T : Employee
        {
            //находим уровень начальника
            int headkeylvl = Level(headkey);
            int num = 1;

            //находим сотрудников, что имеют того же начальника
            foreach (Employee emp in emps)
                if (Level(emp.key) == headkeylvl + 1 &&
                    (emp.key.StartsWith(headkey) || headkey == ""))
                    num++;

            //делаем ключ для сотрудника
            member.key = headkey + num + ".";
            //ставим ссылку на эту группу
            member.group = this;
            //добавляем объект в коллекцию
            emps.Add(member);
        }

        /// <summary>
        /// нахождение уровня ключа
        /// </summary>
        /// <param name="key">ключ</param>
        public static int Level(string key)
        {
            //уровень считается по количеству точек
            //в ключе
            int res = 0;
            foreach (char c in key)
                if (c == '.') res++;
            return res;
        }

        /// <summary>
        /// удаление звена в дереве организации
        /// вместе со всеми подчиненными
        /// </summary>
        /// <param name="key">ключ</param>
        public void Remove(string key)
        {
            //предварительное удаление
            int count = 0;
            PreRemove(key, ref count);

            //перемещение удаляемых сотрудников
            //вверх по коллекции
            emps.Sort();
            emps.RemoveRange(0, count);
        }

        /// <summary>
        /// предварительное удаление звена
        /// ключи звена и нисходящих элементов стираются
        /// ключи сотрудников ниже по коллекции сдвигаются вверх
        /// </summary>
        /// <param name="key">ключ</param>
        /// <param name="count">кол-во элементов для удаления</param>
        void PreRemove(string key, ref int count)
        {
            //объект для удаления
            Employee emp = this[key];

            //удаление всех подчиненных руководителя
            if (emp is Leader)
            {
                foreach (Employee e in emps)

                    //у подчиненных ключ не равень ключу 
                    //руководителя, но он включает его в себя
                    if (e.key != key && e.key.StartsWith(key))
                    {
                        e.key = "";
                        count++;
                    }
            }

            //свигаем ключи, объектов, что находятся под emp

            //получаем подключ
            string subkey = emp.key.Substring(0, emp.key.Length - 1);
            subkey = subkey.Substring(0, subkey.LastIndexOf('.') + 1);

            //получаем уровень ключа
            int lvl = Level(key);
            foreach (Employee e in emps)

                //если служащий под emp
                //и содержит подключ
                if (e.key.CompareTo(emp.key) > 0 && e.key.StartsWith(subkey))

                    //сдвигаем его ключ вверх
                    //по уровню ключа
                    MoveUp(ref e.key, lvl);

            //метка пустого ключа, указывающая,
            //что объект нужно удалить
            emp.key = "";

            //количество объектов для удаления увеличивается
            count++;
        }

        /// <summary>
        /// сдвиг ключа вверх по уровню
        /// </summary>
        /// <param name="key">ключ</param>
        /// <param name="level">уровень</param>
        void MoveUp(ref string key, int level)
        {
            //разбиваем ключ
            string[] strnums = key.Substring(0, key.Length - 1).Split('.');
            //выбираем элемент по уровню
            strnums[level - 1] =

                //и ставим значение, меньшее на 1
                (int.Parse(strnums[level - 1]) - 1).ToString();

            //собираем ключ
            string tmp = "";
            foreach (string s in strnums)
                tmp += s + '.';
            key = tmp;
        }

        /// <summary>
        /// к строке(пользовательское представление)
        /// </summary>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            emps.Sort();
            foreach (Employee emp in emps)
                sb.AppendLine(emp.ToString(format));
            return sb.ToString();
        }

        /// <summary>
        /// заполнить элемент управления
        /// группой
        /// </summary>
        /// <param name="tree"></param>
        public void FillTreeView(TreeView tree)
        {
            for (int i = 0; i < emps.Count; i++)
            {
                Employee emp = emps[i];

                //если служащий н. отдела, добавляем в корень
                if (emp is Department_head)
                    tree.Nodes.Add(emp.key, emp.ToString(EmployeeStringFormat.TreeView));

                //если начальник сектора добавляем к корню дерева
                else if (emp is Head_of_Sector)
                    tree.Nodes[((Head_of_Sector)emp).GetHead().key].Nodes.Add(
                        emp.key, emp.ToString(EmployeeStringFormat.TreeView));

                //если спец, сначала определим начальника
                else if (emp is Specialist)
                {
                    Leader l = ((Specialist)emp).GetHead();

                    //если начальник отдела, добавляем на второй уровень
                    if (l is Department_head)
                        tree.Nodes[l.key].Nodes.Add(
                        emp.key, emp.ToString(EmployeeStringFormat.TreeView));

                    //иначе на третий
                    else
                    {
                        Department_head dh = ((Head_of_Sector)(l)).GetHead();
                        tree.Nodes[dh.key].Nodes[l.key].Nodes.Add(
                        emp.key, emp.ToString(EmployeeStringFormat.TreeView));
                    }
                }
            }
        }

        public void Serialize(string filename)
        {
            SoapFormatter sf = new SoapFormatter();
            FileStream fs = new FileStream(filename, FileMode.Create);
            sf.Serialize(fs, emps.ToArray());
            fs.Close();
        }

        public void Deserialize(string filename)
        {
            SoapFormatter sf = new SoapFormatter();
            FileStream fs = new FileStream(filename, FileMode.Open);
            Employee[] es = (Employee[])sf.Deserialize(fs);
            emps = new List<Employee>(es);
            fs.Close();
        }

        //средства перечисления, основанные на коллекции emps

        public IEnumerator<Employee> GetEnumerator()
        {
            return ((IEnumerable<Employee>)emps).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<Employee>)emps).GetEnumerator();
        }
    }
}
