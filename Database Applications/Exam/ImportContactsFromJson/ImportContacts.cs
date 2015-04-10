namespace ImportContactsFromJson
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Web.Script.Serialization;
    using PhonebookLibrary.Data;
    using PhonebookLibrary.Model;

    using Model.Dto;

    class ImportContacts
    {
        public static void Main()
        {
            var ser = new JavaScriptSerializer();
            var fileContent = File.ReadAllText("../../contacts.json");
            var importedDtos = ser.Deserialize<ContactDto[]>(fileContent);
            foreach (var contactDto in importedDtos)
            {
                try
                {
                    if (contactDto.Name != null )
                    {
                        using (var context = new PhonebookContext())
                        {
                            var newContact = new Contact
                            {
                                Name = contactDto.Name,
                                Notes = contactDto.Notes ?? null,
                                Position = contactDto.Position ?? null,
                                Company = contactDto.Company ?? null,
                                SiteUrl = contactDto.Site ?? null
                            };

                            if (contactDto.Phones.Any())
                            {
                                foreach (var phone in contactDto.Phones)
                                {
                                    newContact.Phones.Add(new Phone { Number = phone });
                                }
                            }

                            if (contactDto.Emails.Any())
                            {
                                foreach (var email in contactDto.Emails)
                                {
                                    newContact.Emails.Add(new Email { Address = email });
                                }
                            }

                            context.Contacts.Add(newContact);
                            context.SaveChanges();
                            Console.WriteLine("Contact {0} imported", newContact.Name);
                        }
                    }
                    else
                    {
                        throw new ArgumentException("Name is required");
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: {0}", e.Message);
                }
            }

        }
    }
}
