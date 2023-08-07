using Game.WordGame.Share.Models;
using Microsoft.JSInterop;

namespace Game.WordGame.Services
{
    public class PersonService
    {
        private ILocalStorageService LocalStorageService;
        public PersonService(ILocalStorageService localStorageService)
        {
            LocalStorageService = localStorageService;
        }
        public Person Person
        {
            get
            {
                var person = LocalStorageService.GetItem<Person>("person");
                if (person != null)
                {
                    return person;
                }
                else
                {
                    person = new Person { Id = Guid.NewGuid() };
                    LocalStorageService.SetItem("person", person);
                    return person;
                }
            }
        }

    }
}
