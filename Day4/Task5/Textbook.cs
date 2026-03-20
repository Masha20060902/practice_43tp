namespace Task5
{
    internal class Textbook : Book
    {
        public override void Read()
        {
            Console.WriteLine("Reading a textbook....");
        }
        public override void DisplayInfo()
        {
            Read();
            base.DisplayInfo();
            Console.WriteLine("Учебник");
        }
    }
}
