using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Db.Service;

namespace Models.Service
{
    public static class RuleService
    {
        public static User ValidateUser(User user)
        {
            return new Func<string, User>((reason) =>
            {
                if (!(CheckWithRule(user.Email, "email", out reason)
                    || CheckWithRule(user.Username, "username", out reason)
                    || CheckWithRule(user.Mobile, "mobile", out reason)))
                    throw new ArgumentException($"user information contains invalid value, reason:${reason}");

                return user;
            })("");

        }

        public static List<Rule> GetRules(string category)
        {
            return new List<Rule> {
                new Rule
                {
                    Category = "email",
                    ValidExpression = @"^[\w!#$%&'*+/=?^_`{|}~-]+(?:\.[\w!#$%&'*+/=?^_`{|}~-]+)*@(?:[\w](?:[\w-]*[\w])?\.)+[\w](?:[\w-]*[\w])?$",
                    BlackList = new List<string> { },
                    CanBeEmpty = true
                },
                new Rule
                {
                   Category = "mobile",
                   ValidExpression = @"^\d{10}$",
                   BlackList = new List<string> { }
                },
                new Rule
                {
                    Category = "username",
                    ValidExpression = @"^[a-zA-Z\d]{5,10}$",
                    BlackList = new List<string> { "admin"}
                }
            }.FindAll(n => n.Category == category);
        }

        public static bool CheckWithRule(string val, string category, out string reason)
        {
            reason = "";
            if (GetRules(category).Find(n =>
            {
                return (n.BlackList.Contains(val.ToLower())
                    || !Regex.IsMatch(val, n.ValidExpression)) && !n.CanBeEmpty;
            }) != null)
            {
                reason = category;
                return false;
            }
            return true;
        }
    }
}
