using Unik.Domain.Shared;


namespace Unik.Domain.Entities
{
    public class Member : BaseEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; } 
        public string? Address { get; set; }
        public string? UserId { get; set; } //String fordi det er ID fra Identity


        // public string UserId { get; set; }
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

        public void Edit(string name, string address) //Tanken er at vi opretter et nyt medlem kun med UserId og derefter kan vi tilføje navn og adresse et andet sted.
        {
            Name = name;
            Address = address;
        }
    }
}
