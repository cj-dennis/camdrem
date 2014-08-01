using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Data
{
    public class multimediaResource
    {
        private int m_resourceID;
        private String m_resourceType;
        private String m_resourcePath;

        private static Dictionary<int, String> m_validTypes;

        public multimediaResource(String _resourceType, String _resourcePath)
        {
            resourceType = _resourceType;
            resourcePath = _resourcePath;
        }

        internal multimediaResource(int _resourceID, String _resourceType, String _resourcePath)
        {
            resourceID = _resourceID;
            resourceType = _resourceType;
            resourcePath = _resourcePath;
        }

        public String resourceType
        {
            get
            {
                return m_resourceType;
            }
            set
            {
                m_resourceType = value;
            }
        }

        public String resourcePath
        {
            get
            {
                return m_resourcePath;
            }
            set
            {
                m_resourcePath = value;
            }
        }

        internal int resourceID
        {
            get
            {
                return m_resourceID;
            }
            set
            {
                m_resourceID = value;
            }
        }

        internal Dictionary<int, String> validTypes
        {
            get
            {
                return m_validTypes;
            }
            set
            {
                m_validTypes = value;
            }

        }
        internal Boolean add_valid_type(int _typeID, String _typeName)
        {
            if (!validTypes.ContainsKey(_typeID) && !validTypes.ContainsValue(_typeName))
            {
                validTypes.Add(_typeID, _typeName);
                return true;
            }
            else
            {
                return false;
            }
        }

        internal Boolean remove_valid_type(int _typeID, String _typeName)
        {
            if (validTypes.ContainsKey(_typeID) && validTypes[_typeID] == _typeName)
            {
                validTypes.Remove(_typeID);
                return true;
            }
            else
            {
                return false;
            }
        }

    }

    public class User
    {
        private int m_userID;
        private String m_userName;
        private String m_password;
        private Progress m_userProgress;
        private Schedule m_userSchedule;

        internal User(int _userID, String _userName, String _password)
        {
            userID = _userID;
            userName = _userName;
            password = _password;
        }

        internal User(int _userID, String _userName, String _password, Progress _progress, Schedule _schedule)
        {
            userID = _userID;
            userName = _userName;
            password = _password;
            UserProgress = _progress;
            UserSchedule = _schedule;
        }

        public User(String _userName, String _password)
        {
            userName = _userName;
            password = _password;
        }

        public User( String _userName, String _password, Progress _progress, Schedule _schedule)
        {
            userName = _userName;
            password = _password;
            UserProgress = _progress;
            UserSchedule = _schedule;
        }

        public String userName
        {
            get
            {
                return m_userName;
            }
            set
            {
                m_userName = value;
            }
        }

        internal int userID
        {
            get
            {
                return m_userID;
            }
            set
            {
                m_userID = value;
            }
        }

        internal String password
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

        public Progress UserProgress
        {
            get { return m_userProgress; }
            set { m_userProgress = value; }
        }

        public Schedule UserSchedule
        {
            get { return m_userSchedule; }
            set { m_userSchedule = value; }
        }
    }

    public class Card
    {
        private int cardID;
        private String frontText;
        private string backText;
        private multimediaResource frontResource;
        private multimediaResource backResource;

        internal Card(int _cardID, String _frontText, String _backText, multimediaResource _frontResource, multimediaResource _backResource)
        {
            cardID = _cardID;
            frontText = _frontText;
            backText = _backText;
            frontResource = _frontResource;
            backResource = _backResource;
        }

        public Card(String _frontText, String _backText, multimediaResource _frontResource, multimediaResource _backResource)
        {
            frontText = _frontText;
            backText = _backText;
            frontResource = _frontResource;
            backResource = _backResource;
        }

        internal int CardID
        {
            get { return cardID; }
            set { cardID = value; }
        }

        public String FrontText
        {
            get { return frontText; }
            set { frontText = value; }
        }

        public string BackText
        {
            get { return backText; }
            set { backText = value; }
        }

        public multimediaResource FrontResource
        {
            get { return frontResource; }
            set { frontResource = value; }
        }

        public multimediaResource BackResource
        {
            get { return backResource; }
            set { backResource = value; }
        }
    }

    public class Deck
    {
        private int m_deckID;
        private String m_deckName;
        private String m_deckDescription;
        private List<Card> m_cards;

        
         internal Deck(int _deckID, String _deckName, String _deckDescription, List<Card> _cards)
        {
            deckID = _deckID;
            deckName = _deckName;
            deckDescription = _deckDescription;
            cards = _cards;
        }

        
        internal Deck(int _deckID, String _deckName, String _deckDescription)
        {
            deckID = _deckID;
            deckName = _deckName;
            deckDescription = _deckDescription;
            cards = new List<Card>();
        }

        public Deck(String _deckName, String _deckDescription, List<Card> _cards)
        {
            deckName = _deckName;
            deckDescription = _deckDescription;
            cards = _cards;
        }

        public Deck(String _deckName, String _deckDescription)
        {
            deckName = _deckName;
            deckDescription = _deckDescription;
            cards = new List<Card>();
        }

        //TODO: make this method internal
        public int deckID
        {
            get { return m_deckID; }
            set { m_deckID = value; }
        }

        public String deckName
        {
            get { return m_deckName; }
            set { m_deckName = value; }
        }

        public String deckDescription
        {
            get { return m_deckDescription; }
            set { m_deckDescription = value; }
        }

        public List<Card> cards
        {
            get { return m_cards; }
            set { m_cards = value; }
        }
    }

    public class ProgressRecord
    {
        private int recordID;
        private Card recordCard;
        private DateTime recordDate;
        private int recallRating;

        private static Dictionary<int, String> validRecalls;

        internal ProgressRecord(int _recordID, Card _recordCard, DateTime _recordDate, int _recallRating)
        {
            recordID = _recordID;
            recordCard = _recordCard;
            RecordDate = _recordDate;
            if (validRecalls.ContainsKey(_recallRating))
            {
                recallRating = _recallRating;
            }
            else
            {
                throw new System.ArgumentException("recall rating set to invlaid value", "_recallRating");
            }
        }

        public ProgressRecord(Card _recordCard, DateTime _recordDate, int _recallRating)
        {
            recordCard = _recordCard;
            RecordDate = _recordDate;
            if (validRecalls.ContainsKey(_recallRating))
            {
                recallRating = _recallRating;
            }
            else
            {
                throw new System.ArgumentException("recall rating set to invlaid value", "_recallRating");
            }
        }

        internal int RecordID
        {
            get { return recordID; }
            set { recordID = value; }
        }

        public Card RecordCard
        {
            get { return recordCard; }
            set { recordCard = value; }
        }

        public DateTime RecordDate
        {
            get { return recordDate; }
            set { recordDate = value; }
        }

        public int RecallRating
        {
            get { return recallRating; }
            set { recallRating = value; }
        }

        internal static Dictionary<int, String> ValidRecalls
        {
            get { return ProgressRecord.validRecalls; }
            set { ProgressRecord.validRecalls = value; }
        }
    }

    public class Progress
    {
        private System.Collections.ArrayList progressRecords;

        public Progress()
        {
            progressRecords = new System.Collections.ArrayList();
        }

        public System.Collections.ArrayList ProgressRecords
        {
            get { return progressRecords; }
            set { progressRecords = value; }
        }

    }

    public class ScheduleRecord
    {
        private Card recordCard;

        public Card RecordCard
        {
            get { return recordCard; }
            set { recordCard = value; }
        }
        private DateTime recordDate;

        public DateTime RecordDate
        {
            get { return recordDate; }
            set { recordDate = value; }
        }

        public ScheduleRecord(Card _card, DateTime _date)
        {
            recordCard = _card;
            RecordDate = _date;
        }

    }

    public class Schedule
    {
        private System.Collections.ArrayList scheduleRecords;

        public Schedule()
        {
            scheduleRecords = new System.Collections.ArrayList();
        }

        public System.Collections.ArrayList ScheduleRecords
        {
            get { return scheduleRecords; }
            set { scheduleRecords = value; }
        }
    }

}
namespace DBManager
{
    public class DataAccessManager {
         private static System.Data.SqlClient.SqlConnection camdremConnection = new System.Data.SqlClient.SqlConnection("Data Source=TD-PC\\BSSFORD2012_1;Initial Catalog=camdremData;Integrated Security=True");

         /*Basic row creation syntax
          * try
                 {
                     camdremConnection.Open();
                     SqlCommand createCommand = new SqlCommand(" ", camdremConnection);
                     SqlParameter userNameParamater = new SqlParameter("@usernameParameter", _user.userName);
                     createCommand.Parameters.Add(userNameParamater);

                     createCommand.ExecuteNonQuery();
                 }
                 catch (Exception e)
                 {
                     throw new ArgumentException("Cannot create user with current Parameters", e);
                 }finally{
                     if ( camdremConnection.State == System.Data.ConnectionState.Open ){
                         camdremConnection.Close();
                     }
                 }
          *
          */

         public class UserDBManager{

            public static Data.User getUserByName( String _name )
            {
                Data.User requestedUser = null;

                try
                {
                    camdremConnection.Open();

                    SqlCommand getUserCommand = new SqlCommand(" SELECT userID, userName, userPassword "
                                                                + " FROM camdremData.allData.Users "
                                                                + " WHERE userName = @userNameParam; ", camdremConnection);

                    SqlParameter userNameParam = new SqlParameter("@userNameParam", _name);
                    getUserCommand.Parameters.Add(userNameParam);

                    SqlDataReader userReader = getUserCommand.ExecuteReader();

                    if (userReader.Read())
                    {
                        requestedUser = new Data.User(userReader.GetInt32(0), userReader.GetString(1), userReader.GetString(2) );
                    }
                }
                catch (Exception e)
                {
                    throw new ArgumentException("User could not be retrived from database", e);
                }
                finally
                {
                    if (camdremConnection.State == System.Data.ConnectionState.Open)
                    {
                        camdremConnection.Close();
                    }
                }
                return requestedUser;
            }

            public static Data.User getUserByID(int _userID)
            {
                Data.User requestedUser = null;

                try
                {
                    camdremConnection.Open();

                    SqlCommand getUserCommand = new SqlCommand(" SELECT userID, userName, userPassword "
                                                                + " FROM camdremData.allData.Users "
                                                                + " WHERE userID = @userIDParam; ", camdremConnection);

                    SqlParameter userIDParam = new SqlParameter("@userIDParam", _userID);
                    getUserCommand.Parameters.Add(userIDParam);

                    SqlDataReader userReader = getUserCommand.ExecuteReader();

                    if (userReader.Read())
                    {
                        requestedUser = new Data.User(userReader.GetInt32(0), userReader.GetString(1), userReader.GetString(2));
                    }
                }
                catch (Exception e)
                {
                    throw new ArgumentException("User could not be retrived from database", e);
                }
                finally
                {
                    if (camdremConnection.State == System.Data.ConnectionState.Open)
                    {
                        camdremConnection.Close();
                    }
                }
                return requestedUser;
            }

            public static List<String> getAllUserNames()
            {
                List<String> userNames = new List<String>();

                try
                {
                    camdremConnection.Open();

                    SqlCommand getUsernameCommand = new SqlCommand(" SELECT userName "
                                                                    + " FROM camdremData.allData.Users; ", camdremConnection);

                    SqlDataReader userNameReader = getUsernameCommand.ExecuteReader();

                    while (userNameReader.Read())
                    {
                        userNames.Add(userNameReader.GetString(0));
                    }
             
                }
                catch (Exception e)
                {
                    throw new InvalidOperationException("Could not retrieve user names", e);
                }
                finally
                {
                    if (camdremConnection.State == System.Data.ConnectionState.Open)
                    {
                        camdremConnection.Close();
                    }
                }

                return userNames;
            }

            public static List<int> getAllUserIDs()
            {
                List<int> userIds = new List<int>();

                try
                {
                    camdremConnection.Open();

                    SqlCommand getUserIDCommand = new SqlCommand(" SELECT userID "
                                                                + " FROM camdremData.allData.Users; ", camdremConnection);

                    SqlDataReader userIDReader = getUserIDCommand.ExecuteReader();

                    while (userIDReader.Read())
                    {
                        userIds.Add(userIDReader.GetInt32(0));
                    }

                }
                catch (Exception e)
                {
                    throw new InvalidOperationException("Could not retrieve user names", e);
                }
                finally
                {
                    if (camdremConnection.State == System.Data.ConnectionState.Open)
                    {
                        camdremConnection.Close();
                    }
                }

                return userIds;
            }

            public static Boolean updateUser(Data.User _user)
            {
                Boolean successFlag = false;

                try
                {
                    camdremConnection.Open();

                    SqlCommand updateUserCommand = new SqlCommand(" UPDATE camdremData.allData.Users "
                                                                + " SET userName = @userNameParam "
                                                                + " WHERE userID = @userIDParam;", camdremConnection);
                    SqlParameter userNameParam = new SqlParameter("@userNameParam", _user.userName);
                    SqlParameter userIDParam = new SqlParameter("@userIDParam", _user.userID);

                    updateUserCommand.Parameters.Add(userNameParam);
                    updateUserCommand.Parameters.Add(userIDParam);

                    updateUserCommand.ExecuteNonQuery();

                    successFlag = true;
                }
                catch (Exception e)
                {
                    throw new InvalidOperationException("user could not be updated at this time", e);
                }
                finally
                {
                    if (camdremConnection.State == System.Data.ConnectionState.Open)
                    {
                        camdremConnection.Close();
                    }
                }
                return successFlag;
            }

            public static Boolean createNewUser( Data.User _user )
            {
                Boolean successFlag = false;

                try
                {
                    camdremConnection.Open();

                    SqlCommand createCommand = new SqlCommand(" BEGIN TRAN; INSERT INTO "
                                                              + " camdremData.allData.Users( userName, userPassword) "
                                                              + " VALUES (@userNameParameter, @userPassParameter); "
                                                              + " SELECT userID FROM camdremData.allData.Users "

                                                              + " WHERE userName = @userNameParameter; COMMIT TRAN", camdremConnection);

                    SqlParameter userNameParameter = new SqlParameter("@userNameParameter", _user.userName);
                    SqlParameter userPassParameter = new SqlParameter("@userPassParameter", _user.password);
                    createCommand.Parameters.Add(userNameParameter);
                    createCommand.Parameters.Add(userPassParameter);

                    SqlDataReader idReader = createCommand.ExecuteReader();

                    if (idReader.Read())
                    {
                        _user.userID = idReader.GetInt32(0);
                        successFlag = true;
                    }

                }
                catch (Exception e)
                {
                    throw new ArgumentException("Cannot create user with current parameters", e);
                }finally{
                    if ( camdremConnection.State == System.Data.ConnectionState.Open ){
                        camdremConnection.Close();
                    }
                }

                return successFlag;
            }

            public static Boolean deleteUser(Data.User _user)
            {
                Boolean successFlag = false;

                try
                {
                    camdremConnection.Open();

                    SqlCommand deleteUserCommand = new SqlCommand(" DELETE FROM camdremData.allData.Users "
                                                                + " WHERE userID = @userIDParam; ", camdremConnection);

                    SqlParameter userIdParam = new SqlParameter("@userIDParam", _user.userID);

                    deleteUserCommand.Parameters.Add(userIdParam);

                    deleteUserCommand.ExecuteNonQuery();

                    successFlag = true;
                }
                catch (Exception e)
                {
                    throw new ArgumentException("Given user could not be deleted", e);
                }
                finally
                {
                    if (camdremConnection.State == System.Data.ConnectionState.Open)
                    {
                        camdremConnection.Close();
                    }
                }
                return successFlag;
            }

            

        }
        public class CardDBManager{
            public static Data.Card getCardById( int _id )
            {
                Data.Card requestedCard = null;
                try
                {
                    camdremConnection.Open();

                    SqlParameter cardIDParam = new SqlParameter("@cardIDParam", _id);
                    SqlCommand getCommand = new SqlCommand("SELECT cardID, frontText, backText "
                                                        + " FROM camdremData.allData.Cards "
                                                        + " WHERE cardID = @cardIDParam; ", camdremConnection);
                    getCommand.Parameters.Add(cardIDParam);

                    SqlDataReader cardReader = getCommand.ExecuteReader();

                    if (cardReader.Read())
                    {
                        requestedCard = new Data.Card(cardReader.GetInt32(0), cardReader.GetString(1), cardReader.GetString(2), null, null);
                    }
                }
                catch(Exception e)
                {
                    throw new ArgumentException("Could not retrieve card with given id", e);
                }
                finally
                {
                    if (camdremConnection.State == System.Data.ConnectionState.Open)
                    {
                        camdremConnection.Close();
                    }
                }
                return requestedCard;
            }

            public static Boolean addCardToDeck( Data.Card _card, Data.Deck _deck ){
                Boolean successFlag = false;

                try
                {
                    camdremConnection.Open();
                    SqlParameter cardIDParam = new SqlParameter("@cardIDParam", _card.CardID);
                    SqlParameter deckIDParam = new SqlParameter("@deckIDParam", _deck.deckID);
                    SqlCommand addCommand = new SqlCommand(" INSERT INTO camdremData.allData.DeckCardLookUp(cardID, deckID) "
                                                        + " VALUES ( @cardIDParam, @deckIDParam );", camdremConnection);
                    addCommand.Parameters.Add(cardIDParam);
                    addCommand.Parameters.Add(deckIDParam);

                    if (addCommand.ExecuteNonQuery() > 0)
                    {
                        successFlag = true;
                    }
                }
                catch (Exception e)
                {
                    throw new ArgumentException("could not add given card to given deck", e);
                }
                finally
                {
                    if (camdremConnection.State == System.Data.ConnectionState.Open)
                    {
                        camdremConnection.Close();
                    }
                }
                return successFlag;
            }

            public static List<Data.Card> getCardsByDeck( Data.Deck _deck)
            {
                List<Data.Card> requestedCards = new List<Data.Card>();

                try
                {
                    camdremConnection.Open();

                    SqlParameter deckIDParam = new SqlParameter("@deckIDParam", _deck.deckID);
                    SqlCommand getCommand = new SqlCommand(" SELECT c.cardID, c.frontText, c.backText "
                                                        + " FROM camdremData.allData.Cards AS c"
                                                        + " JOIN camdremData.allData.DeckCardLookUp AS l"
                                                        + " ON l.deckID = @deckIDParam; ", camdremConnection);
                    getCommand.Parameters.Add(deckIDParam);

                    SqlDataReader cardReader = getCommand.ExecuteReader();

                    while (cardReader.Read())
                    {
                        requestedCards.Add( new Data.Card( cardReader.GetInt32(0), cardReader.GetString(1), cardReader.GetString(2), null , null ) );
                    }
                }
                catch(Exception e)
                {
                    throw new ArgumentException("could get not cards for given deck", e);
                }
                finally
                {
                    if (camdremConnection.State == System.Data.ConnectionState.Open )
                    {
                        camdremConnection.Close();
                    }
                }

                return requestedCards;
            }

            public static List<Data.Card> getCardsBySchedule(DateTime _date)
            {
                return null;
            }

            public static List<Data.Card> getCardsBySchedule(DateTime _startDate, DateTime _endDate)
            {
                return null;
            }

            public static List<Data.Card> getCardsByProgressDate(DateTime _date)
            {
                return null;
            }

            public static Boolean createNewCard(Data.Card _card)
            {
                Boolean successFlag = false;


                try
                {
                    camdremConnection.Open();

                    SqlParameter frontParam = new SqlParameter("@frontParam", _card.FrontText);
                    SqlParameter backParam = new SqlParameter("@backParam", _card.BackText);
                    SqlCommand insertCommand = new SqlCommand(" BEGIN TRAN; INSERT INTO camdremData.allData.Cards(frontText, backText) "
                                                            + " VALUES (@frontParam, @backParam); "
                                                            + " SELECT SCOPE_IDENTITY(); COMMIT TRAN;", camdremConnection);

                    insertCommand.Parameters.Add(frontParam);
                    insertCommand.Parameters.Add(backParam);

                    SqlDataReader idReader = insertCommand.ExecuteReader();

                    if (idReader.Read())
                    {
                        _card.CardID = (int)idReader.GetDecimal(0);
                        successFlag = true;
                    }
                }
                catch (Exception e)
                {
                    throw new ArgumentException("could not create given card", e);
                }
                finally
                {
                    if (camdremConnection.State == System.Data.ConnectionState.Open)
                    {
                        camdremConnection.Close();
                    }
                }
                return successFlag;
            }

            public static Boolean updateCard(Data.Card _card)
            {
                Boolean successFlag = false;

                try
                {
                    camdremConnection.Open();

                    SqlParameter cardIDParam = new SqlParameter("@cardIDParam", _card.CardID);
                    SqlParameter frontText = new SqlParameter("@frontText", _card.FrontText);
                    SqlParameter backText = new SqlParameter("@backText", _card.BackText);
                    SqlCommand updateCommand = new SqlCommand(" UPDATE camdremData.allData.Cards "
                                                            + " SET frontText = @frontText, backText=@backText "
                                                            + " WHERE cardID=@cardIDParam; ", camdremConnection);
                    updateCommand.Parameters.Add(cardIDParam);
                    updateCommand.Parameters.Add(frontText);
                    updateCommand.Parameters.Add(backText);

                    if (updateCommand.ExecuteNonQuery() > 0){
                        successFlag = true;
                    }
                }
                catch(Exception e)
                {
                    throw new ArgumentException("could not update given card", e);
                }
                finally
                {
                    if (camdremConnection.State == System.Data.ConnectionState.Open)
                    {
                        camdremConnection.Close();
                    }
                }
                return successFlag;
            }

            public static Boolean removeCardFromDeck(Data.Card _card, Data.Deck _deck)
            {
                Boolean successFlag = false;

                try
                {
                    camdremConnection.Open();

                    SqlParameter cardIDParam = new SqlParameter("@cardIDParam", _card.CardID);
                    SqlParameter deckIDParam = new SqlParameter("@deckIDParam", _deck.deckID);
                    SqlCommand removeCommand = new SqlCommand(" DELETE FROM camdremData.allData.DeckCardLookUp "
                                                            + " WHERE (cardID=@cardIDParam and deckID = @deckIDParam); ", camdremConnection);

                    removeCommand.Parameters.Add(cardIDParam);
                    removeCommand.Parameters.Add(deckIDParam);

                    if (removeCommand.ExecuteNonQuery() > 0)
                    {
                        successFlag = true;
                    }
                }
                catch (Exception e)
                {
                    throw new ArgumentException("could not remove given card from given deck", e);
                }
                finally
                {
                    if (camdremConnection.State == System.Data.ConnectionState.Open)
                    {
                        camdremConnection.Close();
                    }
                }
                return successFlag;
            }

            public static Boolean deleteCard(Data.Card _card)
            {
                Boolean successFlag = false;

                try
                {
                    camdremConnection.Open();

                    SqlParameter cardIDParam = new SqlParameter("@cardIDParam", _card.CardID);
                    SqlCommand deleteCommand = new SqlCommand(" DELETE FROM camdremData.allData.Cards "
                                                            + " WHERE cardID = @cardIDParam;", camdremConnection);
                    deleteCommand.Parameters.Add(cardIDParam);

                    if (deleteCommand.ExecuteNonQuery() > 0)
                    {
                        successFlag = true;
                    }
                }
                catch (Exception e)
                {
                    throw new ArgumentException("could not delete given card", e);
                }
                finally
                {
                    if (camdremConnection.State == System.Data.ConnectionState.Open)
                    {
                        camdremConnection.Close();
                    }
                }
                return successFlag;
            }

        }
        public class DeckDBManager{
           
            public static Data.Deck getDeckByID( int _id)
            {
                Data.Deck requestedDeck = null;

                try
                {
                    camdremConnection.Open();

                    SqlCommand getCommand = new SqlCommand(" SELECT deckID, deckName, deckDescription "
                                                        + " FROM camdremData.allData.Decks "
                                                        + " WHERE deckID = @deckIDParam;", camdremConnection);
                    SqlParameter deckIDParam = new SqlParameter("@deckIDParam", _id);

                    getCommand.Parameters.Add(deckIDParam);

                    SqlDataReader idReader = getCommand.ExecuteReader();

                    if (idReader.Read())
                    {
                        requestedDeck = new Data.Deck(idReader.GetInt32(0), idReader.GetString(1), idReader.GetString(2));
                    }
                }
                catch (Exception e)
                {
                    throw new ArgumentException("cannot get requested deck", e);
                }
                finally
                {
                    if (camdremConnection.State == System.Data.ConnectionState.Open)
                    {
                        camdremConnection.Close();
                    }
                }

                return requestedDeck;
            }
            
            public static List<Data.Deck> getDecksByUser( Data.User _user)
            {
                List<Data.Deck> userDecks = new List<Data.Deck>();

                try
                {
                    camdremConnection.Open();

                    SqlCommand userDecksCommand = new SqlCommand(" SELECT a.deckID, a.deckName, a.deckDescription "
                                                                + " FROM camdremData.allData.Decks AS a "
                                                                + " JOIN camdremData.allData.UserDeckLookUp AS b "
                                                                + " ON b.deckID = a.deckID "
                                                                + " WHERE b.userID = @userIDParam;", camdremConnection);

                    SqlParameter userIDParam = new SqlParameter("@userIDParam", _user.userID);

                    userDecksCommand.Parameters.Add(userIDParam);

                    SqlDataReader deckReader = userDecksCommand.ExecuteReader();

                    while (deckReader.Read())
                    {
                        userDecks.Add( new Data.Deck(deckReader.GetInt32(0), deckReader.GetString(1), deckReader.GetString(2) ) );
                    }
                }
                catch (Exception e)
                {
                    throw new ArgumentException("Could not get decks associated with given user", e);
                }
                finally
                {
                    if ( camdremConnection.State== System.Data.ConnectionState.Open){
                        camdremConnection.Close();
                    }
                }

                return userDecks;
            }

            public static Boolean createNewDeck(Data.Deck _deck)
            {
                Boolean successFlag = false;

                try
                {
                    camdremConnection.Open();

                    SqlCommand createCommand = new SqlCommand(" BEGIN TRAN; INSERT INTO "
                                                              + " camdremData.allData.Decks( deckName, deckDescription) "
                                                              + " VALUES (@deckNameParameter, @deckDescParameter); "
                                                              + " SELECT SCOPE_IDENTITY(); COMMIT TRAN", camdremConnection);

                    SqlParameter deckNameParameter = new SqlParameter("@deckNameParameter", _deck.deckName);
                    SqlParameter deckDescParameter = new SqlParameter("@deckDescParameter", _deck.deckDescription);
                    createCommand.Parameters.Add(deckNameParameter);
                    createCommand.Parameters.Add(deckDescParameter);

                    SqlDataReader idReader = createCommand.ExecuteReader();

                    if (idReader.Read())
                    {
                        _deck.deckID = (int)idReader.GetDecimal(0);
                        successFlag = true;
                    }

                }
                catch (Exception e)
                {
                    throw new ArgumentException("Cannot create deck with current parameters", e);
                }
                finally
                {
                    if (camdremConnection.State == System.Data.ConnectionState.Open)
                    {
                        camdremConnection.Close();
                    }
                }

                return successFlag;
            }

            public static Boolean updateDeck(Data.Deck _deck)
            {
                Boolean successFlag = false;

                try
                {
                    camdremConnection.Open();

                    SqlParameter deckIDParam = new SqlParameter("@deckIDParam", _deck.deckID);
                    SqlParameter deckNameParam = new SqlParameter("@deckNameParam", _deck.deckName);
                    SqlParameter deckDescParam = new SqlParameter("@deckDescParam", _deck.deckDescription);

                    SqlCommand updateCommand = new SqlCommand(" UPDATE camdremData.allData.Decks "
                                                            + " SET deckName = @deckNameParam, deckDescription = @deckDescParam "
                                                            + " WHERE deckID = @deckIDParam; ", camdremConnection);
                    updateCommand.Parameters.Add(deckIDParam);
                    updateCommand.Parameters.Add(deckNameParam);
                    updateCommand.Parameters.Add(deckDescParam);

                    if (updateCommand.ExecuteNonQuery() > 0)
                    {
                        successFlag = true;
                    }


                }
                catch (Exception e)
                {
                    throw new ArgumentException("could not update given deck", e);
                }
                finally
                {
                    if (camdremConnection.State == System.Data.ConnectionState.Open)
                    {
                        camdremConnection.Close();
                    }
                }

                return successFlag;
            }

            public static Boolean addDeckToUser(Data.User _user, Data.Deck _deck)
            {
                Boolean successFlag = false;
                try
                {
                    camdremConnection.Open();

                    SqlCommand addDeckCommand = new SqlCommand(" INSERT INTO camdremData.allData.UserDeckLookUp( deckID, userID) "
                                                            + " VALUES ( @deckIDParam, @userIDParam);", camdremConnection);

                    SqlParameter deckIDParam = new SqlParameter("@deckIDParam", _deck.deckID);
                    SqlParameter userIDParam = new SqlParameter("@userIDParam", _user.userID);

                    addDeckCommand.Parameters.Add(deckIDParam);
                    addDeckCommand.Parameters.Add(userIDParam);

                    addDeckCommand.ExecuteNonQuery();
                    successFlag = true;
                }
                catch (Exception e)
                {
                    throw new ArgumentException("Could not asscoiate given deck to given user", e);
                }
                finally
                {
                    if (camdremConnection.State == System.Data.ConnectionState.Open)
                    {
                        camdremConnection.Close();
                    }
                }

                return successFlag;
            }

            public static Boolean removeDeckFromUser(Data.Deck _deck, Data.User _user)
            {
                Boolean successFlag = false;

                try
                {
                    camdremConnection.Open();

                    SqlParameter userIDParam = new SqlParameter("@userIDParam", _user.userID);
                    SqlParameter deckIDParam = new SqlParameter("@deckIDParam", _deck.deckID);
                    SqlCommand removeCommand = new SqlCommand(" DELETE FROM camdremData.allData.UserDeckLookUp "
                                                            + " WHERE (userID = @userIDParam AND deckID = @deckIDParam);", camdremConnection);

                    removeCommand.Parameters.Add(userIDParam);
                    removeCommand.Parameters.Add(deckIDParam);

                    if (removeCommand.ExecuteNonQuery() > 0)
                    {
                        successFlag = true;
                    }
                }
                catch (Exception e)
                {
                    throw new ArgumentException("could not remove given deck from given user", e);
                }
                finally
                {
                    if (camdremConnection.State == System.Data.ConnectionState.Open)
                    {
                        camdremConnection.Close();
                    }
                }

                return successFlag ;
            }

            public static Boolean deleteDeck(Data.Deck _deck)
            {
                Boolean successFlag = false;

                try{
                    camdremConnection.Open();

                    SqlParameter deckIDParam = new SqlParameter("@deckIDParam", _deck.deckID);
                    SqlCommand deleteCommand = new SqlCommand(" DELETE FROM camdremData.allData.Decks "
                                                            + " WHERE deckID = @deckIDParam; ", camdremConnection);

                    deleteCommand.Parameters.Add(deckIDParam);

                    if (deleteCommand.ExecuteNonQuery() > 0)
                    {
                        successFlag = true;
                    }
                }
                catch(Exception e){
                    throw new ArgumentException("could not delete given deck", e);
                }finally{
                    if(camdremConnection.State == System.Data.ConnectionState.Open){
                        camdremConnection.Close();
                    }
                }

                return successFlag;
            }
        }
        public class ScheduleDBManager{
            public static Data.Schedule getScheduleByUser(Data.User _user)
            {
                return null;
            }

            public static Data.ScheduleRecord getRecordByID(int _id)
            {
                return null;
            }

            public static List<Data.ScheduleRecord> getRecordsByCardUser(Data.Card _card, Data.User _user)
            {
                return null;
            }

            public static Boolean createNewRecord(Data.User _user, Data.Schedule _record)
            {
                return false;
            }

            public static Boolean updateRecord(Data.User _user, Data.ScheduleRecord _record)
            {
                return false;
            }

            public static Boolean deleteRecord(Data.ScheduleRecord _record)
            {
                return false;
            }

        }
        public class ProgressDBManager
        {
            public static Boolean createNewRecord( Data.User _user, Data.ProgressRecord _record )
            {
                return false;
            }

            public static Data.Progress getProgressByUser(Data.User _user) 
            {
                return null;
            }

            public static Data.ProgressRecord getRecordByID(int _id)
            {
                return null;
            }

            public static List<Data.ProgressRecord> getRecordsByCardUser(Data.Card _card, Data.User _user)
            {
                return null;
            }

            public static Boolean updateRecord(Data.ProgressRecord _record)
            {
                return false;
            }

            public static Boolean deleteRecord(Data.ProgressRecord _record)
            {
                return false;
            }
        }

    }
}
