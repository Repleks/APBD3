using System;

namespace LegacyApp;

public class UserInfoChecker
{
    public bool IsUserInputCorrect(string firstName, string lastName, string email, DateTime dateOfBirth)
    {
        return CheckIfUserInputIsCorrect(firstName, lastName, email, dateOfBirth);
    }
    private bool CheckIfUserInputIsCorrect(string firstName, string lastName, string email, DateTime dateOfBirth)
    {
        if (!IsUserNameCorrectAddUser(firstName, lastName)) return false;

        if (!IsUserEmailCorrect(email)) return false;

        var age = AccurateAgeTest(dateOfBirth);

        if (!CheckIfAgeOver21(age)) return false;
        return true;
    }

    private bool CheckIfAgeOver21(int age)
    {
        if (age < 21)
        {
            return false;
        }

        return true;
    }

    private int AccurateAgeTest(DateTime dateOfBirth)
    {
        var now = DateTime.Now;
        int age = now.Year - dateOfBirth.Year;
        if (now.Month < dateOfBirth.Month || (now.Month == dateOfBirth.Month && now.Day < dateOfBirth.Day)) age--;
        return age;
    }

    private bool IsUserEmailCorrect(string email)
    {
        if (!email.Contains("@") && !email.Contains("."))
        {
            return false;
        }

        return true;
    }

    private static bool IsUserNameCorrectAddUser(string firstName, string lastName)
    {
        if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName))
        {
            return false;
        }

        return true;
    }
}
