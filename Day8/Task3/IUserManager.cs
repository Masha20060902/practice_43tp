namespace Task3
{
    internal interface IUserManager<T>
    {
        void AddUser(T user);
        void RemoveUser(T user);
    }
}
