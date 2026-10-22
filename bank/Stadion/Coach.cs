namespace Stadion
{
    internal class Coach
    {
        public int Id { get; }
        private string FullName { get; set; }

        public Coach(int id, string fullName)
        {
            if (id <= 0)
                throw new ArgumentException("Id не может быть меньше 0");
            if (string.IsNullOrWhiteSpace(fullName))
                throw new ArgumentException("fullName не может быть пустым");
            Id = id;
            FullName = fullName;
        }

        public string GetInfo()
        {
            return FullName;
        }
    }
}
