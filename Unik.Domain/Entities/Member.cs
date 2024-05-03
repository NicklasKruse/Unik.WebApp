using Unik.Domain.DomainServices;
using Unik.Domain.Shared;


namespace Unik.Domain.Entities
{
    public class Member : BaseEntity
    {

        internal Member() 
        {
            //EF
        }
        public Member(int id, string UserId) //Til oprettelse af bruger med nyt UserId evt til at teste
        {
            Id = id;
            this.UserId = UserId;
        }
        public Member(string UserId) //Til oprettelse af bruger og tildeling af UserId
        {
            this.UserId = UserId;
        }

        public Member(string name, string address) 
        {
            Name = name;
            Address = address;
        }
        public Member(string UserId, string name, string address)
        {
            this.UserId = UserId;
            Name = name;
            Address = address;
        }
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? UserId { get; set; } //String fordi det er ID fra Identity

       // public List<Booking> Bookings { get; set; } //hvilke bookings har de lavet. Hold det seperat for nu. Evt. Implementer forbindelse til bookings senere så man kan se hvilke bookings de har lavet før.

        public void Edit(string name, string address) //Edit er som sådan ikke Businesslogic. Opdatere bare properties og derfor kan den være i entiteten. Bruges sammen med Load i repository. Så kan vi skilde vores Entities fra vores DTO'er
        {
            Name = name;
            Address = address;
        }
    }
}
