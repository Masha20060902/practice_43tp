namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Movement[] movement =
            {
                new Cycling(),
                new Running(),
                new Walking()
            };
            var work = new WorkingArray();
            work.MovesAll(movement);
            Console.WriteLine("Что вы сейчас делаете?\nБежите: 1,\nИдёте: 2,\nЕдите: 3.");
            int type = Convert.ToInt32(Console.ReadLine());
            work.MoveByType(movement, type);
            Console.WriteLine("Ваш план\nЧто у вас в приоритете:\nБег: 1,\nХодьба: 2,\nЕзда на велосипеде: 3.");
            int priority = Convert.ToInt32(Console.ReadLine());
            work.SortToArray(movement, priority);
            foreach (var m in movement)
            {
                m.Move();
            }
        }
    }
}
