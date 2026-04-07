using System.IO;
using System.Text.Json;
namespace Task
{
    class UserManager
    {
        private string filepath = "users.json";
        private List<User> _users = new List<User>();
        public UserManager()
        {
            LoadUsers();
        }
        public void SaveUser()
        {
            var json = JsonSerializer.Serialize(_users, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            File.WriteAllText(filepath, json);
        }
        private void LoadUsers()
        {
            if (!File.Exists(filepath))
                return;

            var json = File.ReadAllText(filepath);
            var users = JsonSerializer.Deserialize<List<User>>(json);
            if (users != null)
                _users = users;
        }
        public bool RegisterUser(string username, string password)
        {
            if (_users.Exists(u => u.Name == username))
                return false;
            _users.Add(new User { Name = username, Password = BCrypt.Net.BCrypt.HashPassword(password) });
            SaveUser();
            return true;
        }
        public bool Authenticate(string username, string password)
        {
            var user = _users.Find(u => u.Name == username);
            return user != null && BCrypt.Net.BCrypt.Verify(password, user.Password);
        }
    }
}
