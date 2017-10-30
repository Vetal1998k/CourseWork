using System;
using System.Collections.Generic;

//источники информации:
//должностная инструкция по начальнику отдела(БУСЕЛ)  http://busel.org/texts/cat5kh/id5xwzyul.htm

namespace Banking
{
    [Serializable]
    /// <summary>
    /// начальник отдела в финансовой организации
    /// </summary>
    public class Department_head : Leader
    {

        //определение новых статических полей
        static new int minAge = 36;
        //static new string subdivision = "отдел";
        static string definition = "Organisation.Department_head";
        static string[] duties =
        {
            "Дает заключения по проектам документов, поступающих в отдел для согласования вопросов, являющихся предметом деятельности отдела.",
            "Вносит предложения руководству отдела по совершенствованию работы отдела."
        };

        /// <summary>
        /// создание начальника отдела с заполнением личных данных
        /// </summary>
        /// <param name="secondName">фамилия</param>
        /// <param name="firstName">имя</param>
        /// <param name="patronymic">отчество</param>
        /// <param name="position">должность</param>
        /// <param name="address">адрес</param>
        /// <param name="birthDate">год рождения</param>
        public Department_head(string secondName = "Иванов", string firstName = "Иван",
            string patronymic = "Иванович", string position = "Начальник отдела",
            string address = "Восточная Европа", int birthDate = 1991) :
            base(secondName, firstName, patronymic, position, address, birthDate)
        {
            if (DateTime.Today.Year - birthDate > maxAge || DateTime.Today.Year - birthDate < minAge)
                throw new ArgumentException("год рождения не действителен для " + definition);
        }

        //у каждого начальника отдела есть:
        //-заместитель(тоже нач. отдела)
        //-подчиненные(специалисты и зав. сектором)
        //
        //=> должностная инструкция по начальнику отдела(БУСЕЛ)

        /// <summary>
        /// заместитель
        /// </summary>
        public Department_head Deputy;

        /// <summary>
        /// получение подчиненных(руководителей)
        /// </summary>
        public List<Head_of_Sector> GetHeads()
        {
            List<Head_of_Sector> heads = new List<Head_of_Sector>();
            foreach (Employee emp in group)
                if (emp is Head_of_Sector && emp.key.StartsWith(key))
                    heads.Add((Head_of_Sector)emp);
            return heads;
        }

        //у начальника отдела свои обязанности, помимо
        //обязанностей руководителя, поэтому переопределяем метод
        //
        //=> должностная инструкция по начальнику отдела(БУСЕЛ)

        /// <summary>
        /// вывод списка обязанностей в строку
        /// </summary>
        /// <param name="res">контейнер для вывода</param>
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
            return base.ToString(format) + " н. отдела";
        }
    }
}