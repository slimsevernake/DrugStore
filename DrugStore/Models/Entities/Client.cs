using DrugStore.Models.Base;

namespace DrugStore.Models.Entities
{
    public class Client : BaseEntity<int>
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public int _age;
        public int Age
        {
            get
            {
                return _age;
            }

            set
            {
                if (value > 0 && value < 120)
                {
                    _age = value;
                }
                else
                {
                    _age = 0;
                }
            }
        }
        public string Email { get; set; }
        public string Phone { get; set; }

    }
}