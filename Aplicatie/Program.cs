using System.Text;

public class Password
{

    private static readonly TimeSpan validare = TimeSpan.FromSeconds(30);
    //definieste o constanta ce specifica valabilitatea parolei generate
    public string GeneratePassword(string userId, DateTime dateTime)
    {
        const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        Random random = new Random();

        int passwordLength = random.Next(4, 9);
        StringBuilder passwordBuilder = new StringBuilder();
        for (int i = 0; i < passwordLength; i++)
        {
            passwordBuilder.Append(chars[random.Next(chars.Length)]);
        }
        string password = passwordBuilder.ToString();

        return password;
    }

    public bool IsPasswordValid(string userId, DateTime dateTime, string password)
    {
        if (password.Length < 4 || password.Length > 8)
        {
            return false;
        }

        bool hasLowercase = false;
        bool hasUppercase = false;
        bool hasNumber = false;

        foreach (char c in password)
        {
            if (char.IsLower(c))
            {
                hasLowercase = true;
            }
            else if (char.IsUpper(c))
            {
                hasUppercase = true;
            }
            else if (char.IsDigit(c))
            {
                hasNumber = true;
            }
        }

        if (!(hasLowercase && hasUppercase && hasNumber))
        {
            return false;
        }

        DateTime expirationTime = dateTime.Add(validare);
        DateTime currentTime = DateTime.Now;

        return currentTime <= expirationTime;
    }
}



    public class Aplication
{
    public static void Main(string[] args)
    {
        string userId = "BOGDAN";
        DateTime dateTime = DateTime.Now;

        Password passwordGenerator = new Password();
        string password = passwordGenerator.GeneratePassword(userId, dateTime);

        Console.WriteLine("Genereaza parola: " + password);
        Console.WriteLine("Parola este sau nu valida? " + passwordGenerator.IsPasswordValid(userId, dateTime, password));

      //aici verifica daca parola generata ramane valida 30 de secunde
        System.Threading.Thread.Sleep(TimeSpan.FromSeconds(30));

        Console.WriteLine("parola este valida dupa 30 de secunde?? " + passwordGenerator.IsPasswordValid(userId, dateTime, password));
    }
}



