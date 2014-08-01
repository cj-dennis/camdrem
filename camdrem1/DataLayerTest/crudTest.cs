using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data;
using DBManager;
using System.Collections;
using System.Collections.Generic;

namespace DataLayerTest
{
    [TestClass]
    public class crudTest
    {
   /*
        [TestMethod]
        public void TestAccessManagerCreationandDestruction()
        {
            try
            {

                DataAccessManager testManager = new DataAccessManager();
                Assert.AreNotEqual(testManager, null);
            }
            catch (Exception e)
            {
                Assert.Fail("Exceptions were caught during manager creation:" + e.Message + Environment.NewLine + e.ToString() );
            }
        }

    */
        private User unitTestUser = new User("unitTestUser1", "");
        private String testUserName2 = "ChangedUnitTestUser1";
        private String deckName2 = "UpdatedUnitTest1";
        private String deckDesc2 = "Changed Deck Description";
        private Deck unitTestDeck = new Deck("unitTestDeck1", "Test Deck Description");
        //private int unitDeckID = 18;

        [TestMethod]
        public void testUserCreation()
        {
            try
            {
                Assert.IsTrue (  DataAccessManager.UserDBManager.createNewUser( unitTestUser ) );
            }
            catch(Exception e)
            {
                Assert.Fail("Exceptions were caught during user creation:" + e.Message + Environment.NewLine + e.ToString());
            }
        }

        [TestMethod]
        public void testgetUserByName()
        {
            try
            {
                User testUser = DataAccessManager.UserDBManager.getUserByName( unitTestUser.userName  );
                Assert.AreEqual(testUser.userName, unitTestUser.userName );
            }
            catch (Exception e)
            {
                Assert.Fail("Exceptions were caught during user retrival:" + e.Message + Environment.NewLine + e.ToString());
            }
        }

        /*
        [TestMethod]
        public void testgetUserById() //change to be done after an ID is finalized
        {
            try
            {
                User testUser = DataAccessManager.UserDBManager.getUserByID(14);
                Assert.AreNotEqual(testUser, null);
            }
            catch (Exception e)
            {
                Assert.Fail("Exceptions were caught during user retrival:" + e.Message + Environment.NewLine + e.ToString());
            }
        }
       */
        [TestMethod]
        public void testGetAllUserNames()
        {
            List<String> userNames = DataAccessManager.UserDBManager.getAllUserNames();

            Assert.IsNotNull(userNames);
            Assert.IsTrue(userNames.Count > 0);
        }

        [TestMethod]
        public void testGetAllUserIDs()
        {
            List<int> userIds = DataAccessManager.UserDBManager.getAllUserIDs();

            Assert.IsNotNull(userIds);
            Assert.IsTrue(userIds.Count > 0);
        }

        [TestMethod]
        public void testUpdateUser()
        {

            unitTestUser.userName = testUserName2;

            Assert.IsTrue(DataAccessManager.UserDBManager.updateUser( unitTestUser ));
            
        }


        //-------------------
        [TestMethod]
        public void testDeckCreation()
        {
            Assert.IsTrue( DataAccessManager.DeckDBManager.createNewDeck( unitTestDeck ) );
        }

/*
        [TestMethod]
        public void testGetDeckById()
        {
            Deck retrivedDeck = DataAccessManager.DeckDBManager.getDeckByID(7);

            Assert.AreEqual(retrivedDeck.deckID, 7);
            Assert.AreEqual(retrivedDeck.deckName, "unitTestDeck1");
            Assert.AreEqual(retrivedDeck.deckDescription, "Test Deck Description" );
        }
 */

        [TestMethod]
        public void testAddDeckTouser()
        {
            //Assert.IsTrue( DataAccessManager.UserDBManager.addDeckToUser( unitTestUser , unitTestDeck) );
            User testUser = DataAccessManager.UserDBManager.getUserByName(unitTestUser.userName);
            Deck testDeck = DataAccessManager.DeckDBManager.getDeckByID(18);
            Assert.IsTrue(DataAccessManager.DeckDBManager.addDeckToUser(testUser, testDeck));
        }

        [TestMethod]
        public void testGetDecksByUser()
        {
            List<Deck> userDecks =   DataAccessManager.DeckDBManager.getDecksByUser( DataAccessManager.UserDBManager.getUserByName( unitTestUser.userName) );
            Assert.IsTrue( userDecks.Count > 0 );
            Assert.IsTrue(userDecks[0].deckID == 18);
        }

        [TestMethod]
        public void testUpdateDeck()
        {
            Deck testDeck = DataAccessManager.DeckDBManager.getDeckByID(18 );

            testDeck.deckDescription = deckDesc2;
            testDeck.deckName = deckName2;
            Assert.IsTrue(DataAccessManager.DeckDBManager.updateDeck(testDeck));
            testDeck = DataAccessManager.DeckDBManager.getDeckByID(18);

            Assert.AreEqual(testDeck.deckName, deckName2);
            Assert.AreEqual(testDeck.deckDescription, deckDesc2);
        }


        //---------------------------
        private Card unitTestCard = new Card("unitTestFront1", "unitTestBack1", null, null);
        private String frontUpdatedText = "changeFrontText";
        private String backUpdatedText = "changeBackText";

        [TestMethod]
        public void testCreateCard()
        {
            Assert.IsTrue(DataAccessManager.CardDBManager.createNewCard(unitTestCard));
        }

        [TestMethod]
        public void testGetCardByID()
        {
            Card testCard =  DataAccessManager.CardDBManager.getCardById( 1013);
            Assert.AreEqual(testCard.FrontText, unitTestCard.FrontText);
            Assert.AreEqual(testCard.BackText, unitTestCard.BackText);

        }

        [TestMethod]
        public void testAddCardToDeck()
        {
            Card testCard = DataAccessManager.CardDBManager.getCardById(1013);
            Deck testDeck = DataAccessManager.DeckDBManager.getDeckByID(18);
            Assert.IsTrue( DataAccessManager.CardDBManager.addCardToDeck( testCard, testDeck)); 
        }

        [TestMethod]
        public void testGetCardsByDeck()
        {
            Deck testDeck = DataAccessManager.DeckDBManager.getDeckByID(18);

            List<Card> testCards = DataAccessManager.CardDBManager.getCardsByDeck( testDeck );
            Assert.IsTrue(testCards.Count > 0);
        }

        [TestMethod]
        public void testUpdateCard()
        {
            Card testCard = DataAccessManager.CardDBManager.getCardById(1013);
            testCard.FrontText = frontUpdatedText;
            testCard.BackText = backUpdatedText;

            Assert.IsTrue( DataAccessManager.CardDBManager.updateCard(testCard) );

            testCard = DataAccessManager.CardDBManager.getCardById(1013);
            Assert.AreEqual(testCard.FrontText, frontUpdatedText);
            Assert.AreEqual(testCard.BackText, backUpdatedText);
                
        }

        
        //Clean up Test
       
        [TestMethod]
        public void testRemoveCardFromDeck()
        {
            Card testCard = DataAccessManager.CardDBManager.getCardById(1013);
            Deck testDeck = DataAccessManager.DeckDBManager.getDeckByID(18);

            Assert.IsTrue(DataAccessManager.CardDBManager.removeCardFromDeck(testCard, testDeck));

            List<Card> testList = DataAccessManager.CardDBManager.getCardsByDeck(testDeck);

            Assert.IsTrue(testList.Count == 0);
        }

        [TestMethod]
        public void testDeleteCard()
        {
            Card testCard = DataAccessManager.CardDBManager.getCardById(1013);
            Assert.IsTrue( DataAccessManager.CardDBManager.deleteCard( testCard ) );
        }

        [TestMethod]
        public void testRemoveDeckFromUser()
        {
            User testUser = DataAccessManager.UserDBManager.getUserByID(31);
            Deck testDeck = DataAccessManager.DeckDBManager.getDeckByID(12);

            Assert.IsTrue(DataAccessManager.DeckDBManager.removeDeckFromUser(testDeck, testUser));

            Assert.IsTrue(DataAccessManager.DeckDBManager.getDecksByUser(testUser).Count == 0);

        }

        [TestMethod]
        public void testDeleteDeck()
        {
            Deck testDeck = DataAccessManager.DeckDBManager.getDeckByID(12);

            Assert.IsTrue(DataAccessManager.DeckDBManager.deleteDeck(testDeck));

            try
            {
                testDeck = DataAccessManager.DeckDBManager.getDeckByID(12);
                Assert.Fail();
            }
            catch
            {
       
            }
        }

        [TestMethod]
        public void testDeleteUser()
        {
            Assert.IsTrue(DataAccessManager.UserDBManager.deleteUser(unitTestUser));
        }
    }

        
}
