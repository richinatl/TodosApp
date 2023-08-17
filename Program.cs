// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello!");

bool exitApp = false;
var todoList = new List<string>();

while (!exitApp)
{
    Console.WriteLine("");
    Console.WriteLine("What do you want to do?");
    Console.WriteLine("[S]ee all TODOS");
    Console.WriteLine("[A]dd a TODO");
    Console.WriteLine("[R]emove a TODO");
    Console.WriteLine("[E]xit");
    Console.WriteLine("");

    var userChoice = Console.ReadLine();
    var userInput = userChoice.ToUpper();


    switch (userInput)
    {
        case "S":
            {
                SeeAllTodos();
                break;
            }
        case "A":
            {
                AddTodo();
                break;
            }
        case "R":
            {
                RemoveTodo();
                break;
            }
        case "E":
            {
                ExitApp();
                break;
            }
        default:
            {
                Console.WriteLine("Please make a valid Selection");
                break;
            }
    }


    void RemoveTodo()
    {
        if (todoList.Count == 0)
        {
            Console.WriteLine("There's nothing here yet, go back and add something");
            return;
        }
        bool isIndexValid = false;
        while (!isIndexValid)
        {
            SeeAllTodos();
            Console.WriteLine("What number do you want to take off the list?");
            var userIndex = Console.ReadLine();
            if (userIndex == "")
            {
                Console.WriteLine("That's not a valid choice");
                continue;
            }
            if(int.TryParse(userIndex, out int index) &&
                index >=1 &&
                index <= todoList.Count)
            {
                var indexOfTodo = index - 1;
                var todoRemoved = todoList[indexOfTodo];
                todoList.RemoveAt(indexOfTodo);
                isIndexValid = true;
                Console.WriteLine("Todo removed: " + todoRemoved);
                SeeAllTodos();
            }
            else
            {

            }
        }
    }

    void AddTodo()
    {
        bool isValid = false;

      while (!isValid)
        {
            Console.WriteLine("What do you need to get done?");
            var addedTodo = Console.ReadLine();
            if (addedTodo == "")
            {
                Console.WriteLine("Are you forgetting something,,, please describe the task");
            }
            else if (todoList.Contains(addedTodo))
            {
                Console.WriteLine("Hey you already have that one!");
            }
            else
            {
                isValid = true;
                todoList.Add(addedTodo);
            }

        }
    }

    void SeeAllTodos()
    {
        if(todoList.Count == 0)
        {
            Console.WriteLine("Nothing to see yet, add something!");
        }
        else
        {
            for (int i = 0; i < todoList.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {todoList[i]}");
            }
        }
    }
       
}

    void ExitApp()
    {
        exitApp = true;
    }

Console.ReadKey();