using System.Text.RegularExpressions;

namespace Stadion
{
    internal class InMemoryRepository
    {
        private List<Coach> _coaches;
        private List<Team> _teams;
        private List<Match> _matches;
        public InMemoryRepository()
        {
            _coaches = new List<Coach>
            {
                new Coach (1, "Иванов И.И"),
                new Coach (2, "Сидоров И.И"),
                new Coach (3, "Рахитов И.И"),
                new Coach (4, "Магомедов И.И"),
                new Coach (5, "Армани И.И")
            };
            _teams = new List<Team>
            {
                new Team(1, "Спартак", 1, "Москва", 500000000m),
                new Team(2, "ЦСКА", 1, "Москва", 420000000m),
                new Team(3, "Зенит",  1, "Санкт-Петербург", 600000000m),
                new Team(4, "Динамо", 1, "Москва", 50000000m),
                new Team(5, "Локомотив", 1, "Москва", 380000000m)
            };
            _matches = new List<Match> {
                new Match(1,1, "Зенит", new DateTime(2025,9,1), "2:1", "Лужники"),
                new Match(2,2, "Динамо", new DateTime(2025,9,8), "1:1", "ВЭБ Арена"),
                new Match(3,1, "ЦСКА", new DateTime(2025,9,15), "2:1", "Лужники"),
                new Match(4,3, "Спартак", new DateTime(2025,9,20), "1:2", "Газпром Арена"),
                new Match(5,2, "Локомотив", new DateTime(2025,9,25), "2:2", "ВЭБ Арена"),
                new Match(6,1, "Динамо", new DateTime(2025,10,1), "1:0", "Лужники"),
                new Match(7,4, "ЦСКА", new DateTime(2025,10,5), "0:1", "ВТБ Арена")
            };
        }
        public List<Coach> GetCoaches()
        {
            return _coaches;
        }
        public List<Team> GetTeams()
        {
            return _teams;
        }
        public List<Match> GetMatches()
        {
            return _matches;
        }
    }
}