using System;
using System.Collections.Generic;
using System.IO;
using Stadion;
class Program
{
    static void Main()
    {
        Console.WriteLine("Выберите источник данных:");
        Console.WriteLine("1 - InMemory");
        Console.WriteLine("2 - csv");
        Console.WriteLine("Ваш выбор");
        int choice;
        if (!int.TryParse(Console.ReadLine(), out choice))
        {
            Console.WriteLine("Неверный ввод");
            return;
        }
        List<Coach> coaches = null;
        List<Team> teams = null;
        List<Match> matches = null;
        try
        {
            switch (choice)
            {
                case 1:
                    InMemoryRepository memoryRepo = new InMemoryRepository();
                    coaches = memoryRepo.GetCoaches();
                    teams = memoryRepo.GetTeams();
                    matches = memoryRepo.GetMatches();
                    break;
                case 2:
                    CsvRepository csvRepo = new CsvRepository("date");
                    coaches = csvRepo.GetCoaches();
                    teams = csvRepo.GetTeams();
                    matches = csvRepo.GetMatches();
                    break;
                default:
                    Console.WriteLine("Неверный выбор");
                    return;
            }
            if (coaches == null || teams == null || matches == null)
            {
                Console.WriteLine("Данные не загружены");
                return;
            }
            Console.WriteLine();
            Coach foundCoach = FindCoach(teams, coaches, "Спартак");
            Console.WriteLine("1. FindCoach(\"Спартак\"): " + (foundCoach != null ? foundCoach.GetInfo() : "null"));

            Match exampleMatch = matches.Count > 0 ? matches[0] : null;
            Team foundTeam = FindTeam(teams, exampleMatch);
            Console.WriteLine("2. FindTeam: " + (foundTeam != null ? foundTeam.GetInfo() : "null"));

            Console.WriteLine("3. GetTotalGoals: " + GetTotalGoals(matches));

            Console.WriteLine("4. GetTeamStats:");
            Dictionary<string, int> stats = GetTeamStats(matches, teams);
            if (stats != null)
            {
                foreach (var pair in stats)
                {
                    Console.WriteLine($"   {pair.Key} — {pair.Value}");
                }
            }

            Console.WriteLine("5. PrintAllMatches:");
            PrintAllMatches(matches, teams, coaches);

            Console.WriteLine();
            Console.WriteLine("Не найдено: FindCoach(\"Неизвестная команда\") → " +
                (FindCoach(teams, coaches, "Неизвестная команда") == null ? "null" : "нашли"));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ошибка: " + ex.Message);
            return;
        }
    }

    static Coach FindCoach(List<Team> teams, List<Coach> coaches, string teamName)
    {
        if (teams == null || coaches == null || string.IsNullOrWhiteSpace(teamName))
            return null;

        Team foundTeam = null;
        foreach (Team team in teams)
        {
            if (team != null && team.GetName() == teamName)
            {
                foundTeam = team;
                break;
            }
        }

        if (foundTeam == null)
            return null;

        foreach (Coach coach in coaches)
        {
            if (coach != null && coach.Id == foundTeam.CoachId)
                return coach;
        }

        return null;
    }

    static Team FindTeam(List<Team> teams, Match match)
    {
        if (teams == null || match == null)
            return null;

        foreach (Team team in teams)
        {
            if (team != null && team.GetName() == match.GetOpppnent())
                return team;
        }

        return null;
    }

    static int GetTotalGoals(List<Match> matches)
    {
        if (matches == null)
            return 0;

        int total = 0;
        foreach (Match match in matches)
        {
            if (match != null)
                total += match.GetGoals();
        }
        return total;
    }

    static Dictionary<string, int> GetTeamStats(List<Match> matches, List<Team> teams)
    {
        Dictionary<string, int> stats = new Dictionary<string, int>();

        if (matches == null || teams == null)
            return stats;


        foreach (Team team in teams)
        {
            if (team != null && !string.IsNullOrWhiteSpace(team.GetName()) && !stats.ContainsKey(team.GetName()))
            {
                stats.Add(team.GetName(), 0);
            }
        }

        foreach (Match match in matches)
        {
            if (match == null) continue;

            Team team = FindTeam(teams, match);
            if (team == null) continue;

            string[] parts = match.Score.Split(':');
            if (parts.Length != 2) continue;

            int goalsTeam, goalsOpponent;
            if (!int.TryParse(parts[0], out goalsTeam) || !int.TryParse(parts[1], out goalsOpponent))
                continue;

            if (goalsTeam > goalsOpponent)
                stats[team.GetName()] += 3;
            else if (goalsTeam == goalsOpponent)
                stats[team.GetName()] += 1;
        }

        return stats;
    }

    static void PrintAllMatches(List<Match> matches, List<Team> teams, List<Coach> coaches)
    {
        if (matches == null || teams == null || coaches == null)
            return;

        foreach (Match match in matches)
        {
            if (match == null) continue;

            Team team = FindTeam(teams, match);
            string teamName = team != null ? team.GetInfo() : "—";

            Coach coach = null;
            if (team != null)
            {
                foreach (Coach c in coaches)
                {
                    if (c != null && c.Id == team.CoachId)
                    {
                        coach = c;
                        break;
                    }
                }
            }

            string coachName = coach != null ? coach.GetInfo() : "—";
            Console.WriteLine($"{match.GetInfo(teamName)} — команда \"{teamName}\", тренер {coachName}");
        }
    }
}



