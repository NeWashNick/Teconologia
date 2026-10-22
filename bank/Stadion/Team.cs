namespace Stadion
{
    internal class Team
    {
        public int Id { get; }
        private string Name { get; set; }
        public int CoachId { get; }
        public string City { get; set; }
        public decimal Budget { get; set; }
        public bool IsRich => Budget > 100000000m;
        public Team(int id, string name, int coachId, string city, decimal budget)
        {
            if (id <= 0)
                throw new ArgumentException("Id должен быть больше 0");

            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name не может быть пустым");

            if (coachId <= 0)
                throw new ArgumentException("CoachId должен быть больше 0");

            if (string.IsNullOrWhiteSpace(city))
                throw new ArgumentException("City не может быть пустым");

            if (budget < 0)
                throw new ArgumentException("Budget не может быть отрицательным");

            Id = id;
            Name = name;
            CoachId = coachId;
            City = city;
            Budget = budget;
        }
        public string GetName() { return Name; }
        public string GetInfo()
        {
            return $"{Name} ({City}, {Budget} руб)";
        }
    }
}
