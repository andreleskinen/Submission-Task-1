using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserRegistrationService;

// en user class med properties för att spara mina värden i
public class User
{
    public string Username { get; set; } 
    public string Password { get; set; }
    public string Email { get; set; } 

    // en constructor för initialisera en ny användare
    public User(string username, string password, string email)
    {
        Username = username;
        Password = password;
        Email = email;
    }
}
