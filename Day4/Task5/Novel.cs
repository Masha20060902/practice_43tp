namespace Task5
{
    internal class Novel : Book
    {
        public override void Read()
        {
            Console.WriteLine("Reding a novel....");
        }
        public override void DisplayInfo()
        {
            Read();
            base.DisplayInfo();
            Console.WriteLine("Крутая книга с романами");
        }
    }
}
