namespace Task2
{
    public static class ArrayOfEmployees
    {
        public static Employee FindOldestEmployee(Employee[] employees)
        {
            Employee old = employees[0];
            foreach (var emp in employees)
            {
                if (emp.Age > old.Age)
                {
                    old = emp;
                }
            }
            return old;
        }
        public static void SortArray(Employee[] employees)
        {
            Array.Sort(employees, (e1, e2) => e1.Age.CompareTo(e2.Age));
        }
        public static Employee[] Generation(int count)
        {
            var r = new Random();
            var e = new Employee[count];
            for (int i = 0; i < count; i++)
            {
                e[i] = new Employee
                {
                    Name = $"Работник {i}",
                    Age = r.Next(18, 100)
                };
            }
            return e;
        }
        public static double StatisticsByYear(Employee[] emp)
        {
            return emp.Average(e => e.Age);
        }
        public static Employee[] Filter(Employee[] employees, int junioremployee)
        {
            var juniors = employees.Where(e => e.Age < junioremployee).ToArray();
            return juniors;
        }
    }
}
