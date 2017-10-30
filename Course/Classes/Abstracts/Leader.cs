using System;
using System.Collections.Generic;

namespace Banking
{
    [Serializable]
    /// <summary>
    /// руководитель в финансовой органицзации
    /// </summary>
    public abstract class Leader : Employee
    {

        //переопределения ограничения на возраст
        static new int minAge = 26;
        static new int maxAge = 46;

        //определение подразделения
        static protected string subdivision = "группа";

        //определения собственных полей определения класса
        //и списка обязанностей
        static string definition = "Organisation.Leader";
        static string[] duties =
        {
            "Осуществляет руководство деятельностью подразделения \""+subdivision+"\", организует его работу, принимает решения по вопросам, входящим в его компетенцию, в соответствии с поставленными перед ним задачами.",
            "Участвует в определении и реализации общей политики и стратегии всего подразделения \""+subdivision+"\".",
            "Руководит разработкой (участвует в разработке) проектов инструктивно-методических документов, управленческих решений, входящих в сферу деятельности подразделения \""+subdivision+"\".",
            "Дает распоряжения своим подчиненным и контролирует их выполнение."
        };

        //определяем конструктор со своим возрастным ограничением

        /// <summary>
        /// создание руководителя с заполнением личных данных
        /// </summary>
        /// <param name="secondName">фамилия</param>
        /// <param name="firstName">имя</param>
        /// <param name="patronymic">отчество</param>
        /// <param name="position">должность</param>
        /// <param name="address">адрес</param>
        /// <param name="birthDate">год рождения</param>
        public Leader(string secondName = "Иванов", string firstName = "Иван",
            string patronymic = "Иванович", string position = "Начальник сектора",
            string address = "Восточная Европа", int birthDate = 1991) :
            base(secondName, firstName, patronymic, position, address, birthDate)
        {
            if (DateTime.Today.Year - birthDate > maxAge || DateTime.Today.Year - birthDate < minAge)
                throw new ArgumentException("год рождения не действителен для " + definition);
        }

        //у каждого руководителя есть:
        //-подчиненные(специалисты)
        //
        //=> должностная инструкция по зав. сектором(БУСЕЛ)

        /// <summary>
        /// получить коллекцию подчиненных(специалистов)
        /// </summary>
        public List<Specialist> GetSpecialists()
        {
            List<Specialist> specs = new List<Specialist>();
            foreach (Employee emp in group)

                //подчиненный должен быть специалистом,
                //а также его ключ должен начинаться
                //с ключа руководителя
                if (emp is Specialist && emp.key.StartsWith(key))
                    specs.Add((Specialist)emp);
            return specs;
        }

        //у руководителя свои обязанности, помимо
        //обязанностей служащего, поэтому переопределяем метод
        //
        //=> должностная инструкция по зав. сектором(БУСЕЛ)

        /// <summary>
        /// вывод списка обязанностей в строку
        /// </summary>
        /// <param name="res">пустая строка для ввода</param>
        public override void WriteDuties(ref string res)
        {
            //добавляем обязанности любого служащего
            base.WriteDuties(ref res);

            //добавляем обязанности в конструктор
            foreach (string duty in duties)
                res += duty + "\n";
        }

        /// <summary>
        /// вывод списка подчиненных в строку
        /// </summary>
        /// <param name="res">контейнер для вывода</param>
        public override void WriteSubordinates(ref string res)
        {
            base.WriteSubordinates(ref res);
        }

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
        public override string ToString(EmployeeStringFormat format)
        {
            return base.ToString(format);
        }
    }
}
