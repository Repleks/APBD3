using System;

namespace LegacyApp
{
    public class UserService
    {
        public bool AddUser(string firstName, string lastName, string email, DateTime dateOfBirth, int clientId)
        {
            var userInfoChecker = new UserInfoChecker();
            if (!userInfoChecker.IsUserInputCorrect(firstName, lastName, email, dateOfBirth))
            {
                return false;
            }

            var clientRepository = new ClientRepository();
            var client = clientRepository.GetById(clientId);

            var user = new User
            {
                Client = client,
                DateOfBirth = dateOfBirth,
                EmailAddress = email,
                FirstName = firstName,
                LastName = lastName
            };

            SetClientCreditLimitBasedOnType(client, user);

            if (!CheckIfClientHasSomeCreditLimit(user)) return false;

            UserDataAccess.AddUser(user);
            return true;
        }

        private static bool CheckIfClientHasSomeCreditLimit(User user)
        {
            if (user.HasCreditLimit && user.CreditLimit < 500)
            {
                return false;
            }

            return true;
        }

        private static void SetClientCreditLimitBasedOnType(Client client, User user)
        {
            switch (client.Type)
            {
                case "VeryImportantClient":
                {
                    user.HasCreditLimit = false;
                    break;
                }
                case "ImportantClient":
                {
                    using (var userCreditService = new UserCreditService())
                    {
                        int creditLimit = userCreditService.GetCreditLimit(user.LastName, user.DateOfBirth);
                        creditLimit = creditLimit * 2;
                        user.CreditLimit = creditLimit;
                    }
                    break;
                }
                default:
                {
                    user.HasCreditLimit = true;
                    using (var userCreditService = new UserCreditService())
                    {
                        int creditLimit = userCreditService.GetCreditLimit(user.LastName, user.DateOfBirth);
                        user.CreditLimit = creditLimit;
                    }
                    break;
                }
            }
        }
    }
}
