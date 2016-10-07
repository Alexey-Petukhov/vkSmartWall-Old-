using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace vkSmartWall
{
    class User
    {
        private int uid = 0;
        private String first_name = "";
        private String last_name = "";
        private List<User> friends = null;

        /*public User()
        {
            this.uid = 0;
        }*/
        public User(int uid)
        {
            this.uid = uid;
        }


        public String GetFirstname()
        {
            return this.first_name;
        }

        public void SetFirstname(String first_name)
        {
            this.first_name = first_name;
        }

        public String GetLastname()
        {
            return this.last_name;
        }

        public void SetLastname(String last_name)
        {
            this.last_name = last_name;
        }

        public List<User> GetFriends()
        {
            return this.friends;
        }

        public void SetFriends(List<User> friends)
        {
            this.friends = friends;
        }

        public int GetUid()
        {
            return this.uid;
        }

        public void SetUid(int uid)
        {
            this.uid = uid;
        }




        /*public void SayHello()
        {
            Console.WriteLine("Hello, my ID is " + this.uid);
        }*/

        /*public String getUserInfo()
        {
            //String url = "https://api.vk.com/method/users.get?user_ids=42560016,71985644,mr.pavlichenkov";
            return "";
        } */
   
    }

    public class UserBaseInfo
    {
        public int uid { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
    }

    public class RootUserBaseInfo
    {
        public List<UserBaseInfo> response { get; set; }
    }

    public class FriendsIdsList
    {
        public List<int> response { get; set; }
    }
}
