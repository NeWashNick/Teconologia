namespace Stadion
{
    internal class Match
    {
        public int Id { get; }
        public int TeamId { get; }
        private string Opponent { get; set; }
        public DateTime Date { get; set; }
        public string Score { get; set; }
        public string Stadium { get; set; }
        public Match(int id, int teamId, string opponent, DateTime date, string score, string stadium)
        {
            if (id <= 0)
            {
                throw new ArgumentException("id должен быть больше 0");
            }
            if (teamId <= 0)
            {
                throw new ArgumentException("Teamid должен быть больше 0");
            }
            if (string.IsNullOrWhiteSpace(opponent))
            {
                throw new ArgumentException("Opponent не может быть пустым");
            }
            if (string.IsNullOrWhiteSpace(score) || !score.Contains(":"))
            {
                throw new ArgumentException("Score должен быть в формате X:Y");
            }
            if (string.IsNullOrWhiteSpace(stadium))
            {
                throw new ArgumentException("Stadium не может быть пустым");
            }
            Id = id;
            TeamId = teamId;
            Opponent = opponent;
            Date = date;
            Score = score;
            Stadium = stadium;
        }
        public int GetGoals()
        {
            string[] parts = Score.Split(':');
            if (parts.Length != 2)
                return 0;
            int goals1 = int.Parse(parts[0]);
            int goals2 = int.Parse(parts[01]);
            return goals1 + goals2;
        }
        public string GetOpppnent()
        {
            return Opponent;
        }
        public string GetInfo(string teamName)
        {
            return $"{teamName} - {Opponent} ({Score}, {Date:dd.MM.yyyy} )";
        }
    }
}
