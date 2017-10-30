using System;

namespace Banking
{
    //источники информации:
    //должностная инструкция по специалисту(БУСЕЛ)  http://busel.org/texts/cat5vk/id5awefum.htm

    [Serializable]
    /// <summary>
    /// специалист в финансовой организации
    /// </summary>
    public class Specialist : Employee
    {

        //определение новых статических полей
        protected static new int maxAge = 25;
        protected static new int minAge = 18;
        static string definition = "Organisation.Specialist";
        static string[] duties = {
            "Осуществляет подготовку предложений при разработке проектов нормативных и методических документов.",
            "Производит сбор, систематизацию, учет и анализ статистических, информационно-методических и других материалов, необходимых для выполнения определенной работы или отдельных заданий.",
            "Систематизирует и обобщает нормативные и методические документы, формирует банк данных.",
            "В пределах своей компетенции и по поручению руководства участвует в изучении, проверке, контроле деятельности организаций и учреждений.",
            "Принимает участие в организации конференций и семинаров.",
            "Вносит предложения руководству отдела (управления) по улучшению организации работы."
        };

        /// <summary>
        /// создание специалиста с заполнением личных данных
        /// </summary>
        /// <param name="secondName">фамилия</param>
        /// <param name="firstName">имя</param>
        /// <param name="patronymic">отчество</param>
        /// <param name="position">должность</param>
        /// <param name="address">адрес</param>
        /// <param name="birthDate">год рождения</param>
        public Specialist(
            string secondName = "Иванов", string firstName = "Иван",
            string patronymic = "Иванович", string position = "Специалист",
            string address = "Восточная Европа", int birthDate = 1991) : base(
                secondName, firstName, patronymic, position, address, birthDate)
        {
            if (DateTime.Today.Year - birthDate > maxAge || DateTime.Today.Year - birthDate < minAge)
                throw new ArgumentException("год рождения не действителен для " + definition);
        }

        //у каждого специалиста есть начальник(отдела или сектора)
        //и заместитель(такой же должности)
        //
        //=> должностная инструкция по специалисту(БУСЕЛ)

        /// <summary>
        /// получение главы специалиста
        /// </summary>
        /// <returns></returns>
        public Leader GetHead()
        {

            //пробуем получить начальника сектора из группы
            Leader res = null;
            foreach (Employee emp in group)
                if (emp is Head_of_Sector && key.StartsWith(emp.key))
                    res = (Leader)emp;

            //если это не начальник сектора, получаем главу отдела
            if (res == null)
                foreach (Employee emp in group)
                    if (emp is Department_head && key.StartsWith(emp.key))
                        res = (Leader)emp;
            return res;
        }

        /// <summary>
        /// заместитель специалиста(специалист)
        /// </summary>
        public Specialist Deputy;

        //у специалиста свои обязанности, помимо
        //обязанностей служащего, поэтому переопределяем метод
        //
        //=> должностная инструкция по специалисту(БУСЕЛ)

        /// <summary>
        /// вывод списка обязанностей в строку
        /// </summary>
        /// <param name="res">контейнер для вывода</param>
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
            return base.ToString(format) + " специалист";
        }
    }
}
