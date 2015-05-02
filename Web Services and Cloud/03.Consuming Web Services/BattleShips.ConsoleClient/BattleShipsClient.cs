namespace BattleShips.ConsoleClient
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;
    using System.Web.Script.Serialization;
    using Models;

    public class BattleShipsClient
    {
        // check port of the web services
        private const string BaseUri = "http://localhost:62858/";
        private static KeyValuePair<string, string> accessToken;

        public static void Main()
        {
            Console.WriteLine("Type your commands...");
            bool gameIsActive = true;
            while (gameIsActive)
            {
                var input = Console.ReadLine();
                if (input != null)
                {
                    var commandInput = input.Trim().Split(new[] { ' ' });
                    string command = commandInput[0].ToLower();
                    var commandObject = new Command();
                    switch (command)
                    {
                        case "register":
                            if (commandInput.Length == 4)
                            {
                                commandObject.Uri = "api/Account/Register";
                                commandObject.Content = new List<KeyValuePair<string, string>>
                                {
                                    new KeyValuePair<string, string>("Email", commandInput[1]),
                                    new KeyValuePair<string, string>("Password", commandInput[2]),
                                    new KeyValuePair<string, string>("ConfirmPassword", commandInput[3]),
                                };

                                PostAsync(commandObject)
                                    .ContinueWith((result) =>
                                    {
                                        var status = result.Result.StatusCode;
                                        Console.WriteLine(status == HttpStatusCode.OK
                                            ? "Registered"
                                            : (int)result.Result.StatusCode + " " + result.Result.ReasonPhrase);
                                    });
                            }
                            else
                            {
                                Console.WriteLine("Invalid parameters specified for the registration.");
                            }

                            break;
                        case "login":
                            if (commandInput.Length == 3)
                            {
                                Console.WriteLine("You will be logged-in with new credentials and loose any previous seesion.");
                                commandObject.Uri = "Token";
                                commandObject.Content = new List<KeyValuePair<string, string>>
                                {
                                    new KeyValuePair<string, string>("Username", commandInput[1]),
                                    new KeyValuePair<string, string>("Password", commandInput[2]),
                                    new KeyValuePair<string, string>("grant_type", "password"),
                                };

                                PostAsync(commandObject)
                                    .ContinueWith((result) =>
                                    {
                                        var status = result.Result.StatusCode;
                                        if (status == HttpStatusCode.OK)
                                        {
                                            var token =
                                                new JavaScriptSerializer().Deserialize<Token>(
                                                    result.Result.Content.ReadAsStringAsync().Result);
                                            accessToken = new KeyValuePair<string, string>("Bearer", token.Access_token);
                                            Console.WriteLine("Authenticated");
                                        }
                                        else
                                        {
                                            Console.WriteLine((int)result.Result.StatusCode + " " + result.Result.ReasonPhrase);
                                        }
                                    });
                            }
                            else
                            {
                                Console.WriteLine("Invalid parameters specified for the login or you have been logged-in already.");
                            }

                            break;
                        case "create-game":
                            if (commandInput.Length == 1 && accessToken.Value != null)
                            {
                                commandObject.Uri = "api/Games/create";
                                commandObject.Header = accessToken;

                                PostAsync(commandObject)
                                    .ContinueWith((result) =>
                                    {
                                        var status = result.Result.StatusCode;
                                        Console.WriteLine(status == HttpStatusCode.OK
                                            ? "Game created - (Id: " + result.Result.Content.ReadAsStringAsync().Result + ")"
                                            : (int)result.Result.StatusCode + " " + result.Result.ReasonPhrase);
                                    });
                            }
                            else
                            {
                                Console.WriteLine("Invalid parameters specified for the creation of game.");
                            }

                            break;
                        case "join-game":
                            if (commandInput.Length == 2 && accessToken.Value != null)
                            {
                                commandObject.Uri = "api/Games/join";
                                commandObject.Header = accessToken;
                                commandObject.Content = new List<KeyValuePair<string, string>>
                                {
                                    new KeyValuePair<string, string>("GameId", commandInput[1])
                                };

                                PostAsync(commandObject)
                                    .ContinueWith((result) =>
                                    {
                                        var status = result.Result.StatusCode;
                                        Console.WriteLine(status == HttpStatusCode.OK
                                            ? "Game Joined - (Id: " + result.Result.Content.ReadAsStringAsync().Result + ")"
                                            : (int)result.Result.StatusCode + " " + result.Result.ReasonPhrase);
                                    });
                            }
                            else
                            {
                                Console.WriteLine("Invalid parameters specified for the joining game.");
                            }

                            break;
                        case "play":
                            if (commandInput.Length == 4 && accessToken.Value != null)
                            {
                                commandObject.Uri = "api/Games/play";
                                commandObject.Header = accessToken;
                                commandObject.Content = new List<KeyValuePair<string, string>>
                                {
                                    new KeyValuePair<string, string>("GameId", commandInput[1]),
                                    new KeyValuePair<string, string>("PositionX", commandInput[2]),
                                    new KeyValuePair<string, string>("PositionY", commandInput[3]),
                                };

                                PostAsync(commandObject)
                                    .ContinueWith((result) =>
                                    {
                                        var status = result.Result.StatusCode;
                                        Console.WriteLine(status == HttpStatusCode.OK
                                            ? "Player did a move"
                                            : (int)result.Result.StatusCode + " " + result.Result.ReasonPhrase);
                                    });
                            }
                            else
                            {
                                Console.WriteLine("Invalid parameters specified for the playing game.");
                            }

                            break;
                        case "exit":
                            gameIsActive = false;
                            Console.WriteLine("Bye!");
                            break;
                        default:
                            throw new InvalidOperationException("Unknown command has been executed.");
                    }
                }
                else
                {
                    throw new ArgumentNullException("input", "No input detected. Restart game.");
                }
            }
        }

        private static async Task<HttpResponseMessage> PostAsync(Command command)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUri);
                HttpContent content = new FormUrlEncodedContent(new List<KeyValuePair<string, string>>());
                string query = command.Uri;
                if (command.Content.Count > 0)
                {
                    content = new FormUrlEncodedContent(command.Content);
                }

                if (command.Header.Key != null)
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(accessToken.Key, accessToken.Value);
                }

                HttpResponseMessage response = await client.PostAsync(query, content);
                return response;
            }
        }
    }
}
