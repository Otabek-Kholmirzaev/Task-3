using Newtonsoft.Json;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;
using Task_3.Entities;

namespace Task_3.Services;

public class UsersService 
{
    private readonly string filename;

	public UsersService(GetFileNamesService getFileNamesService)
	{
		filename = getFileNamesService.GetFileNames().JsonFilePath;
	}

	public void AddUser(User user)
	{
		var path = Path.Combine(Directory.GetCurrentDirectory(), "Data", filename);

		var jsonString = File.ReadAllText(path);

		var users = JsonConvert.DeserializeObject<List<User>>(jsonString);

		users ??= new List<User>();

		user.Id = users.Count + 1;

		users.Add(user);

		var newJsonString = JsonConvert.SerializeObject(users);

		File.WriteAllText(path, newJsonString);
    }

	public List<User> GetAllUsers()
	{
        var path = Path.Combine(Directory.GetCurrentDirectory(), "Data", filename);

        var jsonString = File.ReadAllText(path);

        var users = JsonConvert.DeserializeObject<List<User>>(jsonString);

        users ??= new List<User>();

		return users;
    }	

}
