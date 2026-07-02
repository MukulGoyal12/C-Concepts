namespace RealEstate
{
    public abstract class Building
    {
        public int Id { get; set; }
        public int Name { get; set; }
        public int Area { get; set; }
        public int Level { get; set; }

        public void Accept()
        {

        }

        //Not Related to Building and is voilating Single Responsibility so we have to remove it.

        //public void SaveToDatabase()
        //{

        //}

        //public void SaveToFile()
        //{

        //}

    }
}
