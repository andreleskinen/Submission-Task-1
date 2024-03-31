using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace UserRegistrationService;

public class UserRegistration
{
    //min lista för att spara users i
    private readonly List<User> _users = new List<User>();

    //metod för att rensa users
    public void ClearUsers()
    {
        _users.Clear();
    }

    public bool RegisterUser(User user)
    {
        //Kollar om användarnamn, lösenord och email är giltiga
        if (!ValidUserName(user.Username) || !ValidPassword(user.Password) || !ValidEmail(user.Email))
            return false;

        // kollar om användarnamnet de är upptagna
        foreach (var existingUser in _users)
        {
            if (existingUser.Username == user.Username)
                return false;
        }

        // om allt är ok, lägg till användaren
        _users.Add(user);
        return true;
    }

    private bool ValidUserName(string username)
    {
        // kolla så att användanamndet är mellan 5 till 20 tecken, tillåtet att använda användarnamn med siffror
        return username.Length >= 5 && username.Length <= 20 && username.All(char.IsLetterOrDigit);
    }

    private bool ValidPassword(string password)
    {
        //kolla så att lösenordet är minst 8 tecken och har minst ett sepcial tecken
        return password.Length >= 8 && CheckIsCharacterSpecial(password);
    }

    private bool ValidEmail(string email)
    {
        try
        {   // försöker skapa en email adress med adressen som användaren har lagt till
            //kollar ocksp att emailen har rätt format
            var addr = new System.Net.Mail.MailAddress(email);
            return addr.Address == email;
        }
        catch
        {
            //fungerar det inte betyder det att email inte är giltigt eller i rätt format
            return false;
        }
    }

    //jag skapade en ny extern metod för att tillåta speciella tecken i lösenordet då .Any(char.IsSymbol);
    //gjorde så att mina tester failade hela tiden
    private bool CheckIsCharacterSpecial(string password)
    {
        foreach (char c in password)
        {
            if (!char.IsLetterOrDigit(c))
            {
                return true;
            }
        }
        return false;
    }
}

