using Assignment3;

namespace Assignment3.Tests
{
    public class SerializationTests
    {
        private ILinkedListADT users;
        private readonly string testFileName = "test_users.bin";

        [SetUp]
        public void Setup()
        {
            this.users = new SLL();

            users.AddLast(new User(1, "Joe Blow", "jblow@gmail.com", "password"));
            users.AddLast(new User(2, "Joe Schmoe", "joe.schmoe@outlook.com", "abcdef"));
            users.AddLast(new User(3, "Colonel Sanders", "chickenlover1890@gmail.com", "kfc5555"));
            users.AddLast(new User(4, "Ronald McDonald", "burgers4life63@outlook.com", "mcdonalds999"));
        }

        [TearDown]
        public void TearDown()
        {
            this.users.Clear();
        }

        /// <summary>
        /// Tests the object was serialized.
        /// </summary>
        [Test]
        public void TestSerialization()
        {
            SerializationHelper.SerializeUsers(users, testFileName);
            Assert.IsTrue(File.Exists(testFileName));
        }

        /// <summary>
        /// Tests the object was deserialized.
        /// </summary>
        [Test]
        public void TestDeSerialization()
        {
            SerializationHelper.SerializeUsers(users, testFileName);
            ILinkedListADT deserializedUsers = SerializationHelper.DeserializeUsers(testFileName);

            Assert.IsTrue(users.Count() == deserializedUsers.Count());

            for (int i = 0; i < users.Count(); i++)
            {
                User expected = users.GetValue(i);
                User actual = deserializedUsers.GetValue(i);

                Assert.AreEqual(expected.Id, actual.Id);
                Assert.AreEqual(expected.Name, actual.Name);
                Assert.AreEqual(expected.Email, actual.Email);
                Assert.AreEqual(expected.Password, actual.Password);
            }
        }

        [Test]
        public void CheckEmpyty()
        {
            Assert.IsFalse(this.users.IsEmpty());
        }

        [Test]
        public void CheckPrepend()
        {
            User person = new User(0, "A", "B", "C");
            this.users.AddFirst(person);
            Assert.AreEqual(this.users.GetValue(0), person);
        }

        [Test]
        public void CheckAppend()
        {
            User person = new User(0, "A", "B", "C");
            this.users.AddLast(person);
            Assert.AreEqual(this.users.GetValue(this.users.Count() - 1), person);
        }

        [Test]
        public void CheckInsert()
        {
            User person = new User(0, "A", "B", "C");
            this.users.Add(person, 1);
            Assert.AreEqual(person, this.users.GetValue(1));
        }

        [Test]
        public void CheckReplace()
        {
            User person = new User(0, "A", "B", "C");
            this.users.Replace(person, 1);
            Assert.AreEqual(person, this.users.GetValue(1));
        }

        [Test]
        public void CheckRemoveFirst()
        {
            User Expected = this.users.GetValue(1);
            this.users.RemoveFirst();
            Assert.AreEqual(Expected, this.users.GetValue(0));
        }

        [Test]
        public void CheckRemoveLast()
        {
            int initialCount = this.users.Count();
            this.users.RemoveLast();
            Assert.AreEqual(initialCount - 1, this.users.Count());
        }

        [Test]
        public void CheckRemoveMiddle()
        {
            int initialCount = this.users.Count();
            int middleIndex = initialCount / 2;
            User removedUser = this.users.GetValue(middleIndex);
            this.users.Remove(middleIndex);

            Assert.IsFalse(this.users.Contains(removedUser));
        }

        [Test]
        public void CheckExistItem()
        {
            int index = 2;
            User user = this.users.GetValue(index);
            Assert.AreEqual(this.users.IndexOf(user), 2);
        }

        [Test]
        public void CheckReverseList()
        {
            User first = this.users.GetValue(0);
            this.users.ReverseList();
            Assert.AreEqual(this.users.IndexOf(first), this.users.Count() - 1);
        }


    }
}