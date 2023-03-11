using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using Newtonsoft.Json;

namespace Day27AddressBookFileIO
{
    public class AddressBook
    {
        public List<Contacts> ContactInfo { get; set; }

        public AddressBook()
        {
            ContactInfo = new List<Contacts>();
        }

        public void AddContact(Contacts contact)
        {
            bool isDuplicate = ContactInfo.Exists(existingContact => existingContact.firstName == contact.firstName && existingContact.lastName == contact.lastName);

            if (!isDuplicate)
            {
                ContactInfo.Add(contact);
                Console.WriteLine("Contact added successfully!");
            }
            else
            {
                Console.WriteLine("A contact with the same name already exists in the address book. Contact not added.");
            }
        }

        public void PrintContacts()
        {
            foreach (Contacts contact in ContactInfo)
            {
                Console.WriteLine("Name: {0} {1}\nCountry: {2}\nPhone: {3}\nEmail: {4}\n",
                    contact.firstName, contact.lastName, contact.country, contact.phoneNumber, contact.email);
            }
        }

        public void WriteToJsonFile(string filePath)
        {
            try
            {
                string json = JsonConvert.SerializeObject(ContactInfo, Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(filePath, json);

                Console.WriteLine("Address book written to file successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error writing to file: {0}", ex.Message);
            }
        }

        public void ReadFromJsonFile(string filePath)
        {
            try
            {
                string json = File.ReadAllText(filePath);
                ContactInfo = JsonConvert.DeserializeObject<List<Contacts>>(json);

                Console.WriteLine("Address book read from file successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error reading from file: {0}", ex.Message);
            }
        }
    }
}