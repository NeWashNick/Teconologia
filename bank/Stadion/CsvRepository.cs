using System.Globalization;
using System.Text.RegularExpressions;

namespace Stadion
{
    internal class CsvRepository
    {
        private string _basePath;
        public CsvRepository(string basePath)
        {
            if (string.IsNullOrWhiteSpace(basePath))
                throw new ArgumentException("Путь не может быть пустым");
            _basePath = basePath;
        }
        public List<Coach> GetCoaches()
        {
            List<Coach> result = new List<Coach>();
            string path = Path.Combine(_basePath, "coaches.csv");
            if (!File.Exists(path))
                return result;
            string[] lines = File.ReadAllLines(path);
            if (lines.Length < 2)
                return result;
            for (int i = 1; i < lines.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(lines[i]))
                    continue;
                string[] parts = lines[i].Split(",");
                if (parts.Length < 2)
                    continue;
                int id;
                if (!int.TryParse(parts[0], out id))
                    continue;
                result.Add(new Coach(id, parts[1]));
            }
            return result;

        }
        public List<Team> GetTeams()
        {
            List<Team> result = new List<Team>();
            string path = Path.Combine(_basePath, "teams.csv");
            if (!File.Exists(path))
                return result;
            string[] lines = File.ReadAllLines(path);
            if (lines.Length < 2)
                return result;
            for (int i = 1; i < lines.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(lines[i]))
                    continue;
                string[] parts = lines[i].Split(",");
                if (parts.Length < 2)
                    continue;
                int id, coachId;
                decimal budget;
                if (!int.TryParse(parts[0], out id))
                    continue;
                if (!int.TryParse(parts[2], out coachId))
                    continue;
                if (!decimal.TryParse(parts[4], out budget))
                    continue;
                result.Add(new Team(id, parts[1], coachId, parts[2], budget));
            }
            return result;

        }
        public List<Match> GetMatches()
        {
            List<Match> result = new List<Match>();
            string path = Path.Combine(_basePath, "matches.csv");
            if (!File.Exists(path))
                return result;
            string[] lines = File.ReadAllLines(path);
            if (lines.Length < 2)
                return result;
            for (int i = 1; i < lines.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(lines[i]))
                    continue;
                string[] parts = lines[i].Split(",");
                if (parts.Length < 2)
                    continue;
                int id, teamId, teamId2;
                DateTime date;
                if (!int.TryParse(parts[0], out id))
                    continue;
                if (!int.TryParse(parts[1], out teamId))
                    continue;
                if (!int.TryParse(parts[2], out teamId2))
                    continue;
                if (!DateTime.TryParseExact(parts[3], "dd.MM.yyyy", null, System.Globalization.DateTimeStyles.None, out date))
                    continue;
                result.Add(new Match(id, teamId, parts[2], date, parts[4], parts[5]));
            }
            return result;

        }
    }
}
