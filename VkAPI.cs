using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using Newtonsoft.Json;


namespace vkSmartWall
{
    class VkAPI
    {
        private WebRequest req = null;
        private WebResponse resp = null;
        private Stream stream = null;
        private StreamReader sr = null;

        private String baseUrl = "";
        //private String groupId = "csu_iit";

        public VkAPI()
        {
            this.baseUrl = "https://api.vk.com/method/";
        }

        public List<User> GetMembers(String groupId) // of group by groupId or groupName
        {
            String url = baseUrl + "groups.getMembers?group_id=" + groupId;
            String jsonAnswer = DoReq(url);

            RootGroupMembers memb = JsonConvert.DeserializeObject<RootGroupMembers>(jsonAnswer);
            List<User> users = new List<User>();
            Group group = new Group(groupId);
            group.SetCount(memb.response.count);
            foreach (var uid in memb.response.users)
            {
                users.Add(GetUserInfo(uid.ToString()));               
            }
            group.SetUsers(users);
            return group.GetUsers(); // memb.response.users;
            
        }

        public /*String*/ User GetUserInfo(String uid) // of user by uid
        {
            String url = baseUrl + "users.get?user_ids=" + uid;
            String jsonAnswer = DoReq(url);
            RootUserBaseInfo uBaseInfo = JsonConvert.DeserializeObject<RootUserBaseInfo>(jsonAnswer);
            User user = null;
            foreach (var u in uBaseInfo.response) // in fact just uBaseInfo.response[0]
            {
                user = new User(u.uid);
                //user.SetUid(u.uid);
                user.SetFirstname(u.first_name);
                user.SetLastname(u.last_name);
            }
            return user;

        }


        public List<User> GetFriends(String uid) // of user by uid
        {
            String url = baseUrl + "friends.get?user_id=" + uid;
            String jsonAnswer = DoReq(url);
            FriendsIdsList friendIds = JsonConvert.DeserializeObject<FriendsIdsList>(jsonAnswer);
            List<User> friends = new List<User>();
            foreach (var u in friendIds.response)
            {
                friends.Add(GetUserInfo(u.ToString()));
            }

            return friends;

        }

        public String /*WallItem*/ GetWallItems(String uid) // of user by uid
        {
            String url = baseUrl + "wall.get?owner_id=" + uid;
            String jsonAnswer = DoReq(url);
            return DoReq(url);

        }

        public String DoReq(String url)
        {
            

            req = WebRequest.Create(url);
            resp = req.GetResponse();
            stream = resp.GetResponseStream();
            sr = new StreamReader(stream);
            string Out = sr.ReadToEnd();
            sr.Close();

            req = null; resp = null; stream = null; sr = null;
            //Console.WriteLine(Out);
            return Out;
        }
    }
}
