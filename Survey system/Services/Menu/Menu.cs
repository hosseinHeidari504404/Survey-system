using Microsoft.EntityFrameworkCore;
using Survey_system.Models.Entities;
namespace Survey_system.Services.Menu
{
    public class Menu
    {
        public static void AdminMenu(
            User user,
            SurveyService surveyService,
            QuestionService questionService,
            OptionService optionService)
        {
            while (true)
            {
                Console.WriteLine("\n=== Admin Menu ===");
                Console.WriteLine("1. Create new survey");
                Console.WriteLine("2. View all surveys");
                Console.WriteLine("3. Add question to survey");
                Console.WriteLine("4. Add option to question");
                Console.WriteLine("5. Delete survey");
                Console.WriteLine("0. Logout");
                Console.Write("Choice: ");
                var choice = Console.ReadLine();
                Console.Clear();
                if (choice == "0") break;

                try
                {
                    if (choice == "1")
                    {
                        Console.Write("Enter survey title: ");
                        var title = Console.ReadLine();
                        surveyService.CreateSurvey(title, user.Id);
                    }
                    else if (choice == "2")
                    {
                        var surveys = surveyService.GetAllSurveys();
                        if (surveys.Count == 0)
                        {
                            Console.WriteLine("No surveys found.");
                            continue;
                        }

                        Console.WriteLine("\n--- All Surveys ---");
                        foreach (var s in surveys)
                            Console.WriteLine($"{s.Id}. {s.Title} (Created on: {s.CreatedOn})");
                    }
                    else if (choice == "3")
                    {
                        var surveys = surveyService.GetAllSurveys();
                        if (surveys.Count == 0)
                        {
                            Console.WriteLine("No surveys to add questions to.");
                            continue;
                        }

                        foreach (var s in surveys)
                            Console.WriteLine($"{s.Id}. {s.Title}");

                        Console.Write("Select survey ID: ");
                        int surveyId = int.Parse(Console.ReadLine());
                        Console.Write("Enter question text: ");
                        string questionText = Console.ReadLine();

                        questionService.AddQuestion(surveyId, questionText);
                    }
                    else if (choice == "4")
                    {
                        var questions = questionService.GetAllQuestions();
                        if (questions.Count == 0)
                        {
                            Console.WriteLine("No questions found.");
                            continue;
                        }

                        foreach (var q in questions)
                            Console.WriteLine($"{q.Id}. {q.Text}");

                        Console.Write("Select question ID: ");
                        int questionId = int.Parse(Console.ReadLine());
                        Console.Write("Enter option text: ");
                        string optionText = Console.ReadLine();

                        optionService.AddOption(questionId, optionText);
                    }
                    else if (choice == "5")
                    {
                        var surveys = surveyService.GetAllSurveys();
                        if (surveys.Count == 0)
                        {
                            Console.WriteLine("No surveys found.");
                            continue;
                        }

                        foreach (var s in surveys)
                            Console.WriteLine($"{s.Id}. {s.Title}");

                        Console.Write("Enter survey ID to delete: ");
                        int id = int.Parse(Console.ReadLine());
                        surveyService.DeleteSurvey(id);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }

        public static void UserMenu(
            User user,
            SurveyService surveyService,
            QuestionService questionService,
            OptionService optionService,
            VoteService voteService)
        {
            while (true)
            {
                Console.WriteLine("\n=== User Menu ===");
                Console.WriteLine("1. View surveys and vote");
                Console.WriteLine("2. View all votes");
                Console.WriteLine("0. Logout");
                Console.Write("Choice: ");
                var choice = Console.ReadLine();
                Console.Clear();
                if (choice == "0") break;

                try
                {
                    if (choice == "1")
                    {
                        var surveys = surveyService.GetAllSurveys();
                        if (surveys.Count == 0)
                        {
                            Console.WriteLine("No surveys available.");
                            continue;
                        }

                        foreach (var s in surveys)
                            Console.WriteLine($"{s.Id}. {s.Title}");

                        Console.Write("Select survey ID: ");
                        int surveyId = int.Parse(Console.ReadLine());
                        Console.Clear();
                        var survey = surveyService.GetSurveyById(surveyId);

                        if (survey == null)
                        {
                            Console.WriteLine("Invalid survey ID.");
                            continue;
                        }

                        Console.WriteLine($"\nSurvey: {survey.Title}");
                        foreach (var q in survey.Questions)
                        {
                            Console.WriteLine($"\nQuestion {q.Id}: {q.Text}");
                            foreach (var opt in q.Options)
                                Console.WriteLine($"   {opt.Id}. {opt.Text}");

                            Console.Write("Select option ID: ");
                            int optionId = int.Parse(Console.ReadLine());
                            //voteService.AddVote(user.Id, q.Id, optionId);
                            try
                            {
                                voteService.AddVote(user.Id, q.Id, optionId);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }

                        }
                    }
                    else if (choice == "2")
                    {
                        var votes = voteService.GetAllVotes();
                        if (votes.Count == 0)
                        {
                            Console.WriteLine("No votes yet.");
                            continue;
                        }

                        Console.WriteLine("\n--- All Votes ---");
                        foreach (var v in votes)
                            Console.WriteLine($"User: {v.User.Username}, Question: {v.Question.Text}, Option: {v.Option.Text}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
    }
}

