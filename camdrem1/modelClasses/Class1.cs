using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBManager;
using Data;

namespace modelClasses
{
    public class modelDeck{
    }
    public class modelCard{

    }
    public class modelUser {
        private int m_userID;
        private String m_name;
        private String m_password;
        private List<modelDeck> m_decks;

        public modelUser(int _id, String _name, String _password)
        {
            m_userID = _id;
            name = _name;
            password = _password;
        }

        public String name
        {
            get
            {
                return m_name;
            }
            set
            {
                m_name = value;
            }
        }

        public String password
        {
            get
            {
                return m_password;
            }
            set
            {
                m_password = value;
            }
        }

        public List<modelDeck> decks
        {
            get
            {
                return m_decks;
            }
            set
            {
                m_decks = value;
            }
        }

        public static modelUser authenticate(String _name, String _password)
        {
            modelUser requestedUser = null;

            //finds out if username and password match

            return requestedUser ;
        }

        public Boolean validatePassword(String _password)
        {
            return true;//check to see if password contains needed characters
        }

        public Boolean validateUserName(String _name)
        {
            return true;//check to see if username already exist
        }
    }
    public class DataFactories
    {
        public modelUser modelUserFactory(String _name){
            modelUser requestedUser = null;

            User dataUser = DataAccessManager.UserDBManager.getUserByName(_name);
            if (dataUser != null)
            {
               
            }

            return requestedUser;
        }
    }
}
