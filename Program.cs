using Microsoft.VisualBasic;

namespace Day27AddressBookFileIO
{
    class Program
    {
        public static void Main(string[] args)
        {
            AddressBook myAddressBook = new AddressBook();
            Contacts newContact = new Contacts("Prince", "Praveen", "INDIA", "8369319177", "prince.p@example.com");
            Contacts newContact2 = new Contacts("Robert", "Downey", "USA", "888222444", "robery.downey@jr.com");
            //Contacts newContact3 = new Contacts("Robert", "Downey", "USA", "888222444", "robery.downey@jr.com");

            myAddressBook.AddContact(newContact);
            myAddressBook.AddContact(newContact2);
            
            myAddressBook.PrintContacts();


            //string path = "C:\\Users\\princ\\OneDrive\\Desktop\\dotnet\\Day27AddressBookFileIO\\Day27AddressBookFileIO\\NewFile.txt";

            string path = "C:\\Users\\princ\\OneDrive\\Desktop\\dotnet\\Day27AddressBookFileIO\\Day27AddressBookFileIO\\NewFile.json";

            myAddressBook.WriteToJsonFile(path);

        }
     }
 }