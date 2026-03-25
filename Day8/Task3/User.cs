namespace Task3
{
    internal class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public override string ToString()
        {
            return $"Id пользователя: {Id}. Имя: {Name}";
        }
    }
}
