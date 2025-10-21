using Survey_system.Infrastructure.Repositories;
using Survey_system.Models.Enums;
using Survey_system.Services;
using Survey_system.Services.Menu;


Console.OutputEncoding = System.Text.Encoding.UTF8;

var userRepository = new UserRepository();
var surveyRepository = new SurveyRepository();
var questionRepository = new QuestionRepository();
var optionRepository = new OptionRepository();
var voteRepository = new VoteRepository();

var userService = new UserService(userRepository);
var surveyService = new SurveyService(surveyRepository);
var questionService = new QuestionService(questionRepository);
var optionService = new OptionService(optionRepository);
var voteService = new VoteService(voteRepository);

while (true)
{
    Console.WriteLine("\n=== MAIN MENU ===");
    Console.WriteLine("1. Register");
    Console.WriteLine("2. Login");
    Console.WriteLine("0. Exit");
    Console.Write("Choice: ");
    var choice = Console.ReadLine();
    Console.Clear();
    if (choice == "0") break;

    try
    {
        if (choice == "1")
        {
            Console.Write("Username: ");
            var username = Console.ReadLine();
            Console.Write("Password: ");
            var password = Console.ReadLine();
            Console.Write("Role (Admin/User): ");
            var role = Console.ReadLine();
            Console.Clear();
            //userService.Register(username, password,  role);
            userService.Register(username, password, Enum.Parse<UserRole>(role, true));

        }
        else if (choice == "2")
        {
            Console.Write("Username: ");
            var username = Console.ReadLine();
            Console.Write("Password: ");
            var password = Console.ReadLine();
            Console.Clear();
            var user = userService.Login(username, password);
            if (user == null)
            {
                Console.WriteLine("Invalid username or password.");
                continue;
            }

            if (user.Role == UserRole.Admin)
                Menu.AdminMenu(user, surveyService, questionService, optionService);
            else
                Menu.UserMenu(user, surveyService, questionService, optionService, voteService);
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }
}
