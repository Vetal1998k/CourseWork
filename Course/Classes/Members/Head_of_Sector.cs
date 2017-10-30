using System;

//источники информации:
//должностная инструкция по зав. сектором(БУСЕЛ)  http://busel.org/texts/cat5kh/id5xwayuf.htm

namespace Banking
{
    [Serializable]
    /// <summary>
    /// начальник сектора в финансовой организации
    /// </summary>
    public class Head_of_Sector : Leader
    {
        //определение новых статических полей
        static new int maxAge = 35;
        static string definition = "Organisation.Head_of_Sector";
        static string[] duties =
        {
            "Вносит предложения руководству отдела (управления) по совершенствованию работы сектора.",
        };

        /// <summary>
        /// создание начальника сектора с заполнением личных данных
        /// </summary>
        /// <param name="secondName">фамилия</param>
        /// <param name="firstName">имя</param>
        /// <param name="patronymic">отчество</param>
        /// <param name="position">должность</param>
        /// <param name="address">адрес</param>
        /// <param name="birthDate">год рождения</param>
        public Head_of_Sector(string secondName = "Иванов", string firstName = "Иван",
            string patronymic = "Иванович", string position = "Начальник сектора",
            string address = "Восточная Европа", int birthDate = 1991) :
            base(secondName, firstName, patronymic, position, address, birthDate)
        {
            if (DateTime.Today.Year - birthDate > maxAge || DateTime.Today.Year - birthDate < minAge)
                throw new ArgumentException("год рождения не действителен для " + definition);
        }

        //у каждого зав. сектором есть:
        //-начальник(отдела)
        //-заместитель(тоже зав. сектором)
        //-подчиненные(специалисты)
        //
        //=> должностная инструкция по зав. сектором(БУСЕЛ)

        /// <summary>
        /// получение начальника(отдела)
        /// </summary>
        public Department_head GetHead()
        {
            foreach (Employee emp in group)
                if (emp is Department_head && key.StartsWith(emp.key))
                    return (Department_head)emp;
            return null;
        }

        /// <summary>
        /// заместитель(зав. сектором)
        /// </summary>
        public Head_of_Sector Deputy;

        //у начальника сектора свои обязанности, помимо
        //обязанностей служащего, поэтому переопределяем метод
        //
        //=> должностная инструкция по зав. сектором(БУСЕЛ)

        /// <summary>
        /// вывод списка обязанностей в строку
        /// </summary>
        /// <param name="res">пустая строка для ввода</param>
        public override void WriteDuties(ref string res)
        {
            //добавляем обязанности любого руководителя
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
            return base.ToString(format) + " н. сектора";
        }
    }
}